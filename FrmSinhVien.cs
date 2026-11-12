using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hệ_Thống_Quản_Lý_Thư_Viện.Classes;

namespace Hệ_Thống_Quản_Lý_Thư_Viện.Forms
{
    /// <summary>
    /// Quản lý Sinh viên - Độc giả. Giao diện: TV3 (đã chuyển thành form con theo INTEGRATION_GUIDE).
    /// Bảng tblSinhVien(MaSV, TenSV, NganhHoc, KhoaHoc, SoDienThoai).
    /// dgvSinhVien đã đặt sẵn DataPropertyName trùng tên cột SQL (AutoGenerateColumns = false):
    ///   dgvSinhVien.DataSource = db.DocBang("select * from tblSinhVien");
    /// </summary>
    public partial class FrmSinhVien : Form
    {
        private enum CheDo
        {
            Xem,
            Them,
            Sua
        }

        private readonly DataProcesser db = new();
        private CheDo cheDo = CheDo.Xem;

        public FrmSinhVien()
        {
            InitializeComponent();

            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnGhi.Click += BtnGhi_Click;
            btnHuy.Click += BtnHuy_Click;
            txtTimKiem.TextChanged += TimKiem_Changed;
            radTimMa.CheckedChanged += TimKiem_Changed;
            radTimTen.CheckedChanged += TimKiem_Changed;
            dgvSinhVien.SelectionChanged += DgvSinhVien_SelectionChanged;
        }

        private void FrmSinhVien_Load(object? sender, EventArgs e)
        {
            if (!TaiKhoanDangNhap.CoQuyen(ChucNang.SinhVien))
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng này.", "Phân quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BeginInvoke(Close);
                return;
            }

            cboKhoaHoc.Items.Clear();
            cboKhoaHoc.Items.AddRange(new object[] { "K63", "K62", "K61" });
            cboKhoaHoc.SelectedIndex = 0;

            TaiDuLieu();
            DatCheDo(CheDo.Xem);
        }

        private void TaiDuLieu()
        {
            try
            {
                string cotTim = radTimMa.Checked ? "MaSV" : "TenSV";
                string sql = string.IsNullOrWhiteSpace(txtTimKiem.Text)
                    ? "SELECT MaSV, TenSV, NganhHoc, KhoaHoc, SoDienThoai FROM tblSinhVien ORDER BY MaSV"
                    : $"SELECT MaSV, TenSV, NganhHoc, KhoaHoc, SoDienThoai FROM tblSinhVien WHERE {cotTim} LIKE @tuKhoa ORDER BY MaSV";

                dgvSinhVien.DataSource = string.IsNullOrWhiteSpace(txtTimKiem.Text)
                    ? db.DocBang(sql)
                    : db.DocBang(sql, DataProcesser.Tham("@tuKhoa", "%" + txtTimKiem.Text.Trim() + "%"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách sinh viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimKiem_Changed(object? sender, EventArgs e)
        {
            if (IsHandleCreated && cheDo == CheDo.Xem)
                TaiDuLieu();
        }

        private void DgvSinhVien_SelectionChanged(object? sender, EventArgs e)
        {
            if (cheDo == CheDo.Xem && dgvSinhVien.CurrentRow?.DataBoundItem is DataRowView row)
                HienThiSinhVien(row.Row);
        }

        private void HienThiSinhVien(DataRow row)
        {
            txtMaSV.Text = Convert.ToString(row["MaSV"]) ?? "";
            txtTenSV.Text = Convert.ToString(row["TenSV"]) ?? "";
            txtNganhHoc.Text = row["NganhHoc"] == DBNull.Value ? "" : Convert.ToString(row["NganhHoc"]) ?? "";
            txtSoDienThoai.Text = row["SoDienThoai"] == DBNull.Value ? "" : Convert.ToString(row["SoDienThoai"]) ?? "";

            string khoaHoc = row["KhoaHoc"] == DBNull.Value ? "" : Convert.ToString(row["KhoaHoc"]) ?? "";
            if (!cboKhoaHoc.Items.Contains(khoaHoc) && !string.IsNullOrWhiteSpace(khoaHoc))
                cboKhoaHoc.Items.Add(khoaHoc);
            cboKhoaHoc.SelectedItem = khoaHoc;
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                XoaNhapLieu();
                txtMaSV.Text = db.SinhMa("tblSinhVien", "MaSV", "", 4);
                DatCheDo(CheDo.Them);
                txtTenSV.Focus();
            }
            catch (Exception ex)
            {
                DatCheDo(CheDo.Xem);
                MessageBox.Show("Không thể tạo mã sinh viên mới: " + ex.Message, "Lỗi kết nối CSDL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click(object? sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow?.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DatCheDo(CheDo.Sua);
            txtTenSV.Focus();
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            string ma = txtMaSV.Text.Trim();
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa sinh viên {ma}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                db.CapNhatDuLieu("DELETE FROM tblSinhVien WHERE MaSV=@MaSV",
                    DataProcesser.Tham("@MaSV", ma));
                TaiDuLieu();
                XoaNhapLieu();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể xóa sinh viên này vì có thể đang có phiếu mượn.\n\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa sinh viên thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGhi_Click(object? sender, EventArgs e)
        {
            if (cheDo == CheDo.Xem || !KiemTraDuLieu())
                return;

            string maDaGhi = txtMaSV.Text.Trim();
            try
            {
                SqlParameter[] thamSo =
                {
                    DataProcesser.Tham("@MaSV", maDaGhi),
                    DataProcesser.Tham("@TenSV", txtTenSV.Text.Trim()),
                    DataProcesser.Tham("@NganhHoc", txtNganhHoc.Text.Trim()),
                    DataProcesser.Tham("@KhoaHoc", cboKhoaHoc.Text.Trim()),
                    DataProcesser.Tham("@SoDienThoai", txtSoDienThoai.Text.Trim())
                };

                if (cheDo == CheDo.Them)
                {
                    db.CapNhatDuLieu(
                        "INSERT INTO tblSinhVien (MaSV, TenSV, NganhHoc, KhoaHoc, SoDienThoai) VALUES (@MaSV, @TenSV, @NganhHoc, @KhoaHoc, @SoDienThoai)",
                        thamSo);
                }
                else
                {
                    db.CapNhatDuLieu(
                        "UPDATE tblSinhVien SET TenSV=@TenSV, NganhHoc=@NganhHoc, KhoaHoc=@KhoaHoc, SoDienThoai=@SoDienThoai WHERE MaSV=@MaSV",
                        thamSo);
                }

                TaiDuLieu();
                DatCheDo(CheDo.Xem);
                ChonTheoMa(maDaGhi);
                MessageBox.Show("Đã ghi thông tin sinh viên.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể ghi dữ liệu. Mã sinh viên có thể đã tồn tại hoặc dữ liệu không hợp lệ.\n\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ghi dữ liệu thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHuy_Click(object? sender, EventArgs e)
        {
            DatCheDo(CheDo.Xem);
            if (dgvSinhVien.CurrentRow?.DataBoundItem is DataRowView row)
                HienThiSinhVien(row.Row);
            else
                XoaNhapLieu();
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) || txtMaSV.Text.Trim().Length > 10)
            {
                MessageBox.Show("Mã sinh viên không được trống và tối đa 10 ký tự.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenSV.Text) || txtTenSV.Text.Trim().Length > 50)
            {
                MessageBox.Show("Họ tên không được trống và tối đa 50 ký tự.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSV.Focus();
                return false;
            }
            if (txtNganhHoc.Text.Trim().Length > 30)
            {
                MessageBox.Show("Ngành học tối đa 30 ký tự.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNganhHoc.Focus();
                return false;
            }
            if (txtSoDienThoai.Text.Trim().Length > 15)
            {
                MessageBox.Show("Số điện thoại tối đa 15 ký tự.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return false;
            }
            return true;
        }

        private void DatCheDo(CheDo moi)
        {
            cheDo = moi;
            bool dangSua = moi != CheDo.Xem;
            txtMaSV.ReadOnly = moi != CheDo.Them;
            txtTenSV.ReadOnly = !dangSua;
            txtNganhHoc.ReadOnly = !dangSua;
            txtSoDienThoai.ReadOnly = !dangSua;
            cboKhoaHoc.Enabled = dangSua;
            btnGhi.Enabled = dangSua;
            btnHuy.Enabled = dangSua;
            btnThem.Enabled = !dangSua;
            btnSua.Enabled = !dangSua;
            btnXoa.Enabled = !dangSua;
        }

        private void XoaNhapLieu()
        {
            txtMaSV.Clear();
            txtTenSV.Clear();
            txtNganhHoc.Clear();
            txtSoDienThoai.Clear();
            if (cboKhoaHoc.Items.Count > 0)
                cboKhoaHoc.SelectedIndex = 0;
        }

        private void ChonTheoMa(string ma)
        {
            foreach (DataGridViewRow row in dgvSinhVien.Rows)
            {
                if (string.Equals(Convert.ToString(row.Cells["colMaSV"].Value), ma, StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;
                    dgvSinhVien.CurrentCell = row.Cells["colMaSV"];
                    return;
                }
            }
        }
    }
}
