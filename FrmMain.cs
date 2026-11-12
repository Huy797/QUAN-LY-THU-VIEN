using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Hệ_Thống_Quản_Lý_Thư_Viện.Classes;

namespace Hệ_Thống_Quản_Lý_Thư_Viện.Forms
{
    /// <summary>
    /// Form chính: menu điều hướng + vùng nội dung (pnlContent).
    /// Quy ước cho các thành viên: mỗi chức năng là 1 Form con riêng (FrmXxx),
    /// FrmMain tạo form con và nhúng vào pnlContent qua MoChucNang(...).
    /// </summary>
    public partial class FrmMain : Form
    {
        private static readonly Color MauNut = Color.FromArgb(66, 133, 244);
        private static readonly Color MauNutDangChon = Color.FromArgb(33, 150, 243);

        // Form con đang hiển thị trong pnlContent (luôn tối đa 1 form)
        private Form? _formCon;

        /// <summary>true nếu FrmMain đóng do người dùng bấm "Đăng xuất" (Program.Main dựa vào đây để quay lại đăng nhập).</summary>
        public bool DangXuat { get; private set; }

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object? sender, EventArgs e)
        {
            lblWelcome.Text = $"Xin chào, {TaiKhoanDangNhap.TenNhanVien}! (Quyền: {TaiKhoanDangNhap.Quyen})";

            btnTrangChu.Click += BtnTrangChu_Click;
            btnNhanVien.Click += BtnNhanVien_Click;
            btnSinhVien.Click += BtnSinhVien_Click;
            btnSach.Click += BtnSach_Click;
            btnTheLoai.Click += BtnTheLoai_Click;
            btnMuonTra.Click += BtnMuonTra_Click;
            btnThongKe.Click += BtnThongKe_Click;
            btnDangXuat.Click += BtnDangXuat_Click;

            ApDungPhanQuyen();
            LoadTrangChu();
        }

        // ===================== PHÂN QUYỀN =====================

        /// <summary>Ẩn các nút không có quyền và xếp lại menu cho liền mạch.
        /// (Việc kiểm tra quyền thật sự nằm ở MoChucNang, không chỉ dựa vào ẩn nút.)</summary>
        private void ApDungPhanQuyen()
        {
            var nut = new (ChucNang cn, Button btn)[]
            {
                (ChucNang.TrangChu, btnTrangChu),
                (ChucNang.NhanVien, btnNhanVien),
                (ChucNang.SinhVien, btnSinhVien),
                (ChucNang.Sach, btnSach),
                (ChucNang.TheLoai, btnTheLoai),
                (ChucNang.MuonTra, btnMuonTra),
                (ChucNang.ThongKe, btnThongKe),
            };

            int y = btnTrangChu.Top;
            foreach (var (cn, btn) in nut)
            {
                btn.Visible = TaiKhoanDangNhap.CoQuyen(cn);
                if (btn.Visible)
                {
                    btn.Top = y;
                    y += 55;
                }
            }
        }

        // ===================== ĐIỀU HƯỚNG =====================

        private void DongFormCon()
        {
            // Lấy danh sách ra trước (ToList) rồi mới dispose -> không bị lỗi "Collection was modified"
            foreach (Form f in pnlContent.Controls.OfType<Form>().ToList())
            {
                pnlContent.Controls.Remove(f);
                f.Dispose();
            }
            _formCon = null;
        }

        private void OpenFormInPanel(Form frm)
        {
            DongFormCon();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(frm);
            _formCon = frm;
            frm.BringToFront();
            frm.Show();
        }

        private void HienKhuVucTrangChu(bool hien)
        {
            pnlStats.Visible = hien;
            lblWelcome.Visible = hien;
            lblOverview.Visible = hien;
        }

        private void DanhDauNut(Button? nutDangChon)
        {
            foreach (Button b in new[] { btnTrangChu, btnNhanVien, btnSinhVien, btnSach, btnTheLoai, btnMuonTra, btnThongKe })
                b.BackColor = MauNut;
            if (nutDangChon != null)
                nutDangChon.BackColor = MauNutDangChon;
        }

        /// <summary>Mở 1 chức năng: kiểm tra quyền -> tạo form con -> nhúng vào pnlContent.</summary>
        private void MoChucNang(ChucNang chucNang, Button nut, Func<Form> taoForm)
        {
            if (!TaiKhoanDangNhap.CoQuyen(chucNang))
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng này.", "Không đủ quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Form frm = taoForm();      // tạo trước: nếu lỗi thì giữ nguyên màn hình hiện tại
                HienKhuVucTrangChu(false);
                OpenFormInPanel(frm);
                DanhDauNut(nut);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở chức năng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTrangChu()
        {
            DongFormCon();
            HienKhuVucTrangChu(true);
            DanhDauNut(btnTrangChu);
            TaiThongKeTrangChu();
        }

        /// <summary>
        /// Số liệu trên 4 thẻ trang chủ lấy từ CSDL (truy vấn đối chiếu script SQL của TV2).
        /// TẠM THỜI: TV4 có thể thay bằng logic nghiệp vụ chính thức.
        /// </summary>
        private void TaiThongKeTrangChu()
        {
            try
            {
                var db = new DataProcesser();
                lblTongSachValue.Text = Convert.ToString(db.LayGiaTri("SELECT COUNT(*) FROM tblSach")) ?? "-";
                lblTongSinhVienValue.Text = Convert.ToString(db.LayGiaTri("SELECT COUNT(*) FROM tblSinhVien")) ?? "-";
                lblPhieuMuonValue.Text = Convert.ToString(db.LayGiaTri("SELECT COUNT(*) FROM tblPhieuMuon")) ?? "-";
                lblSachDangMuonValue.Text = Convert.ToString(db.LayGiaTri("SELECT ISNULL(SUM(SoLuong), 0) FROM v_DangMuon")) ?? "-";
            }
            catch (Exception)
            {
                lblTongSachValue.Text = lblTongSinhVienValue.Text =
                    lblPhieuMuonValue.Text = lblSachDangMuonValue.Text = "-";
            }
        }

        private void BtnTrangChu_Click(object? sender, EventArgs e) => LoadTrangChu();

        private void BtnNhanVien_Click(object? sender, EventArgs e) =>
            MoChucNang(ChucNang.NhanVien, btnNhanVien, () => new FrmNhanVien());

        private void BtnSinhVien_Click(object? sender, EventArgs e) =>
            MoChucNang(ChucNang.SinhVien, btnSinhVien, () => new FrmSinhVien());

        private void BtnSach_Click(object? sender, EventArgs e) =>
            MoChucNang(ChucNang.Sach, btnSach, () => new FrmSach());

        private void BtnTheLoai_Click(object? sender, EventArgs e) =>
            MoChucNang(ChucNang.TheLoai, btnTheLoai, () => new FrmTheLoai());

        private void BtnMuonTra_Click(object? sender, EventArgs e) =>
            MoChucNang(ChucNang.MuonTra, btnMuonTra, () => new FrmMuonTra());

        private void BtnThongKe_Click(object? sender, EventArgs e) =>
            MoChucNang(ChucNang.ThongKe, btnThongKe, () => new FrmThongKe());

        // ===================== ĐĂNG XUẤT =====================

        private void BtnDangXuat_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                TaiKhoanDangNhap.DangXuat();
                DangXuat = true;
                Close(); // Program.Main sẽ mở lại FrmDangNhap (không tạo form thừa ở đây)
            }
        }
    }
}
