using Hệ_Thống_Quản_Lý_Thư_Viện.Forms;

namespace Hệ_Thống_Quản_Lý_Thư_Viện
{
    internal static class Program
    {
        /// <summary>
        ///  Điểm khởi động. Vòng đời Form:
        ///  Đăng nhập (hộp thoại) -> FrmMain -> (Đăng xuất) -> quay lại Đăng nhập ...
        ///  Chỉ có đúng 1 FrmDangNhap và 1 FrmMain tồn tại tại mỗi thời điểm.
        ///  Ứng dụng kết thúc khi: bấm Thoát/đóng form đăng nhập, hoặc đóng FrmMain mà không chọn Đăng xuất.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            while (true)
            {
                using (var dangNhap = new FrmDangNhap())
                {
                    if (dangNhap.ShowDialog() != DialogResult.OK)
                        break; // Thoát / đóng cửa sổ đăng nhập -> kết thúc ứng dụng
                }

                bool dangXuat;
                using (var main = new FrmMain())
                {
                    Application.Run(main); // chạy tới khi FrmMain đóng
                    dangXuat = main.DangXuat;
                }

                if (!dangXuat)
                    break; // đóng FrmMain bằng nút X -> kết thúc ứng dụng
            }
        }
    }
}
