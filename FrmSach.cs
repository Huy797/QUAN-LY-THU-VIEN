using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hệ_Thống_Quản_Lý_Thư_Viện.Classes;

namespace Hệ_Thống_Quản_Lý_Thư_Viện.Forms
{
    /// <summary>
    /// Quản lý sách - Form con (nhúng vào pnlContent của FrmMain, giống FrmSinhVien).
    /// Giao diện: TV3. Logic: TV4. Form KHÔNG tự mở/đóng FrmMain, không gọi Application.Exit().
    /// CSDL: tblSach(MaSach, TenSach, TacGia, MaTL, NhaXuatBan, NamXuatBan, SoLuong). cboTheLoai nạp từ tblTheLoai (lưu MaTL). Lưu ý: giao diện dùng ComboBox cho Nhà xuất bản (cột là chuỗi tự do) và chưa có ô NamXuatBan. SoLuong = số cuốn CÒN trong thư viện.
    /// </summary>
    public partial class FrmSach : Form
    {
        private enum CheDo
        {
            Xem,
            Them,
            Sua
        }

        private readonly DataProcesser db = new();
        private CheDo cheDo = CheDo.Xem;

        public FrmSach()
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
            dgvSach.SelectionChanged += DgvSach_SelectionChanged;
        }

        private void FrmSach_Load(object? sender, EventArgs e)
        {
            cboTheLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            TaiDanhSachTheLoai();
            TaiDuLieu();
            DatCheDo(CheDo.Xem);
        }

        private void TaiDanhSachTheLoai()
        {
            try
            {
                DataTable theLoai = db.DocBang("SELECT MaTL, TenTL FROM tblTheLoai ORDER BY TenTL");
                cboTheLoai.DataSource = theLoai;
                cboTheLoai.DisplayMember = "TenTL";
                cboTheLoai.ValueMember = "MaTL";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách thể loại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiDuLieu()
        {
            try
            {
                string cotTim = radTimMa.Checked ? "MaSach" : "TenSach";
                string sql = string.IsNullOrWhiteSpace(txtTimKiem.Text)
                    ? "SELECT MaSach, TenSach, TacGia, MaTL, NhaXuatBan, SoLuong FROM tblSach ORDER BY MaSach"
                    : $"SELECT MaSach, TenSach, TacGia, MaTL, NhaXuatBan, SoLuong FROM tblSach WHERE {cotTim} LIKE @tuKhoa ORDER BY MaSach";

                dgvSach.DataSource = string.IsNullOrWhiteSpace(txtTimKiem.Text)
                    ? db.DocBang(sql)
                    : db.DocBang(sql, DataProcesser.Tham("@tuKhoa", "%" + txtTimKiem.Text.Trim() + "%"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimKiem_Changed(object? sender, EventArgs e)
        {
            if (IsHandleCreated && cheDo == CheDo.Xem)
                TaiDuLieu();
        }

        private void DgvSach_SelectionChanged(object? sender, EventArgs e)
        {
            if (cheDo != CheDo.Xem || dgvSach.CurrentRow?.DataBoundItem is not DataRowView row)
                return;

            txtMaSach.Text = Convert.ToString(row["MaSach"]) ?? "";
            txtTenSach.Text = Convert.ToString(row["TenSach"]) ?? "";
            txtTacGia.Text = row["TacGia"] == DBNull.Value ? "" : Convert.ToString(row["TacGia"]) ?? "";
            cboNhaXuatBan.Text = row["NhaXuatBan"] == DBNull.Value ? "" : Convert.ToString(row["NhaXuatBan"]) ?? "";
            txtSoLuong.Text = Convert.ToString(row["SoLuong"]) ?? "0";

            string maTL = row["MaTL"] == DBNull.Value ? "" : Convert.ToString(row["MaTL"]) ?? "";
            if (!string.IsNullOrWhiteSpace(maTL))
                cboTheLoai.SelectedValue = maTL;
            else
                cboTheLoai.SelectedIndex = -1;
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                XoaNhapLieu();
                txtMaSach.Text = db.SinhMa("tblSach", "MaSach", "S", 3);
                DatCheDo(CheDo.Them);
                txtTenSach.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tạo mã sách mới: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click(object? sender, EventArgs e)
        {
            if (dgvSach.CurrentRow?.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn sách cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DatCheDo(CheDo.Sua);
            txtTenSach.Focus();
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            string ma = txtMaSach.Text.Trim();
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui lòng chọn sách cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa sách {ma}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                db.CapNhatDuLieu("DELETE FROM tblSach WHERE MaSach=@MaSach", DataProcesser.Tham("@MaSach", ma));
                TaiDuLieu();
                XoaNhapLieu();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể xóa sách đang được sử dụng trong phiếu mượn.\n\n" + ex.Message,
                    "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa sách thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGhi_Click(object? sender, EventArgs e)
        {
            string ma = txtMaSach.Text.Trim();
            string ten = txtTenSach.Text.Trim();
            string tacGia = txtTacGia.Text.Trim();
            string nhaXuatBan = cboNhaXuatBan.Text.Trim();
            string maTL = cboTheLoai.SelectedValue?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(ma) || ma.Length > 10)
            {
                MessageBox.Show("Mã sách không được trống và tối đa 10 ký tự.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSach.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(ten) || ten.Length > 100)
            {
                MessageBox.Show("Tên sách không được trống và tối đa 100 ký tự.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSach.Focus();
                return;
            }
            if (tacGia.Length > 50 || nhaXuatBan.Length > 50)
            {
                MessageBox.Show("Tên tác giả và nhà xuất bản tối đa 50 ký tự.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên không âm.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(maTL))
            {
                MessageBox.Show("Vui lòng chọn thể loại.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTheLoai.Focus();
                return;
            }

            try
            {
                if (cheDo == CheDo.Them)
                {
                    db.CapNhatDuLieu(@"INSERT INTO tblSach
                        (MaSach, TenSach, TacGia, MaTL, NhaXuatBan, SoLuong)
                        VALUES (@MaSach, @TenSach, @TacGia, @MaTL, @NhaXuatBan, @SoLuong)",
                        DataProcesser.Tham("@MaSach", ma), DataProcesser.Tham("@TenSach", ten),
                        DataProcesser.Tham("@TacGia", tacGia), DataProcesser.Tham("@MaTL", maTL),
                        DataProcesser.Tham("@NhaXuatBan", nhaXuatBan), DataProcesser.Tham("@SoLuong", soLuong));
                }
                else if (cheDo == CheDo.Sua)
                {
                    db.CapNhatDuLieu(@"UPDATE tblSach SET TenSach=@TenSach, TacGia=@TacGia,
                        MaTL=@MaTL, NhaXuatBan=@NhaXuatBan, SoLuong=@SoLuong
                        WHERE MaSach=@MaSach",
                        DataProcesser.Tham("@MaSach", ma), DataProcesser.Tham("@TenSach", ten),
                        DataProcesser.Tham("@TacGia", tacGia), DataProcesser.Tham("@MaTL", maTL),
                        DataProcesser.Tham("@NhaXuatBan", nhaXuatBan), DataProcesser.Tham("@SoLuong", soLuong));
                }

                TaiDuLieu();
                DatCheDo(CheDo.Xem);
                ChonTheoMa(ma);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể lưu sách. Mã sách có thể đã tồn tại hoặc thể loại không hợp lệ.\n\n" + ex.Message,
                    "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu sách thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHuy_Click(object? sender, EventArgs e)
        {
            DatCheDo(CheDo.Xem);
            if (dgvSach.CurrentRow?.DataBoundItem is DataRowView row)
                DgvSach_SelectionChanged(dgvSach, EventArgs.Empty);
            else
                XoaNhapLieu();
        }

        private void DatCheDo(CheDo moi)
        {
            cheDo = moi;
            bool dangSua = moi != CheDo.Xem;
            txtMaSach.ReadOnly = moi != CheDo.Them;
            txtTenSach.ReadOnly = !dangSua;
            txtTacGia.ReadOnly = !dangSua;
            cboNhaXuatBan.Enabled = dangSua;
            txtSoLuong.ReadOnly = !dangSua;
            cboTheLoai.Enabled = dangSua;
            btnGhi.Enabled = dangSua;
            btnHuy.Enabled = dangSua;
            btnThem.Enabled = !dangSua;
            btnSua.Enabled = !dangSua;
            btnXoa.Enabled = !dangSua;
        }

        private void XoaNhapLieu()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtTacGia.Clear();
            cboNhaXuatBan.Text = "";
            txtSoLuong.Text = "0";
            if (cboTheLoai.Items.Count > 0)
                cboTheLoai.SelectedIndex = 0;
        }

        private void ChonTheoMa(string ma)
        {
            foreach (DataGridViewRow row in dgvSach.Rows)
            {
                if (string.Equals(Convert.ToString(row.Cells["colMaSach"].Value), ma,
                    StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;
                    dgvSach.CurrentCell = row.Cells["colMaSach"];
                    return;
                }
            }
        }
    }
}
