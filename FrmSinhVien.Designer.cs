namespace Hệ_Thống_Quản_Lý_Thư_Viện.Forms
{
    partial class FrmSinhVien
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
            grpTimKiem = new GroupBox();
            radTimMa = new RadioButton();
            radTimTen = new RadioButton();
            txtTimKiem = new TextBox();
            pnlNhapLieu = new Panel();
            lblMaSV = new Label();
            txtMaSV = new TextBox();
            lblTenSV = new Label();
            txtTenSV = new TextBox();
            lblNganhHoc = new Label();
            txtNganhHoc = new TextBox();
            lblKhoaHoc = new Label();
            cboKhoaHoc = new ComboBox();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnGhi = new Button();
            btnHuy = new Button();
            dgvSinhVien = new DataGridView();
            colMaSV = new DataGridViewTextBoxColumn();
            colTenSV = new DataGridViewTextBoxColumn();
            colNganhHoc = new DataGridViewTextBoxColumn();
            colKhoaHoc = new DataGridViewTextBoxColumn();
            colSoDienThoai = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            grpTimKiem.SuspendLayout();
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
            lblTieuDe.Text = "Quản Lý Sinh Viên - Độc Giả";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.TabIndex = 0;
            // 
            // grpTimKiem
            // 
            grpTimKiem.Location = new Point(370, 60);
            grpTimKiem.Size = new Size(490, 75);
            grpTimKiem.Text = "Tìm Kiếm Sinh Viên";
            grpTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpTimKiem.Name = "grpTimKiem";
            grpTimKiem.TabIndex = 1;
            // 
            // radTimMa
            // 
            radTimMa.AutoSize = true;
            radTimMa.Location = new Point(16, 29);
            radTimMa.Text = "Mã Sinh Viên";
            radTimMa.Name = "radTimMa";
            radTimMa.TabIndex = 0;
            // 
            // radTimTen
            // 
            radTimTen.AutoSize = true;
            radTimTen.Checked = true;
            radTimTen.Location = new Point(132, 29);
            radTimTen.Text = "Tên Sinh Viên";
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
            // lblMaSV
            // 
            lblMaSV.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaSV.Location = new Point(0, 30);
            lblMaSV.Size = new Size(112, 28);
            lblMaSV.Text = "Mã Sinh Viên";
            lblMaSV.TextAlign = ContentAlignment.MiddleRight;
            lblMaSV.Name = "lblMaSV";
            lblMaSV.TabIndex = 0;
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(120, 30);
            txtMaSV.Size = new Size(193, 23);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.TabIndex = 1;
            // 
            // lblTenSV
            // 
            lblTenSV.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenSV.Location = new Point(0, 83);
            lblTenSV.Size = new Size(112, 28);
            lblTenSV.Text = "Họ và Tên";
            lblTenSV.TextAlign = ContentAlignment.MiddleRight;
            lblTenSV.Name = "lblTenSV";
            lblTenSV.TabIndex = 2;
            // 
            // txtTenSV
            // 
            txtTenSV.Location = new Point(120, 83);
            txtTenSV.Size = new Size(193, 23);
            txtTenSV.Name = "txtTenSV";
            txtTenSV.TabIndex = 3;
            // 
            // lblNganhHoc
            // 
            lblNganhHoc.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNganhHoc.Location = new Point(0, 136);
            lblNganhHoc.Size = new Size(112, 28);
            lblNganhHoc.Text = "Ngành Học";
            lblNganhHoc.TextAlign = ContentAlignment.MiddleRight;
            lblNganhHoc.Name = "lblNganhHoc";
            lblNganhHoc.TabIndex = 4;
            // 
            // txtNganhHoc
            // 
            txtNganhHoc.Location = new Point(120, 136);
            txtNganhHoc.Size = new Size(193, 23);
            txtNganhHoc.Name = "txtNganhHoc";
            txtNganhHoc.TabIndex = 5;
            // 
            // lblKhoaHoc
            // 
            lblKhoaHoc.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKhoaHoc.Location = new Point(0, 189);
            lblKhoaHoc.Size = new Size(112, 28);
            lblKhoaHoc.Text = "Khoá Học";
            lblKhoaHoc.TextAlign = ContentAlignment.MiddleRight;
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.TabIndex = 6;
            // 
            // cboKhoaHoc
            // 
            cboKhoaHoc.Items.AddRange(new object[] { "K63", "K62", "K61" });
            cboKhoaHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoaHoc.Location = new Point(120, 189);
            cboKhoaHoc.Size = new Size(193, 23);
            cboKhoaHoc.Name = "cboKhoaHoc";
            cboKhoaHoc.TabIndex = 7;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSoDienThoai.Location = new Point(0, 242);
            lblSoDienThoai.Size = new Size(112, 28);
            lblSoDienThoai.Text = "Số Điện Thoại";
            lblSoDienThoai.TextAlign = ContentAlignment.MiddleRight;
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.TabIndex = 8;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(120, 242);
            txtSoDienThoai.Size = new Size(193, 23);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.TabIndex = 9;
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
            btnThem.TabIndex = 10;
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
            btnSua.TabIndex = 11;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.White;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.ForeColor = Color.FromArgb(133, 178, 174);
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(228, 300);
            btnXoa.Size = new Size(99, 46);
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Name = "btnXoa";
            btnXoa.TabIndex = 12;
            // 
            // btnGhi
            // 
            btnGhi.BackColor = Color.White;
            btnGhi.FlatStyle = FlatStyle.Flat;
            btnGhi.ForeColor = Color.FromArgb(133, 178, 174);
            btnGhi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGhi.Location = new Point(57, 362);
            btnGhi.Size = new Size(99, 46);
            btnGhi.Text = "Ghi";
            btnGhi.UseVisualStyleBackColor = false;
            btnGhi.Name = "btnGhi";
            btnGhi.TabIndex = 13;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.White;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.ForeColor = Color.FromArgb(133, 178, 174);
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHuy.Location = new Point(171, 362);
            btnHuy.Size = new Size(99, 46);
            btnHuy.Text = "Huỷ bỏ";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Name = "btnHuy";
            btnHuy.TabIndex = 14;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.AutoGenerateColumns = false;
            dgvSinhVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.BackgroundColor = Color.DarkGray;
            dgvSinhVien.ColumnHeadersHeight = 28;
            dgvSinhVien.EnableHeadersVisualStyles = false;
            dgvSinhVien.Location = new Point(370, 150);
            dgvSinhVien.RowHeadersVisible = false;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.Size = new Size(490, 380);
            dgvSinhVien.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(211, 231, 242);
            dgvSinhVien.Columns.AddRange(new DataGridViewColumn[] { colMaSV, colTenSV, colNganhHoc, colKhoaHoc, colSoDienThoai });
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.TabIndex = 3;
            // 
            // colMaSV
            // 
            colMaSV.DataPropertyName = "MaSV";
            colMaSV.HeaderText = "Mã SV";
            colMaSV.Name = "colMaSV";
            colMaSV.ReadOnly = true;
            // 
            // colTenSV
            // 
            colTenSV.DataPropertyName = "TenSV";
            colTenSV.HeaderText = "Họ và tên";
            colTenSV.Name = "colTenSV";
            colTenSV.ReadOnly = true;
            // 
            // colNganhHoc
            // 
            colNganhHoc.DataPropertyName = "NganhHoc";
            colNganhHoc.HeaderText = "Ngành học";
            colNganhHoc.Name = "colNganhHoc";
            colNganhHoc.ReadOnly = true;
            // 
            // colKhoaHoc
            // 
            colKhoaHoc.DataPropertyName = "KhoaHoc";
            colKhoaHoc.HeaderText = "Khoá";
            colKhoaHoc.Name = "colKhoaHoc";
            colKhoaHoc.ReadOnly = true;
            // 
            // colSoDienThoai
            // 
            colSoDienThoai.DataPropertyName = "SoDienThoai";
            colSoDienThoai.HeaderText = "Số điện thoại";
            colSoDienThoai.Name = "colSoDienThoai";
            colSoDienThoai.ReadOnly = true;
            grpTimKiem.Controls.Add(radTimMa);
            grpTimKiem.Controls.Add(radTimTen);
            grpTimKiem.Controls.Add(txtTimKiem);
            pnlNhapLieu.Controls.Add(lblMaSV);
            pnlNhapLieu.Controls.Add(txtMaSV);
            pnlNhapLieu.Controls.Add(lblTenSV);
            pnlNhapLieu.Controls.Add(txtTenSV);
            pnlNhapLieu.Controls.Add(lblNganhHoc);
            pnlNhapLieu.Controls.Add(txtNganhHoc);
            pnlNhapLieu.Controls.Add(lblKhoaHoc);
            pnlNhapLieu.Controls.Add(cboKhoaHoc);
            pnlNhapLieu.Controls.Add(lblSoDienThoai);
            pnlNhapLieu.Controls.Add(txtSoDienThoai);
            pnlNhapLieu.Controls.Add(btnThem);
            pnlNhapLieu.Controls.Add(btnSua);
            pnlNhapLieu.Controls.Add(btnXoa);
            pnlNhapLieu.Controls.Add(btnGhi);
            pnlNhapLieu.Controls.Add(btnHuy);
            // 
            // FrmSinhVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(880, 580);
            Controls.Add(dgvSinhVien);
            Controls.Add(pnlNhapLieu);
            Controls.Add(grpTimKiem);
            Controls.Add(lblTieuDe);
            Name = "FrmSinhVien";
            Text = "Quản lý Sinh viên - Độc giả";
            Load += FrmSinhVien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            grpTimKiem.ResumeLayout(false);
            grpTimKiem.PerformLayout();
            pnlNhapLieu.ResumeLayout(false);
            pnlNhapLieu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDe;
        private GroupBox grpTimKiem;
        private RadioButton radTimMa;
        private RadioButton radTimTen;
        private TextBox txtTimKiem;
        private Panel pnlNhapLieu;
        private Label lblMaSV;
        private TextBox txtMaSV;
        private Label lblTenSV;
        private TextBox txtTenSV;
        private Label lblNganhHoc;
        private TextBox txtNganhHoc;
        private Label lblKhoaHoc;
        private ComboBox cboKhoaHoc;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnGhi;
        private Button btnHuy;
        private DataGridView dgvSinhVien;
        private DataGridViewTextBoxColumn colMaSV;
        private DataGridViewTextBoxColumn colTenSV;
        private DataGridViewTextBoxColumn colNganhHoc;
        private DataGridViewTextBoxColumn colKhoaHoc;
        private DataGridViewTextBoxColumn colSoDienThoai;
    }
}
