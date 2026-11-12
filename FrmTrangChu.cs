using System;
using System.Windows.Forms;

namespace Hệ_Thống_Quản_Lý_Thư_Viện.Forms
{
    /// <summary>
    /// GIỮ CHỖ cho TV4. Hiện KHÔNG được FrmMain mở: trang chủ (lời chào + 4 thẻ thống kê)
    /// đang nằm ngay trong FrmMain (pnlStats) và đã đọc số liệu từ CSDL (FrmMain.TaiThongKeTrangChu).
    /// Nếu nhóm muốn tách trang chủ thành form riêng, TV4/Leader chuyển nội dung sang đây và gọi
    /// MoChucNang(ChucNang.TrangChu, btnTrangChu, () => new FrmTrangChu()) trong FrmMain.
    /// Không xóa form này để tránh gãy các tham chiếu của các thành viên khác.
    /// </summary>
    public partial class FrmTrangChu : Form
    {
        public FrmTrangChu()
        {
            InitializeComponent();
        }

        private void FrmTrangChu_Load(object sender, EventArgs e)
        {
            // TODO: Thành viên 4 sẽ điền logic trang chủ tại đây
        }
    }
}
