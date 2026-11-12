namespace Hệ_Thống_Quản_Lý_Thư_Viện.Forms
{
    partial class FrmTheLoai
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
            grpTimTheLoai = new GroupBox();
            radTimMa = new RadioButton();
            radTimTen = new RadioButton();
            txtTimKiem = new TextBox();
            pnlNhapLieu = new Panel();
            lblMaTL = new Label();
            txtMaTL = new TextBox();
            lblTenTL = new Label();
            cboTenTL = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLuuTheLoai = new Button();
            dgvTheLoai = new DataGridView();
            colMaTL = new DataGridViewTextBoxColumn();
            colTenTL = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).BeginInit();
            grpTimTheLoai.SuspendLayout();
            pnlNhapLieu.SuspendLayout();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.Dock = DockStyle.Top;
            lblTieuDe.BackColor = Color.FromArgb(0, 153, 150);
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.Size = new Size(880, 47);
            lblTieuDe.Text = "Quản Lý Thể Loại";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.TabIndex = 0;
            // 
            // grpTimTheLoai
            // 
            grpTimTheLoai.Location = new Point(370, 60);
            grpTimTheLoai.Size = new Size(490, 75);
            grpTimTheLoai.Text = "Tìm Kiếm Thể Loại";
            grpTimTheLoai.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpTimTheLoai.Name = "grpTimTheLoai";
            grpTimTheLoai.TabIndex = 1;
            // 
            // radTimMa
            // 
            radTimMa.AutoSize = true;
            radTimMa.Location = new Point(16, 29);
            radTimMa.Text = "Mã Thể Loại";
            radTimMa.Name = "radTimMa";
            radTimMa.TabIndex = 0;
            // 
            // radTimTen
            // 
            radTimTen.AutoSize = true;
            radTimTen.Checked = true;
            radTimTen.Location = new Point(132, 29);
            radTimTen.Text = "Tên Thể Loại";
            radTimTen.Name = "radTimTen";
            radTimTen.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(250, 26);
            txtTimKiem.Size = new Size(225, 23);
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.TabIndex = 2;
            // 
            // pnlNhapLieu
            // 
            pnlNhapLieu.Location = new Point(20, 60);
            pnlNhapLieu.Size = new Size(335, 470);
            pnlNhapLieu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlNhapLieu.Name = "pnlNhapLieu";
            pnlNhapLieu.TabIndex = 2;
            // 
            // lblMaTL
            // 
            lblMaTL.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaTL.Location = new Point(0, 30);
            lblMaTL.Size = new Size(112, 28);
            lblMaTL.Text = "Mã Thể Loại";
            lblMaTL.TextAlign = ContentAlignment.MiddleRight;
            lblMaTL.Name = "lblMaTL";
            lblMaTL.TabIndex = 0;
            // 
            // txtMaTL
            // 
            txtMaTL.Location = new Point(120, 30);
            txtMaTL.Size = new Size(193, 23);
            txtMaTL.Name = "txtMaTL";
            txtMaTL.TabIndex = 1;
            // 
            // lblTenTL
            // 
            lblTenTL.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenTL.Location = new Point(0, 83);
            lblTenTL.Size = new Size(112, 28);
            lblTenTL.Text = "Tên Thể Loại";
            lblTenTL.TextAlign = ContentAlignment.MiddleRight;
            lblTenTL.Name = "lblTenTL";
            lblTenTL.TabIndex = 2;
            // 
            // cboTenTL
            // 
            cboTenTL.Location = new Point(120, 83);
            cboTenTL.Size = new Size(193, 23);
            cboTenTL.Name = "cboTenTL";
            cboTenTL.TabIndex = 3;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.White;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.ForeColor = Color.FromArgb(133, 178, 174);
            btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(0, 300);
            btnThem.Size = new Size(99, 46);
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Name = "btnThem";
            btnThem.TabIndex = 4;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.White;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.ForeColor = Color.FromArgb(133, 178, 174);
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(114, 300);
            btnSua.Size = new Size(99, 46);
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Name = "btnSua";
            btnSua.TabIndex = 5;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.ForeColor = Color.FromArgb(133, 178, 174);
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(228, 300);
            btnXoa.Size = new Size(99, 46);
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Name = "btnXoa";
            btnXoa.TabIndex = 6;
            // 
            // btnLuuTheLoai
            // 
            btnLuuTheLoai.BackColor = Color.White;
            btnLuuTheLoai.FlatStyle = FlatStyle.Flat;
            btnLuuTheLoai.ForeColor = Color.FromArgb(133, 178, 174);
            btnLuuTheLoai.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLuuTheLoai.Location = new Point(57, 362);
            btnLuuTheLoai.Size = new Size(99, 46);
            btnLuuTheLoai.Text = "Lưu thể loại";
            btnLuuTheLoai.UseVisualStyleBackColor = false;
            btnLuuTheLoai.Name = "btnLuuTheLoai";
            btnLuuTheLoai.TabIndex = 7;
            // 
            // dgvTheLoai
            // 
            dgvTheLoai.AllowUserToAddRows = false;
            dgvTheLoai.AllowUserToDeleteRows = false;
            dgvTheLoai.ReadOnly = true;
            dgvTheLoai.AutoGenerateColumns = false;
            dgvTheLoai.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTheLoai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTheLoai.BackgroundColor = Color.DarkGray;
            dgvTheLoai.ColumnHeadersHeight = 28;
            dgvTheLoai.EnableHeadersVisualStyles = false;
            dgvTheLoai.Location = new Point(370, 150);
            dgvTheLoai.RowHeadersVisible = false;
            dgvTheLoai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTheLoai.Size = new Size(490, 380);
            dgvTheLoai.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(211, 231, 242);
            dgvTheLoai.Columns.AddRange(new DataGridViewColumn[] { colMaTL, colTenTL });
            dgvTheLoai.Name = "dgvTheLoai";
            dgvTheLoai.TabIndex = 3;
            // 
            // colMaTL
            // 
            colMaTL.DataPropertyName = "MaTL";
            colMaTL.HeaderText = "Mã thể loại";
            colMaTL.Name = "colMaTL";
            colMaTL.ReadOnly = true;
            // 
            // colTenTL
            // 
            colTenTL.DataPropertyName = "TenTL";
            colTenTL.HeaderText = "Tên thể loại";
            colTenTL.Name = "colTenTL";
            colTenTL.ReadOnly = true;
            grpTimTheLoai.Controls.Add(radTimMa);
            grpTimTheLoai.Controls.Add(radTimTen);
            grpTimTheLoai.Controls.Add(txtTimKiem);
            pnlNhapLieu.Controls.Add(lblMaTL);
            pnlNhapLieu.Controls.Add(txtMaTL);
            pnlNhapLieu.Controls.Add(lblTenTL);
            pnlNhapLieu.Controls.Add(cboTenTL);
            pnlNhapLieu.Controls.Add(btnThem);
            pnlNhapLieu.Controls.Add(btnSua);
            pnlNhapLieu.Controls.Add(btnXoa);
            pnlNhapLieu.Controls.Add(btnLuuTheLoai);
            // 
            // FrmTheLoai
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(880, 580);
            Controls.Add(dgvTheLoai);
            Controls.Add(pnlNhapLieu);
            Controls.Add(grpTimTheLoai);
            Controls.Add(lblTieuDe);
            Name = "FrmTheLoai";
            Text = "Quản lý thể loại";
            Load += FrmTheLoai_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).EndInit();
            grpTimTheLoai.ResumeLayout(false);
            grpTimTheLoai.PerformLayout();
            pnlNhapLieu.ResumeLayout(false);
            pnlNhapLieu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDe;
        private GroupBox grpTimTheLoai;
        private RadioButton radTimMa;
        private RadioButton radTimTen;
        private TextBox txtTimKiem;
        private Panel pnlNhapLieu;
        private Label lblMaTL;
        private TextBox txtMaTL;
        private Label lblTenTL;
        private ComboBox cboTenTL;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLuuTheLoai;
        private DataGridView dgvTheLoai;
        private DataGridViewTextBoxColumn colMaTL;
        private DataGridViewTextBoxColumn colTenTL;
    }
}
