namespace Hệ_Thống_Quản_Lý_Thư_Viện.Forms
{
    partial class FrmMuonTra
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            grpLapPhieu = new GroupBox();
            lblMaSV = new Label();
            txtMaSV = new TextBox();
            lblNgayMuon = new Label();
            txtNgayMuon = new TextBox();
            btnXacNhanMuon = new Button();
            grpXuLyTra = new GroupBox();
            lblLapPhieuMuon = new Label();
            cboLapPhieuMuon = new ComboBox();
            lblXuLyTra = new Label();
            cboXuLyTra = new ComboBox();
            btnXacNhanTra = new Button();
            btnInPhieu = new Button();
            lblDanhSachPhieuMuon = new Label();
            dgvPhieuMuon = new DataGridView();
            lblDanhSachSachMuon = new Label();
            dgvSachMuon = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuMuon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSachMuon).BeginInit();
            grpLapPhieu.SuspendLayout();
            grpXuLyTra.SuspendLayout();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.Dock = DockStyle.Top;
            lblTieuDe.BackColor = Color.FromArgb(0, 153, 150);
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.Size = new Size(880, 47);
            lblTieuDe.Text = "Quản Lý Mượn Trả";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.TabIndex = 0;
            // 
            // grpLapPhieu
            // 
            grpLapPhieu.Location = new Point(20, 60);
            grpLapPhieu.Size = new Size(335, 195);
            grpLapPhieu.Text = "Lập Phiếu Mượn";
            grpLapPhieu.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            grpLapPhieu.TabStop = false;
            grpLapPhieu.Name = "grpLapPhieu";
            grpLapPhieu.TabIndex = 1;
            // 
            // lblMaSV
            // 
            lblMaSV.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaSV.Location = new Point(0, 32);
            lblMaSV.Size = new Size(130, 28);
            lblMaSV.Text = "Mã Sinh Viên";
            lblMaSV.TextAlign = ContentAlignment.MiddleRight;
            lblMaSV.Name = "lblMaSV";
            lblMaSV.TabIndex = 0;
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(135, 32);
            txtMaSV.Size = new Size(178, 23);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.TabIndex = 1;
            // 
            // lblNgayMuon
            // 
            lblNgayMuon.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNgayMuon.Location = new Point(0, 85);
            lblNgayMuon.Size = new Size(130, 28);
            lblNgayMuon.Text = "Ngày Mượn";
            lblNgayMuon.TextAlign = ContentAlignment.MiddleRight;
            lblNgayMuon.Name = "lblNgayMuon";
            lblNgayMuon.TabIndex = 2;
            // 
            // txtNgayMuon
            // 
            txtNgayMuon.Location = new Point(135, 85);
            txtNgayMuon.Size = new Size(178, 23);
            txtNgayMuon.Name = "txtNgayMuon";
            txtNgayMuon.TabIndex = 3;
            // 
            // btnXacNhanMuon
            // 
            btnXacNhanMuon.BackColor = Color.White;
            btnXacNhanMuon.FlatStyle = FlatStyle.Flat;
            btnXacNhanMuon.ForeColor = Color.FromArgb(133, 178, 174);
            btnXacNhanMuon.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXacNhanMuon.Location = new Point(17, 128);
            btnXacNhanMuon.Size = new Size(140, 46);
            btnXacNhanMuon.Text = "Xác nhận mượn";
            btnXacNhanMuon.UseVisualStyleBackColor = false;
            btnXacNhanMuon.Name = "btnXacNhanMuon";
            btnXacNhanMuon.TabIndex = 4;
            // 
            // grpXuLyTra
            // 
            grpXuLyTra.Location = new Point(20, 270);
            grpXuLyTra.Size = new Size(335, 260);
            grpXuLyTra.Text = "Xử Lý Trả";
            grpXuLyTra.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpXuLyTra.TabStop = false;
            grpXuLyTra.Name = "grpXuLyTra";
            grpXuLyTra.TabIndex = 2;
            // 
            // lblLapPhieuMuon
            // 
            lblLapPhieuMuon.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLapPhieuMuon.Location = new Point(0, 32);
            lblLapPhieuMuon.Size = new Size(130, 28);
            lblLapPhieuMuon.Text = "Lập Phiếu Mượn";
            lblLapPhieuMuon.TextAlign = ContentAlignment.MiddleRight;
            lblLapPhieuMuon.Name = "lblLapPhieuMuon";
            lblLapPhieuMuon.TabIndex = 0;
            // 
            // cboLapPhieuMuon
            // 
            cboLapPhieuMuon.Location = new Point(135, 32);
            cboLapPhieuMuon.Size = new Size(178, 23);
            cboLapPhieuMuon.Name = "cboLapPhieuMuon";
            cboLapPhieuMuon.TabIndex = 1;
            // 
            // lblXuLyTra
            // 
            lblXuLyTra.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblXuLyTra.Location = new Point(0, 85);
            lblXuLyTra.Size = new Size(130, 28);
            lblXuLyTra.Text = "Xử Lý Trả";
            lblXuLyTra.TextAlign = ContentAlignment.MiddleRight;
            lblXuLyTra.Name = "lblXuLyTra";
            lblXuLyTra.TabIndex = 2;
            // 
            // cboXuLyTra
            // 
            cboXuLyTra.Location = new Point(135, 85);
            cboXuLyTra.Size = new Size(178, 23);
            cboXuLyTra.Name = "cboXuLyTra";
            cboXuLyTra.TabIndex = 3;
            // 
            // btnXacNhanTra
            // 
            btnXacNhanTra.BackColor = Color.White;
            btnXacNhanTra.FlatStyle = FlatStyle.Flat;
            btnXacNhanTra.ForeColor = Color.FromArgb(133, 178, 174);
            btnXacNhanTra.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXacNhanTra.Location = new Point(17, 128);
            btnXacNhanTra.Size = new Size(140, 46);
            btnXacNhanTra.Text = "Xác nhận trả";
            btnXacNhanTra.UseVisualStyleBackColor = false;
            btnXacNhanTra.Name = "btnXacNhanTra";
            btnXacNhanTra.TabIndex = 4;
            // 
            // btnInPhieu
            // 
            btnInPhieu.BackColor = Color.White;
            btnInPhieu.FlatStyle = FlatStyle.Flat;
            btnInPhieu.ForeColor = Color.FromArgb(133, 178, 174);
            btnInPhieu.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInPhieu.Location = new Point(172, 128);
            btnInPhieu.Size = new Size(140, 46);
            btnInPhieu.Text = "In phiếu";
            btnInPhieu.UseVisualStyleBackColor = false;
            btnInPhieu.Name = "btnInPhieu";
            btnInPhieu.TabIndex = 5;
            // 
            // lblDanhSachPhieuMuon
            // 
            lblDanhSachPhieuMuon.AutoSize = true;
            lblDanhSachPhieuMuon.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDanhSachPhieuMuon.Location = new Point(370, 62);
            lblDanhSachPhieuMuon.Text = "Danh sách phiếu mượn trả";
            lblDanhSachPhieuMuon.Name = "lblDanhSachPhieuMuon";
            lblDanhSachPhieuMuon.TabIndex = 3;
            // 
            // dgvPhieuMuon
            // 
            dgvPhieuMuon.AllowUserToAddRows = false;
            dgvPhieuMuon.AllowUserToDeleteRows = false;
            dgvPhieuMuon.ReadOnly = true;
            dgvPhieuMuon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvPhieuMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuMuon.BackgroundColor = Color.DarkGray;
            dgvPhieuMuon.ColumnHeadersHeight = 28;
            dgvPhieuMuon.EnableHeadersVisualStyles = false;
            dgvPhieuMuon.Location = new Point(370, 90);
            dgvPhieuMuon.RowHeadersVisible = false;
            dgvPhieuMuon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhieuMuon.Size = new Size(490, 185);
            dgvPhieuMuon.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(211, 231, 242);
            dgvPhieuMuon.Name = "dgvPhieuMuon";
            dgvPhieuMuon.TabIndex = 4;
            // 
            // lblDanhSachSachMuon
            // 
            lblDanhSachSachMuon.AutoSize = true;
            lblDanhSachSachMuon.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDanhSachSachMuon.Location = new Point(370, 290);
            lblDanhSachSachMuon.Text = "Danh sách sách mượn";
            lblDanhSachSachMuon.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblDanhSachSachMuon.Name = "lblDanhSachSachMuon";
            lblDanhSachSachMuon.TabIndex = 5;
            // 
            // dgvSachMuon
            // 
            dgvSachMuon.AllowUserToAddRows = false;
            dgvSachMuon.AllowUserToDeleteRows = false;
            dgvSachMuon.ReadOnly = true;
            dgvSachMuon.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSachMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSachMuon.BackgroundColor = Color.DarkGray;
            dgvSachMuon.ColumnHeadersHeight = 28;
            dgvSachMuon.EnableHeadersVisualStyles = false;
            dgvSachMuon.Location = new Point(370, 318);
            dgvSachMuon.RowHeadersVisible = false;
            dgvSachMuon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSachMuon.Size = new Size(490, 212);
            dgvSachMuon.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(211, 231, 242);
            dgvSachMuon.Name = "dgvSachMuon";
            dgvSachMuon.TabIndex = 6;
            grpLapPhieu.Controls.Add(lblMaSV);
            grpLapPhieu.Controls.Add(txtMaSV);
            grpLapPhieu.Controls.Add(lblNgayMuon);
            grpLapPhieu.Controls.Add(txtNgayMuon);
            grpLapPhieu.Controls.Add(btnXacNhanMuon);
            grpXuLyTra.Controls.Add(lblLapPhieuMuon);
            grpXuLyTra.Controls.Add(cboLapPhieuMuon);
            grpXuLyTra.Controls.Add(lblXuLyTra);
            grpXuLyTra.Controls.Add(cboXuLyTra);
            grpXuLyTra.Controls.Add(btnXacNhanTra);
            grpXuLyTra.Controls.Add(btnInPhieu);
            // 
            // FrmMuonTra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(880, 580);
            Controls.Add(dgvSachMuon);
            Controls.Add(lblDanhSachSachMuon);
            Controls.Add(dgvPhieuMuon);
            Controls.Add(lblDanhSachPhieuMuon);
            Controls.Add(grpXuLyTra);
            Controls.Add(grpLapPhieu);
            Controls.Add(lblTieuDe);
            Name = "FrmMuonTra";
            Text = "Quản lý mượn trả";
            Load += FrmMuonTra_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPhieuMuon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSachMuon).EndInit();
            grpLapPhieu.ResumeLayout(false);
            grpLapPhieu.PerformLayout();
            grpXuLyTra.ResumeLayout(false);
            grpXuLyTra.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDe;
        private GroupBox grpLapPhieu;
        private Label lblMaSV;
        private TextBox txtMaSV;
        private Label lblNgayMuon;
        private TextBox txtNgayMuon;
        private Button btnXacNhanMuon;
        private GroupBox grpXuLyTra;
        private Label lblLapPhieuMuon;
        private ComboBox cboLapPhieuMuon;
        private Label lblXuLyTra;
        private ComboBox cboXuLyTra;
        private Button btnXacNhanTra;
        private Button btnInPhieu;
        private Label lblDanhSachPhieuMuon;
        private DataGridView dgvPhieuMuon;
        private Label lblDanhSachSachMuon;
        private DataGridView dgvSachMuon;
    }
}
