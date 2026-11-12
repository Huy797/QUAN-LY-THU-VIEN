using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hệ_Thống_Quản_Lý_Thư_Viện.Classes;

namespace Hệ_Thống_Quản_Lý_Thư_Viện.Forms
{
    /// <summary>
    /// Quản lý nhân viên - Form con (nhúng vào pnlContent của FrmMain, giống FrmSinhVien).
    /// Giao diện: TV3. Logic: TV4. Form KHÔNG tự mở/đóng FrmMain, không gọi Application.Exit().
    /// CSDL: tblNhanVien(MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, SoDienThoai, ChucVu). Lưu ý: giao diện có ô Email (txtEmail) nhưng bảng chưa có cột Email, và chưa có ô GioiTinh/NgaySinh/DiaChi -> nhóm cần thống nhất với TV2/TV3. Chỉ Admin được vào form này (xem TaiKhoanDangNhap.CoQuyen).
    /// </summary>
    public partial class FrmNhanVien : Form
    {
        private enum CheDo
        {
            Xem,
            Them,
            Sua
        }

        private readonly DataProcesser db = new();
        private CheDo cheDo = CheDo.Xem;

        public FrmNhanVien()
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
            dgvNhanVien.SelectionChanged += DgvNhanVien_SelectionChanged;
        }

        private void FrmNhanVien_Load(object? sender, EventArgs e)
        {
            if (!TaiKhoanDangNhap.CoQuyen(ChucNang.NhanVien))
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng này.", "Phân quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BeginInvoke(Close);
                return;
            }

            cboChucVu.Items.Clear();
            cboChucVu.Items.AddRange(new object[] { "Thủ thư", "Quản lý", "Nhân viên" });
            cboChucVu.SelectedIndex = 0;

            TaiDuLieu();
            DatCheDo(CheDo.Xem);
        }

        private void TaiDuLieu()
        {
            try
            {
                string cotTim = radTimMa.Checked ? "MaNV" : "TenNV";
                string sql = string.IsNullOrWhiteSpace(txtTimKiem.Text)
                    ? "SELECT MaNV, TenNV, ChucVu, SoDienThoai FROM tblNhanVien ORDER BY MaNV"
                    : $"SELECT MaNV, TenNV, ChucVu, SoDienThoai FROM tblNhanVien WHERE {cotTim} LIKE @tuKhoa ORDER BY MaNV";

                dgvNhanVien.DataSource = string.IsNullOrWhiteSpace(txtTimKiem.Text)
                    ? db.DocBang(sql)
                    : db.DocBang(sql, DataProcesser.Tham("@tuKhoa", "%" + txtTimKiem.Text.Trim() + "%"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách nhân viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimKiem_Changed(object? sender, EventArgs e)
        {
            if (IsHandleCreated && cheDo == CheDo.Xem)
                TaiDuLieu();
        }

        private void DgvNhanVien_SelectionChanged(object? sender, EventArgs e)
        {
            if (cheDo == CheDo.Xem && dgvNhanVien.CurrentRow?.DataBoundItem is DataRowView row)
                HienThiNhanVien(row.Row);
        }

        private void HienThiNhanVien(DataRow row)
        {
            txtMaNV.Text = Convert.ToString(row["MaNV"]) ?? "";
            txtTenNV.Text = Convert.ToString(row["TenNV"]) ?? "";
            txtSoDienThoai.Text = row["SoDienThoai"] == DBNull.Value ? "" : Convert.ToString(row["SoDienThoai"]) ?? "";
            string chucVu = row["ChucVu"] == DBNull.Value ? "" : Convert.ToString(row["ChucVu"]) ?? "";
            if (!cboChucVu.Items.Contains(chucVu) && !string.IsNullOrWhiteSpace(chucVu))
                cboChucVu.Items.Add(chucVu);
            cboChucVu.SelectedItem = chucVu;
            txtEmail.Clear();
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                XoaNhapLieu();
                txtMaNV.Text = db.SinhMa("tblNhanVien", "MaNV", "NV", 2);
                DatCheDo(CheDo.Them);
                txtTenNV.Focus();
            }
            catch (Exception ex)
            {
                DatCheDo(CheDo.Xem);
                MessageBox.Show("Không thể tạo mã nhân viên mới: " + ex.Message, "Lỗi kết nối CSDL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click(object? sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow?.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cheDo = CheDo.Sua;
            DatCheDo(cheDo);
            txtTenNV.Focus();
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            string ma = txtMaNV.Text.Trim();
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa nhân viên {ma}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                db.CapNhatDuLieu("DELETE FROM tblNhanVien WHERE MaNV=@MaNV", DataProcesser.Tham("@MaNV", ma));
                TaiDuLieu();
                XoaNhapLieu();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể xóa nhân viên này. Có thể nhân viên đang được dùng trong tài khoản hoặc phiếu mượn.\n\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa nhân viên thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGhi_Click(object? sender, EventArgs e)
        {
            if (cheDo == CheDo.Xem)
                return;
            if (!KiemTraDuLieu())
                return;

            try
            {
                string maDaGhi = txtMaNV.Text.Trim();
                SqlParameter[] thamSo =
                {
                    DataProcesser.Tham("@MaNV", txtMaNV.Text.Trim()),
                    DataProcesser.Tham("@TenNV", txtTenNV.Text.Trim()),
                    DataProcesser.Tham("@SoDienThoai", txtSoDienThoai.Text.Trim()),
                    DataProcesser.Tham("@ChucVu", cboChucVu.Text.Trim())
                };

                if (cheDo == CheDo.Them)
                    db.CapNhatDuLieu("INSERT INTO tblNhanVien (MaNV, TenNV, SoDienThoai, ChucVu) VALUES (@MaNV, @TenNV, @SoDienThoai, @ChucVu)", thamSo);
                else
                    db.CapNhatDuLieu("UPDATE tblNhanVien SET TenNV=@TenNV, SoDienThoai=@SoDienThoai, ChucVu=@ChucVu WHERE MaNV=@MaNV", thamSo);

                TaiDuLieu();
                DatCheDo(CheDo.Xem);
                ChonTheoMa(maDaGhi);
                MessageBox.Show("Đã ghi thông tin nhân viên.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể ghi dữ liệu. Mã nhân viên có thể đã tồn tại hoặc dữ liệu không hợp lệ.\n\n" + ex.Message,
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
            if (dgvNhanVien.CurrentRow?.DataBoundItem is DataRowView row)
                HienThiNhanVien(row.Row);
            else
                XoaNhapLieu();
        }

        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) || txtMaNV.Text.Trim().Length > 10)
            {
                MessageBox.Show("Mã nhân viên không được trống và tối đa 10 ký tự.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenNV.Text) || txtTenNV.Text.Trim().Length > 50)
            {
                MessageBox.Show("Họ tên không được trống và tối đa 50 ký tự.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
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
            txtMaNV.ReadOnly = moi != CheDo.Them;
            txtTenNV.ReadOnly = !dangSua;
            txtSoDienThoai.ReadOnly = !dangSua;
            txtEmail.ReadOnly = !dangSua;
            cboChucVu.Enabled = dangSua;
            btnGhi.Enabled = dangSua;
            btnHuy.Enabled = dangSua;
            btnSua.Enabled = !dangSua;
            btnXoa.Enabled = !dangSua;
            btnThem.Enabled = !dangSua;
        }

        private void XoaNhapLieu()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            if (cboChucVu.Items.Count > 0)
                cboChucVu.SelectedIndex = 0;
        }

        private void ChonTheoMa(string ma)
        {
            foreach (DataGridViewRow row in dgvNhanVien.Rows)
            {
                if (string.Equals(Convert.ToString(row.Cells["colMaNV"].Value), ma, StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;
                    dgvNhanVien.CurrentCell = row.Cells["colMaNV"];
                    return;
                }
            }
        }
    }
}
