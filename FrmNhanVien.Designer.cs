namespace Hệ_Thống_Quản_Lý_Thư_Viện.Forms
{
    partial class FrmNhanVien
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
            lblMaNV = new Label();
            txtMaNV = new TextBox();
            lblTenNV = new Label();
            txtTenNV = new TextBox();
            lblChucVu = new Label();
            cboChucVu = new ComboBox();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnGhi = new Button();
            btnHuy = new Button();
            dgvNhanVien = new DataGridView();
            colMaNV = new DataGridViewTextBoxColumn();
            colTenNV = new DataGridViewTextBoxColumn();
            colChucVu = new DataGridViewTextBoxColumn();
            colSoDienThoai = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
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
            lblTieuDe.Text = "Quản Lý Nhân Viên";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.TabIndex = 0;
            // 
            // grpTimKiem
            // 
            grpTimKiem.Location = new Point(370, 60);
            grpTimKiem.Size = new Size(490, 75);
            grpTimKiem.Text = "Tìm Kiếm Nhân Viên";
            grpTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpTimKiem.Name = "grpTimKiem";
            grpTimKiem.TabIndex = 1;
            // 
            // radTimMa
            // 
            radTimMa.AutoSize = true;
            radTimMa.Location = new Point(16, 29);
            radTimMa.Text = "Mã Nhân Viên";
            radTimMa.Name = "radTimMa";
            radTimMa.TabIndex = 0;
            // 
            // radTimTen
            // 
            radTimTen.AutoSize = true;
            radTimTen.Checked = true;
            radTimTen.Location = new Point(132, 29);
            radTimTen.Text = "Tên Nhân Viên";
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
            // lblMaNV
            // 
            lblMaNV.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaNV.Location = new Point(0, 30);
            lblMaNV.Size = new Size(112, 28);
            lblMaNV.Text = "Mã Nhân Viên";
            lblMaNV.TextAlign = ContentAlignment.MiddleRight;
            lblMaNV.Name = "lblMaNV";
            lblMaNV.TabIndex = 0;
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(120, 30);
            txtMaNV.Size = new Size(193, 23);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.TabIndex = 1;
            // 
            // lblTenNV
            // 
            lblTenNV.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenNV.Location = new Point(0, 83);
            lblTenNV.Size = new Size(112, 28);
            lblTenNV.Text = "Họ và Tên";
            lblTenNV.TextAlign = ContentAlignment.MiddleRight;
            lblTenNV.Name = "lblTenNV";
            lblTenNV.TabIndex = 2;
            // 
            // txtTenNV
            // 
            txtTenNV.Location = new Point(120, 83);
            txtTenNV.Size = new Size(193, 23);
            txtTenNV.Name = "txtTenNV";
            txtTenNV.TabIndex = 3;
            // 
            // lblChucVu
            // 
            lblChucVu.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChucVu.Location = new Point(0, 136);
            lblChucVu.Size = new Size(112, 28);
            lblChucVu.Text = "Chức Vụ";
            lblChucVu.TextAlign = ContentAlignment.MiddleRight;
            lblChucVu.Name = "lblChucVu";
            lblChucVu.TabIndex = 4;
            // 
            // cboChucVu
            // 
            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucVu.Location = new Point(120, 136);
            cboChucVu.Size = new Size(193, 23);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.TabIndex = 5;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSoDienThoai.Location = new Point(0, 189);
            lblSoDienThoai.Size = new Size(112, 28);
            lblSoDienThoai.Text = "Số Điện Thoại";
            lblSoDienThoai.TextAlign = ContentAlignment.MiddleRight;
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.TabIndex = 6;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(120, 189);
            txtSoDienThoai.Size = new Size(193, 23);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(0, 242);
            lblEmail.Size = new Size(112, 28);
            lblEmail.Text = "Email";
            lblEmail.TextAlign = ContentAlignment.MiddleRight;
            lblEmail.Name = "lblEmail";
            lblEmail.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(120, 242);
            txtEmail.Size = new Size(193, 23);
            txtEmail.Name = "txtEmail";
            txtEmail.TabIndex = 9;
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
            btnXoa.Text = "Xóa";
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
            btnHuy.Text = "Hủy bỏ";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Name = "btnHuy";
            btnHuy.TabIndex = 14;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToDeleteRows = false;
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.AutoGenerateColumns = false;
            dgvNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.BackgroundColor = Color.DarkGray;
            dgvNhanVien.ColumnHeadersHeight = 28;
            dgvNhanVien.EnableHeadersVisualStyles = false;
            dgvNhanVien.Location = new Point(370, 150);
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new Size(490, 380);
            dgvNhanVien.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(211, 231, 242);
            dgvNhanVien.Columns.AddRange(new DataGridViewColumn[] { colMaNV, colTenNV, colChucVu, colSoDienThoai });
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.TabIndex = 3;
            // 
            // colMaNV
            // 
            colMaNV.DataPropertyName = "MaNV";
            colMaNV.HeaderText = "Mã NV";
            colMaNV.Name = "colMaNV";
            colMaNV.ReadOnly = true;
            // 
            // colTenNV
            // 
            colTenNV.DataPropertyName = "TenNV";
            colTenNV.HeaderText = "Họ và tên";
            colTenNV.Name = "colTenNV";
            colTenNV.ReadOnly = true;
            // 
            // colChucVu
            // 
            colChucVu.DataPropertyName = "ChucVu";
            colChucVu.HeaderText = "Chức vụ";
            colChucVu.Name = "colChucVu";
            colChucVu.ReadOnly = true;
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
            pnlNhapLieu.Controls.Add(lblMaNV);
            pnlNhapLieu.Controls.Add(txtMaNV);
            pnlNhapLieu.Controls.Add(lblTenNV);
            pnlNhapLieu.Controls.Add(txtTenNV);
            pnlNhapLieu.Controls.Add(lblChucVu);
            pnlNhapLieu.Controls.Add(cboChucVu);
            pnlNhapLieu.Controls.Add(lblSoDienThoai);
            pnlNhapLieu.Controls.Add(txtSoDienThoai);
            pnlNhapLieu.Controls.Add(lblEmail);
            pnlNhapLieu.Controls.Add(txtEmail);
            pnlNhapLieu.Controls.Add(btnThem);
            pnlNhapLieu.Controls.Add(btnSua);
            pnlNhapLieu.Controls.Add(btnXoa);
            pnlNhapLieu.Controls.Add(btnGhi);
            pnlNhapLieu.Controls.Add(btnHuy);
            // 
            // FrmNhanVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(880, 580);
            Controls.Add(dgvNhanVien);
            Controls.Add(pnlNhapLieu);
            Controls.Add(grpTimKiem);
            Controls.Add(lblTieuDe);
            Name = "FrmNhanVien";
            Text = "Quản lý nhân viên";
            Load += FrmNhanVien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
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
        private Label lblMaNV;
        private TextBox txtMaNV;
        private Label lblTenNV;
        private TextBox txtTenNV;
        private Label lblChucVu;
        private ComboBox cboChucVu;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnGhi;
        private Button btnHuy;
        private DataGridView dgvNhanVien;
        private DataGridViewTextBoxColumn colMaNV;
        private DataGridViewTextBoxColumn colTenNV;
        private DataGridViewTextBoxColumn colChucVu;
        private DataGridViewTextBoxColumn colSoDienThoai;
    }
}
