using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Hệ_Thống_Quản_Lý_Thư_Viện.Classes;

namespace Hệ_Thống_Quản_Lý_Thư_Viện.Forms
{
    /// <summary>
    /// Quản lý mượn trả - Form con (nhúng vào pnlContent của FrmMain, giống FrmSinhVien).
    /// Giao diện: TV3. Logic: TV4. Form KHÔNG tự mở/đóng FrmMain, không gọi Application.Exit().
    /// CSDL: tblPhieuMuon, tblChiTietMuon (NgayTra = NULL là chưa trả), view v_DangMuon. Mượn: thêm phiếu + chi tiết + trừ tblSach.SoLuong; Trả: cập nhật NgayTra + cộng lại SoLuong -> nên làm trong 1 transaction (DataProcesser hiện chưa hỗ trợ).
    /// </summary>
    public partial class FrmMuonTra : Form
    {
        private readonly DataProcesser db = new();

        public FrmMuonTra()
        {
            InitializeComponent();

            btnXacNhanMuon.Click += BtnXacNhanMuon_Click;
            btnXacNhanTra.Click += BtnXacNhanTra_Click;
            btnInPhieu.Click += BtnInPhieu_Click;
            cboXuLyTra.SelectedIndexChanged += CboXuLyTra_SelectedIndexChanged;
        }

        private void FrmMuonTra_Load(object? sender, EventArgs e)
        {
            if (!TaiKhoanDangNhap.CoQuyen(ChucNang.MuonTra))
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng này.", "Phân quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BeginInvoke(Close);
                return;
            }

            txtNgayMuon.Text = DateTime.Today.ToString("yyyy-MM-dd");
            lblLapPhieuMuon.Text = "Sách mượn";
            lblXuLyTra.Text = "Phiếu trả";
            cboLapPhieuMuon.DropDownStyle = ComboBoxStyle.DropDownList;
            cboXuLyTra.DropDownStyle = ComboBoxStyle.DropDownList;

            TaiDanhSachSach();
            TaiDuLieu();
        }

        private void TaiDanhSachSach()
        {
            try
            {
                DataTable sach = db.DocBang(
                    "SELECT MaSach, TenSach, SoLuong FROM tblSach WHERE SoLuong > 0 ORDER BY TenSach");
                cboLapPhieuMuon.DataSource = sach;
                cboLapPhieuMuon.DisplayMember = "TenSach";
                cboLapPhieuMuon.ValueMember = "MaSach";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiDuLieu()
        {
            try
            {
                dgvPhieuMuon.DataSource = db.DocBang(@"
                    SELECT p.MaPM, p.MaSV, sv.TenSV, nv.TenNV, p.NgayMuon, p.HanTra,
                           CASE WHEN EXISTS (
                               SELECT 1 FROM tblChiTietMuon c
                               WHERE c.MaPM = p.MaPM AND c.NgayTra IS NULL
                           ) THEN N'Đang mượn' ELSE N'Đã trả' END AS TrangThai
                    FROM tblPhieuMuon p
                    INNER JOIN tblSinhVien sv ON sv.MaSV = p.MaSV
                    INNER JOIN tblNhanVien nv ON nv.MaNV = p.MaNV
                    ORDER BY p.NgayMuon DESC, p.MaPM DESC");

                dgvSachMuon.DataSource = db.DocBang(@"
                    SELECT MaPM, MaSV, TenSV, MaSach, TenSach, SoLuong, NgayMuon, HanTra
                    FROM v_DangMuon
                    ORDER BY HanTra, MaPM");

                TaiDanhSachTra();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu mượn trả: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiDanhSachTra()
        {
            DataTable dangMuon = db.DocBang(@"
                SELECT MaPM, MaSV, MaSach, TenSV, TenSach,
                       CONVERT(varchar(10), HanTra, 23) AS HanTra,
                       MaPM + N' - ' + TenSach AS HienThi
                FROM v_DangMuon
                ORDER BY HanTra, MaPM");

            cboXuLyTra.DataSource = dangMuon;
            cboXuLyTra.DisplayMember = "HienThi";
            cboXuLyTra.ValueMember = "MaPM";
        }

        private void BtnXacNhanMuon_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return;
            }

            if (cboLapPhieuMuon.SelectedValue is not string maSach || string.IsNullOrWhiteSpace(maSach))
            {
                MessageBox.Show("Vui lòng chọn sách cần mượn.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParse(txtNgayMuon.Text.Trim(), out DateTime ngayMuon))
            {
                MessageBox.Show("Ngày mượn phải có dạng yyyy-MM-dd.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayMuon.Focus();
                return;
            }

            if (ngayMuon.Date > DateTime.Today)
            {
                MessageBox.Show("Ngày mượn không được lớn hơn ngày hiện tại.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string maPM = db.SinhMa("tblPhieuMuon", "MaPM", "PM", 2);
                using SqlConnection conn = new(CauHinhKetNoi.TaoChuoiKetNoi());
                conn.Open();
                using SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    using (SqlCommand kiemTraSV = new(
                        "SELECT COUNT(*) FROM tblSinhVien WHERE MaSV=@MaSV", conn, transaction))
                    {
                        kiemTraSV.Parameters.Add(DataProcesser.Tham("@MaSV", txtMaSV.Text.Trim()));
                        if (Convert.ToInt32(kiemTraSV.ExecuteScalar()) == 0)
                            throw new InvalidOperationException("Mã sinh viên không tồn tại.");
                    }

                    using (SqlCommand themPhieu = new(@"
                        INSERT INTO tblPhieuMuon (MaPM, MaSV, MaNV, NgayMuon, HanTra)
                        VALUES (@MaPM, @MaSV, @MaNV, @NgayMuon, @HanTra)", conn, transaction))
                    {
                        themPhieu.Parameters.Add(DataProcesser.Tham("@MaPM", maPM));
                        themPhieu.Parameters.Add(DataProcesser.Tham("@MaSV", txtMaSV.Text.Trim()));
                        themPhieu.Parameters.Add(DataProcesser.Tham("@MaNV", TaiKhoanDangNhap.MaNV));
                        themPhieu.Parameters.Add(DataProcesser.Tham("@NgayMuon", ngayMuon.Date));
                        themPhieu.Parameters.Add(DataProcesser.Tham("@HanTra", ngayMuon.Date.AddDays(14)));
                        themPhieu.ExecuteNonQuery();
                    }

                    using (SqlCommand themChiTiet = new(@"
                        INSERT INTO tblChiTietMuon (MaPM, MaSach, SoLuong)
                        VALUES (@MaPM, @MaSach, 1)", conn, transaction))
                    {
                        themChiTiet.Parameters.Add(DataProcesser.Tham("@MaPM", maPM));
                        themChiTiet.Parameters.Add(DataProcesser.Tham("@MaSach", maSach));
                        themChiTiet.ExecuteNonQuery();
                    }

                    using (SqlCommand truSach = new(@"
                        UPDATE tblSach SET SoLuong = SoLuong - 1
                        WHERE MaSach=@MaSach AND SoLuong > 0", conn, transaction))
                    {
                        truSach.Parameters.Add(DataProcesser.Tham("@MaSach", maSach));
                        if (truSach.ExecuteNonQuery() != 1)
                            throw new InvalidOperationException("Sách đã hết hoặc không tồn tại.");
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

                MessageBox.Show("Lập phiếu mượn thành công. Hạn trả: " + ngayMuon.Date.AddDays(14).ToString("yyyy-MM-dd"),
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSV.Clear();
                TaiDanhSachSach();
                TaiDuLieu();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể lập phiếu mượn: " + ex.Message, "Lỗi CSDL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lập phiếu mượn thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXacNhanTra_Click(object? sender, EventArgs e)
        {
            if (cboXuLyTra.SelectedItem is not DataRowView row)
            {
                MessageBox.Show("Vui lòng chọn sách cần trả.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maPM = Convert.ToString(row["MaPM"]) ?? "";
            string maSach = Convert.ToString(row["MaSach"]) ?? "";
            if (MessageBox.Show($"Xác nhận trả sách {maSach} của phiếu {maPM}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using SqlConnection conn = new(CauHinhKetNoi.TaoChuoiKetNoi());
                conn.Open();
                using SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    int soDong;
                    using (SqlCommand traSach = new(@"
                        UPDATE tblChiTietMuon SET NgayTra=CONVERT(date, GETDATE())
                        WHERE MaPM=@MaPM AND MaSach=@MaSach AND NgayTra IS NULL", conn, transaction))
                    {
                        traSach.Parameters.Add(DataProcesser.Tham("@MaPM", maPM));
                        traSach.Parameters.Add(DataProcesser.Tham("@MaSach", maSach));
                        soDong = traSach.ExecuteNonQuery();
                    }

                    if (soDong != 1)
                        throw new InvalidOperationException("Sách này đã được trả trước đó.");

                    using (SqlCommand congSach = new(
                        "UPDATE tblSach SET SoLuong=SoLuong+1 WHERE MaSach=@MaSach", conn, transaction))
                    {
                        congSach.Parameters.Add(DataProcesser.Tham("@MaSach", maSach));
                        congSach.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

                MessageBox.Show("Đã xác nhận trả sách.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachSach();
                TaiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xử lý trả sách thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboXuLyTra_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboXuLyTra.SelectedItem is DataRowView row)
                txtMaSV.Text = Convert.ToString(row["MaSV"]) ?? "";
        }

        private void BtnInPhieu_Click(object? sender, EventArgs e)
        {
            if (dgvPhieuMuon.CurrentRow?.DataBoundItem is not DataRowView row)
            {
                MessageBox.Show("Vui lòng chọn một phiếu mượn để xem.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maPM = Convert.ToString(row["MaPM"]) ?? "";
            DataTable chiTiet = db.DocBang(
                "SELECT MaSach, TenSach, SoLuong FROM v_DangMuon WHERE MaPM=@MaPM",
                DataProcesser.Tham("@MaPM", maPM));
            string sach = chiTiet.Rows.Count == 0
                ? "Không còn sách đang mượn"
                : string.Join(", ", chiTiet.Rows.Cast<DataRow>().Select(r => Convert.ToString(r["TenSach"])));

            MessageBox.Show($"Phiếu: {maPM}\nSinh viên: {row["TenSV"]}\nNgày mượn: {row["NgayMuon"]:yyyy-MM-dd}\nHạn trả: {row["HanTra"]:yyyy-MM-dd}\nSách: {sach}",
                "Thông tin phiếu mượn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
