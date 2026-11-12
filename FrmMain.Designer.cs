namespace Hệ_Thống_Quản_Lý_Thư_Viện.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlMenu = new Panel();
            btnTrangChu = new Button();
            btnNhanVien = new Button();
            btnSinhVien = new Button();
            btnSach = new Button();
            btnTheLoai = new Button();
            btnMuonTra = new Button();
            btnThongKe = new Button();
            btnDangXuat = new Button();
            pnlContent = new Panel();
            lblWelcome = new Label();
            lblOverview = new Label();
            pnlStats = new Panel();
            cardTongSach = new Panel();
            lblTongSachTitle = new Label();
            lblTongSachValue = new Label();
            cardTongSinhVien = new Panel();
            lblTongSinhVienTitle = new Label();
            lblTongSinhVienValue = new Label();
            cardPhieuMuon = new Panel();
            lblPhieuMuonTitle = new Label();
            lblPhieuMuonValue = new Label();
            cardSachDangMuon = new Panel();
            lblSachDangMuonTitle = new Label();
            lblSachDangMuonValue = new Label();
            pnlHeader.SuspendLayout();
            pnlMenu.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlStats.SuspendLayout();
            cardTongSach.SuspendLayout();
            cardTongSinhVien.SuspendLayout();
            cardPhieuMuon.SuspendLayout();
            cardSachDangMuon.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(13, 71, 161);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 70);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(360, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ THƯ VIỆN";
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(66, 133, 244);
            pnlMenu.Controls.Add(btnTrangChu);
            pnlMenu.Controls.Add(btnNhanVien);
            pnlMenu.Controls.Add(btnSinhVien);
            pnlMenu.Controls.Add(btnSach);
            pnlMenu.Controls.Add(btnTheLoai);
            pnlMenu.Controls.Add(btnMuonTra);
            pnlMenu.Controls.Add(btnThongKe);
            pnlMenu.Controls.Add(btnDangXuat);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 70);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(220, 580);
            pnlMenu.TabIndex = 1;
            // 
            // btnTrangChu
            // 
            btnTrangChu.BackColor = Color.FromArgb(33, 150, 243);
            btnTrangChu.FlatAppearance.BorderSize = 0;
            btnTrangChu.FlatStyle = FlatStyle.Flat;
            btnTrangChu.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTrangChu.ForeColor = Color.White;
            btnTrangChu.Location = new Point(10, 10);
            btnTrangChu.Name = "btnTrangChu";
            btnTrangChu.Size = new Size(200, 45);
            btnTrangChu.TabIndex = 0;
            btnTrangChu.Text = "Trang chủ";
            btnTrangChu.UseVisualStyleBackColor = false;
            // 
            // btnNhanVien
            // 
            btnNhanVien.BackColor = Color.FromArgb(66, 133, 244);
            btnNhanVien.FlatAppearance.BorderSize = 0;
            btnNhanVien.FlatStyle = FlatStyle.Flat;
            btnNhanVien.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNhanVien.ForeColor = Color.White;
            btnNhanVien.Location = new Point(10, 65);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Size = new Size(200, 45);
            btnNhanVien.TabIndex = 1;
            btnNhanVien.Text = "Quản lý nhân viên";
            btnNhanVien.UseVisualStyleBackColor = false;
            // 
            // btnSinhVien
            // 
            btnSinhVien.BackColor = Color.FromArgb(66, 133, 244);
            btnSinhVien.FlatAppearance.BorderSize = 0;
            btnSinhVien.FlatStyle = FlatStyle.Flat;
            btnSinhVien.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSinhVien.ForeColor = Color.White;
            btnSinhVien.Location = new Point(10, 120);
            btnSinhVien.Name = "btnSinhVien";
            btnSinhVien.Size = new Size(200, 45);
            btnSinhVien.TabIndex = 2;
            btnSinhVien.Text = "Quản lý sinh viên";
            btnSinhVien.UseVisualStyleBackColor = false;
            // 
            // btnSach
            // 
            btnSach.BackColor = Color.FromArgb(66, 133, 244);
            btnSach.FlatAppearance.BorderSize = 0;
            btnSach.FlatStyle = FlatStyle.Flat;
            btnSach.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSach.ForeColor = Color.White;
            btnSach.Location = new Point(10, 175);
            btnSach.Name = "btnSach";
            btnSach.Size = new Size(200, 45);
            btnSach.TabIndex = 3;
            btnSach.Text = "Quản lý sách";
            btnSach.UseVisualStyleBackColor = false;
            // 
            // btnTheLoai
            // 
            btnTheLoai.BackColor = Color.FromArgb(66, 133, 244);
            btnTheLoai.FlatAppearance.BorderSize = 0;
            btnTheLoai.FlatStyle = FlatStyle.Flat;
            btnTheLoai.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTheLoai.ForeColor = Color.White;
            btnTheLoai.Location = new Point(10, 230);
            btnTheLoai.Name = "btnTheLoai";
            btnTheLoai.Size = new Size(200, 45);
            btnTheLoai.TabIndex = 4;
            btnTheLoai.Text = "Quản lý thể loại";
            btnTheLoai.UseVisualStyleBackColor = false;
            // 
            // btnMuonTra
            // 
            btnMuonTra.BackColor = Color.FromArgb(66, 133, 244);
            btnMuonTra.FlatAppearance.BorderSize = 0;
            btnMuonTra.FlatStyle = FlatStyle.Flat;
            btnMuonTra.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMuonTra.ForeColor = Color.White;
            btnMuonTra.Location = new Point(10, 285);
            btnMuonTra.Name = "btnMuonTra";
            btnMuonTra.Size = new Size(200, 45);
            btnMuonTra.TabIndex = 5;
            btnMuonTra.Text = "Quản lý mượn trả";
            btnMuonTra.UseVisualStyleBackColor = false;
            // 
            // btnThongKe
            // 
            btnThongKe.BackColor = Color.FromArgb(66, 133, 244);
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThongKe.ForeColor = Color.White;
            btnThongKe.Location = new Point(10, 340);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(200, 45);
            btnThongKe.TabIndex = 6;
            btnThongKe.Text = "Thống kê báo cáo";
            btnThongKe.UseVisualStyleBackColor = false;
            // 
            // btnDangXuat
            // 
            btnDangXuat.BackColor = Color.FromArgb(229, 57, 53);
            btnDangXuat.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDangXuat.ForeColor = Color.White;
            btnDangXuat.Location = new Point(10, 525);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(200, 45);
            btnDangXuat.TabIndex = 7;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = false;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Controls.Add(pnlStats);
            pnlContent.Controls.Add(lblOverview);
            pnlContent.Controls.Add(lblWelcome);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(220, 70);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(30);
            pnlContent.Size = new Size(880, 580);
            pnlContent.TabIndex = 2;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.FromArgb(13, 71, 161);
            lblWelcome.Location = new Point(30, 30);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(246, 32);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Xin chào, Quản Trị Viên!";
            // 
            // lblOverview
            // 
            lblOverview.AutoSize = true;
            lblOverview.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOverview.ForeColor = Color.FromArgb(100, 100, 100);
            lblOverview.Location = new Point(30, 70);
            lblOverview.Name = "lblOverview";
            lblOverview.Size = new Size(340, 21);
            lblOverview.TabIndex = 1;
            lblOverview.Text = "Dưới đây là thông tin tổng quan của hệ thống:";
            // 
            // pnlStats
            // 
            pnlStats.Controls.Add(cardSachDangMuon);
            pnlStats.Controls.Add(cardPhieuMuon);
            pnlStats.Controls.Add(cardTongSinhVien);
            pnlStats.Controls.Add(cardTongSach);
            pnlStats.Location = new Point(30, 110);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new Size(820, 430);
            pnlStats.TabIndex = 2;
            // 
            // cardTongSach
            // 
            cardTongSach.BackColor = Color.FromArgb(33, 150, 243);
            cardTongSach.Controls.Add(lblTongSachValue);
            cardTongSach.Controls.Add(lblTongSachTitle);
            cardTongSach.Location = new Point(0, 0);
            cardTongSach.Name = "cardTongSach";
            cardTongSach.Size = new Size(190, 150);
            cardTongSach.TabIndex = 0;
            // 
            // lblTongSachTitle
            // 
            lblTongSachTitle.AutoSize = true;
            lblTongSachTitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongSachTitle.ForeColor = Color.White;
            lblTongSachTitle.Location = new Point(15, 15);
            lblTongSachTitle.Name = "lblTongSachTitle";
            lblTongSachTitle.Size = new Size(91, 20);
            lblTongSachTitle.TabIndex = 0;
            lblTongSachTitle.Text = "Tổng số sách";
            // 
            // lblTongSachValue
            // 
            lblTongSachValue.AutoSize = true;
            lblTongSachValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongSachValue.ForeColor = Color.White;
            lblTongSachValue.Location = new Point(15, 50);
            lblTongSachValue.Name = "lblTongSachValue";
            lblTongSachValue.Size = new Size(75, 59);
            lblTongSachValue.TabIndex = 1;
            lblTongSachValue.Text = "250";
            // 
            // cardTongSinhVien
            // 
            cardTongSinhVien.BackColor = Color.FromArgb(76, 175, 80);
            cardTongSinhVien.Controls.Add(lblTongSinhVienValue);
            cardTongSinhVien.Controls.Add(lblTongSinhVienTitle);
            cardTongSinhVien.Location = new Point(210, 0);
            cardTongSinhVien.Name = "cardTongSinhVien";
            cardTongSinhVien.Size = new Size(190, 150);
            cardTongSinhVien.TabIndex = 1;
            // 
            // lblTongSinhVienTitle
            // 
            lblTongSinhVienTitle.AutoSize = true;
            lblTongSinhVienTitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongSinhVienTitle.ForeColor = Color.White;
            lblTongSinhVienTitle.Location = new Point(15, 15);
            lblTongSinhVienTitle.Name = "lblTongSinhVienTitle";
            lblTongSinhVienTitle.Size = new Size(113, 20);
            lblTongSinhVienTitle.TabIndex = 0;
            lblTongSinhVienTitle.Text = "Tổng số sinh viên";
            // 
            // lblTongSinhVienValue
            // 
            lblTongSinhVienValue.AutoSize = true;
            lblTongSinhVienValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongSinhVienValue.ForeColor = Color.White;
            lblTongSinhVienValue.Location = new Point(15, 50);
            lblTongSinhVienValue.Name = "lblTongSinhVienValue";
            lblTongSinhVienValue.Size = new Size(75, 59);
            lblTongSinhVienValue.TabIndex = 1;
            lblTongSinhVienValue.Text = "450";
            // 
            // cardPhieuMuon
            // 
            cardPhieuMuon.BackColor = Color.FromArgb(255, 152, 0);
            cardPhieuMuon.Controls.Add(lblPhieuMuonValue);
            cardPhieuMuon.Controls.Add(lblPhieuMuonTitle);
            cardPhieuMuon.Location = new Point(420, 0);
            cardPhieuMuon.Name = "cardPhieuMuon";
            cardPhieuMuon.Size = new Size(190, 150);
            cardPhieuMuon.TabIndex = 2;
            // 
            // lblPhieuMuonTitle
            // 
            lblPhieuMuonTitle.AutoSize = true;
            lblPhieuMuonTitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPhieuMuonTitle.ForeColor = Color.White;
            lblPhieuMuonTitle.Location = new Point(15, 15);
            lblPhieuMuonTitle.Name = "lblPhieuMuonTitle";
            lblPhieuMuonTitle.Size = new Size(92, 20);
            lblPhieuMuonTitle.TabIndex = 0;
            lblPhieuMuonTitle.Text = "Số phiếu mượn";
            // 
            // lblPhieuMuonValue
            // 
            lblPhieuMuonValue.AutoSize = true;
            lblPhieuMuonValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhieuMuonValue.ForeColor = Color.White;
            lblPhieuMuonValue.Location = new Point(15, 50);
            lblPhieuMuonValue.Name = "lblPhieuMuonValue";
            lblPhieuMuonValue.Size = new Size(75, 59);
            lblPhieuMuonValue.TabIndex = 1;
            lblPhieuMuonValue.Text = "180";
            // 
            // cardSachDangMuon
            // 
            cardSachDangMuon.BackColor = Color.FromArgb(233, 30, 99);
            cardSachDangMuon.Controls.Add(lblSachDangMuonValue);
            cardSachDangMuon.Controls.Add(lblSachDangMuonTitle);
            cardSachDangMuon.Location = new Point(630, 0);
            cardSachDangMuon.Name = "cardSachDangMuon";
            cardSachDangMuon.Size = new Size(190, 150);
            cardSachDangMuon.TabIndex = 3;
            // 
            // lblSachDangMuonTitle
            // 
            lblSachDangMuonTitle.AutoSize = true;
            lblSachDangMuonTitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSachDangMuonTitle.ForeColor = Color.White;
            lblSachDangMuonTitle.Location = new Point(15, 15);
            lblSachDangMuonTitle.Name = "lblSachDangMuonTitle";
            lblSachDangMuonTitle.Size = new Size(139, 20);
            lblSachDangMuonTitle.TabIndex = 0;
            lblSachDangMuonTitle.Text = "Sách đang được mượn";
            // 
            // lblSachDangMuonValue
            // 
            lblSachDangMuonValue.AutoSize = true;
            lblSachDangMuonValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSachDangMuonValue.ForeColor = Color.White;
            lblSachDangMuonValue.Location = new Point(15, 50);
            lblSachDangMuonValue.Name = "lblSachDangMuonValue";
            lblSachDangMuonValue.Size = new Size(75, 59);
            lblSachDangMuonValue.TabIndex = 1;
            lblSachDangMuonValue.Text = "145";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 650);
            Controls.Add(pnlContent);
            Controls.Add(pnlMenu);
            Controls.Add(pnlHeader);
            Name = "FrmMain";
            Text = "Quản lý Thư viện";
            Load += FrmMain_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMenu.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            pnlStats.ResumeLayout(false);
            cardTongSach.ResumeLayout(false);
            cardTongSach.PerformLayout();
            cardTongSinhVien.ResumeLayout(false);
            cardTongSinhVien.PerformLayout();
            cardPhieuMuon.ResumeLayout(false);
            cardPhieuMuon.PerformLayout();
            cardSachDangMuon.ResumeLayout(false);
            cardSachDangMuon.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlMenu;
        private Button btnTrangChu;
        private Button btnNhanVien;
        private Button btnSinhVien;
        private Button btnSach;
        private Button btnTheLoai;
        private Button btnMuonTra;
        private Button btnThongKe;
        private Button btnDangXuat;
        private Panel pnlContent;
        private Label lblWelcome;
        private Label lblOverview;
        private Panel pnlStats;
        private Panel cardTongSach;
        private Label lblTongSachTitle;
        private Label lblTongSachValue;
        private Panel cardTongSinhVien;
        private Label lblTongSinhVienTitle;
        private Label lblTongSinhVienValue;
        private Panel cardPhieuMuon;
        private Label lblPhieuMuonTitle;
        private Label lblPhieuMuonValue;
        private Panel cardSachDangMuon;
        private Label lblSachDangMuonTitle;
        private Label lblSachDangMuonValue;
    }
}
