using Hệ_Thống_Quản_Lý_Thư_Viện.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hệ_Thống_Quản_Lý_Thư_Viện.Forms
{
    /// <summary>
    /// Form đăng nhập. Được mở bằng ShowDialog() từ Program.Main:
    /// DialogResult.OK = đăng nhập thành công, Cancel = thoát.
    /// </summary>
    public partial class FrmDangNhap : Form
    {
        DataProcesser db = new DataProcesser();

        public FrmDangNhap()
        {
            InitializeComponent();

            txtMatKhau.PasswordChar = '*';
            StartPosition = FormStartPosition.CenterScreen;

            // Nhấn Enter = Đăng nhập, nhấn Esc = Thoát
            AcceptButton = btnDangNhap;
            CancelButton = btnThoat;

            btnDangNhap.Click += btnDangNhap_Click;
            btnThoat.Click += btnThoat_Click;
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '*';
            txtTaiKhoan.Focus();

            if (CauHinhKetNoi.LoiCauHinh != "")
                MessageBox.Show(CauHinhKetNoi.LoiCauHinh, "Lỗi file cấu hình",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDangNhap_Click(object? sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (taiKhoan == "" || matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Đăng nhập",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Đối chiếu với script SQL của TV2: tblTaiKhoan(TenDangNhap, MatKhau, MaNV, Quyen) JOIN tblNhanVien(MaNV, TenNV)
                DataTable dt = db.DocBang(
                    @"SELECT tk.TenDangNhap, tk.MaNV, tk.Quyen, nv.TenNV
                      FROM tblTaiKhoan tk
                      INNER JOIN tblNhanVien nv ON tk.MaNV = nv.MaNV
                      WHERE tk.TenDangNhap = @tk
                      AND tk.MatKhau = @mk",
                    DataProcesser.Tham("@tk", taiKhoan),
                    DataProcesser.Tham("@mk", matKhau)
                );

                if (dt.Rows.Count > 0)
                {
                    TaiKhoanDangNhap.TenDangNhap = dt.Rows[0]["TenDangNhap"].ToString() ?? "";
                    TaiKhoanDangNhap.MaNV = dt.Rows[0]["MaNV"].ToString() ?? "";
                    TaiKhoanDangNhap.Quyen = dt.Rows[0]["Quyen"].ToString() ?? "";
                    TaiKhoanDangNhap.TenNhanVien = dt.Rows[0]["TenNV"].ToString() ?? "";

                    DialogResult = DialogResult.OK; // đóng hộp thoại, Program.Main sẽ mở FrmMain
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Đăng nhập",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                }
            }
            catch (SqlException ex)
            {
                // Không in chuỗi kết nối / mật khẩu ra thông báo.
                MessageBox.Show(
                    "Không kết nối được SQL Server.\n\n" +
                    "Server: " + CauHinhKetNoi.Server + "\n" +
                    "CSDL: " + CauHinhKetNoi.Database + "\n" +
                    "File cấu hình đang dùng: " + CauHinhKetNoi.FileDaNap + "\n\n" +
                    "Hãy kiểm tra SQL Server đã chạy, đã chạy script tạo CSDL, và tên server trong appsettings.local.json.\n\n" +
                    "Chi tiết: " + ex.Message,
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định khi đăng nhập: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
