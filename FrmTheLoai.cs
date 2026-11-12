using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hệ_Thống_Quản_Lý_Thư_Viện.Classes;

namespace Hệ_Thống_Quản_Lý_Thư_Viện.Forms
{
    /// <summary>
    /// Quản lý thể loại - Form con (nhúng vào pnlContent của FrmMain, giống FrmSinhVien).
    /// Giao diện: TV3. Logic: TV4. Form KHÔNG tự mở/đóng FrmMain, không gọi Application.Exit().
    /// CSDL: tblTheLoai(MaTL, TenTL). Xóa thể loại đang có sách sẽ bị khóa ngoại chặn -> cần báo lỗi dễ hiểu.
    /// </summary>
    public partial class FrmTheLoai : Form
    {
        private enum CheDo
        {
            Xem,
            Them,
            Sua
        }

        private readonly DataProcesser db = new();
        private CheDo cheDo = CheDo.Xem;

        public FrmTheLoai()
        {
            InitializeComponent();

            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLuuTheLoai.Click += BtnLuuTheLoai_Click;
            txtTimKiem.TextChanged += TimKiem_Changed;
            radTimMa.CheckedChanged += TimKiem_Changed;
            radTimTen.CheckedChanged += TimKiem_Changed;
            dgvTheLoai.SelectionChanged += DgvTheLoai_SelectionChanged;
        }

        private void FrmTheLoai_Load(object? sender, EventArgs e)
        {
            TaiDuLieu();
            DatCheDo(CheDo.Xem);
        }

        private void TaiDuLieu()
        {
            try
            {
                string cotTim = radTimMa.Checked ? "MaTL" : "TenTL";
                string sql = string.IsNullOrWhiteSpace(txtTimKiem.Text)
                    ? "SELECT MaTL, TenTL FROM tblTheLoai ORDER BY MaTL"
                    : $"SELECT MaTL, TenTL FROM tblTheLoai WHERE {cotTim} LIKE @tuKhoa ORDER BY MaTL";

                dgvTheLoai.DataSource = string.IsNullOrWhiteSpace(txtTimKiem.Text)
                    ? db.DocBang(sql)
                    : db.DocBang(sql, DataProcesser.Tham("@tuKhoa", "%" + txtTimKiem.Text.Trim() + "%"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách thể loại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimKiem_Changed(object? sender, EventArgs e)
        {
            if (IsHandleCreated && cheDo == CheDo.Xem)
                TaiDuLieu();
        }

        private void DgvTheLoai_SelectionChanged(object? sender, EventArgs e)
        {
            if (cheDo == CheDo.Xem && dgvTheLoai.CurrentRow?.DataBoundItem is DataRowView row)
            {
                txtMaTL.Text = Convert.ToString(row["MaTL"]) ?? "";
                cboTenTL.Text = Convert.ToString(row["TenTL"]) ?? "";
            }
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            try
            {
                XoaNhapLieu();
                txtMaTL.Text = db.SinhMa("tblTheLoai", "MaTL", "TL", 2);
                DatCheDo(CheDo.Them);
                cboTenTL.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tạo mã thể loại mới: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click(object? sender, EventArgs e)
        {
            if (dgvTheLoai.CurrentRow?.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn thể loại cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DatCheDo(CheDo.Sua);
            cboTenTL.Focus();
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            string ma = txtMaTL.Text.Trim();
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui lòng chọn thể loại cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa thể loại {ma}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                db.CapNhatDuLieu("DELETE FROM tblTheLoai WHERE MaTL=@MaTL", DataProcesser.Tham("@MaTL", ma));
                TaiDuLieu();
                XoaNhapLieu();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể xóa thể loại đang được sử dụng bởi sách.\n\n" + ex.Message,
                    "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thể loại thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLuuTheLoai_Click(object? sender, EventArgs e)
        {
            string ma = txtMaTL.Text.Trim();
            string ten = cboTenTL.Text.Trim();
            if (string.IsNullOrWhiteSpace(ma) || ma.Length > 10)
            {
                MessageBox.Show("Mã thể loại không được trống và tối đa 10 ký tự.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTL.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ten) || ten.Length > 50)
            {
                MessageBox.Show("Tên thể loại không được trống và tối đa 50 ký tự.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTenTL.Focus();
                return;
            }

            try
            {
                if (cheDo == CheDo.Them)
                {
                    db.CapNhatDuLieu(@"INSERT INTO tblTheLoai (MaTL, TenTL)
                                       VALUES (@MaTL, @TenTL)",
                        DataProcesser.Tham("@MaTL", ma), DataProcesser.Tham("@TenTL", ten));
                }
                else if (cheDo == CheDo.Sua)
                {
                    db.CapNhatDuLieu(@"UPDATE tblTheLoai SET TenTL=@TenTL
                                       WHERE MaTL=@MaTL",
                        DataProcesser.Tham("@MaTL", ma), DataProcesser.Tham("@TenTL", ten));
                }

                TaiDuLieu();
                DatCheDo(CheDo.Xem);
                ChonTheoMa(ma);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể lưu thể loại. Mã thể loại có thể đã tồn tại.\n\n" + ex.Message,
                    "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu thể loại thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DatCheDo(CheDo moi)
        {
            cheDo = moi;
            bool dangSua = moi != CheDo.Xem;
            txtMaTL.ReadOnly = moi != CheDo.Them;
            cboTenTL.Enabled = dangSua;
            btnLuuTheLoai.Enabled = dangSua;
            btnThem.Enabled = !dangSua;
            btnSua.Enabled = !dangSua;
            btnXoa.Enabled = !dangSua;
        }

        private void XoaNhapLieu()
        {
            txtMaTL.Clear();
            cboTenTL.Text = "";
        }

        private void ChonTheoMa(string ma)
        {
            foreach (DataGridViewRow row in dgvTheLoai.Rows)
            {
                if (string.Equals(Convert.ToString(row.Cells["colMaTL"].Value), ma,
                    StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;
                    dgvTheLoai.CurrentCell = row.Cells["colMaTL"];
                    return;
                }
            }
        }
    }
}
