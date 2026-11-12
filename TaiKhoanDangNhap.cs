namespace Hệ_Thống_Quản_Lý_Thư_Viện.Classes
{
    /// <summary>Các chức năng của hệ thống (dùng để kiểm tra phân quyền).</summary>
    internal enum ChucNang
    {
        TrangChu,
        NhanVien,
        SinhVien,
        Sach,
        TheLoai,
        MuonTra,
        ThongKe
    }

    internal static class TaiKhoanDangNhap
    {
        // Giá trị cột tblTaiKhoan.Quyen trong script SQL của TV2: 'Admin' / 'NhanVien'
        public const string QuyenAdmin = "Admin";
        public const string QuyenNhanVien = "NhanVien";

        public static string TenDangNhap { get; set; } = "";
        public static string TenNhanVien { get; set; } = "";
        public static string MaNV { get; set; } = "";
        public static string Quyen { get; set; } = "";

        public static bool LaAdmin =>
            string.Equals(Quyen?.Trim(), QuyenAdmin, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// CHÍNH SÁCH PHÂN QUYỀN (sửa tại đây nếu nhóm đổi chính sách):
        ///  - Admin: dùng được tất cả chức năng.
        ///  - Nhân viên: KHÔNG dùng Quản lý nhân viên và Thống kê báo cáo.
        /// Tài khoản chưa đăng nhập / quyền lạ: không có quyền nào.
        /// </summary>
        public static bool CoQuyen(ChucNang chucNang)
        {
            if (string.IsNullOrWhiteSpace(TenDangNhap)) return false;
            if (LaAdmin) return true;

            if (!string.Equals(Quyen?.Trim(), QuyenNhanVien, StringComparison.OrdinalIgnoreCase))
                return false;

            return chucNang != ChucNang.NhanVien && chucNang != ChucNang.ThongKe;
        }

        public static void DangXuat()
        {
            TenDangNhap = "";
            TenNhanVien = "";
            MaNV = "";
            Quyen = "";
        }
    }
}
