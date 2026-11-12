namespace Hệ_Thống_Quản_Lý_Thư_Viện.Forms
{
    partial class FrmDangNhap
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
            lblTieuDe = new Label();
            lblTaiKhoan = new Label();
            lblMatKhau = new Label();
            txtTaiKhoan = new TextBox();
            txtMatKhau = new TextBox();
            btnDangNhap = new Button();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.Location = new Point(-2, -1);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(800, 93);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "\t                                 QUẢN LÝ THƯ VIỆN";
            // 
            // lblTaiKhoan
            // 
            lblTaiKhoan.AutoSize = true;
            lblTaiKhoan.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaiKhoan.Location = new Point(37, 130);
            lblTaiKhoan.Name = "lblTaiKhoan";
            lblTaiKhoan.Size = new Size(107, 20);
            lblTaiKhoan.TabIndex = 1;
            lblTaiKhoan.Text = "Tên đăng nhập";
            // 
            // lblMatKhau
            // 
            lblMatKhau.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMatKhau.Location = new Point(37, 203);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(100, 23);
            lblMatKhau.TabIndex = 2;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // txtTaiKhoan
            // 
            txtTaiKhoan.Location = new Point(161, 130);
            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.Size = new Size(274, 23);
            txtTaiKhoan.TabIndex = 3;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(161, 203);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(274, 23);
            txtMatKhau.TabIndex = 4;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangNhap.Location = new Point(152, 343);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(125, 23);
            btnDangNhap.TabIndex = 5;
            btnDangNhap.Text = "ĐĂNG NHẬP";
            btnDangNhap.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(488, 343);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(75, 23);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "THOÁT";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // FrmDangNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnThoat);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTaiKhoan);
            Controls.Add(lblMatKhau);
            Controls.Add(lblTaiKhoan);
            Controls.Add(lblTieuDe);
            ForeColor = SystemColors.MenuText;
            Location = new Point(80, 40);
            Name = "FrmDangNhap";
            Text = "FrmDangNhap";
            Load += FrmDangNhap_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblTaiKhoan;
        private Label lblMatKhau;
        private TextBox txtTaiKhoan;
        private TextBox txtMatKhau;
        private Button btnDangNhap;
        private Button btnThoat;
    }
}