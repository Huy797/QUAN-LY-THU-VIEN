namespace Hệ_Thống_Quản_Lý_Thư_Viện.Forms
{
    partial class FrmSach
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
            lblMaSach = new Label();
            txtMaSach = new TextBox();
            lblTenSach = new Label();
            txtTenSach = new TextBox();
            lblTacGia = new Label();
            txtTacGia = new TextBox();
            lblNhaXuatBan = new Label();
            cboNhaXuatBan = new ComboBox();
            lblSoLuong = new Label();
            txtSoLuong = new TextBox();
            lblTheLoai = new Label();
            cboTheLoai = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnGhi = new Button();
            btnHuy = new Button();
            dgvSach = new DataGridView();
            colMaSach = new DataGridViewTextBoxColumn();
            colTenSach = new DataGridViewTextBoxColumn();
            colTacGia = new DataGridViewTextBoxColumn();
            colMaTL = new DataGridViewTextBoxColumn();
            colNhaXuatBan = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvSach).BeginInit();
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
            lblTieuDe.Text = "Quản Lý Sách";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.TabIndex = 0;
            // 
            // grpTimKiem
            // 
            grpTimKiem.Location = new Point(370, 60);
            grpTimKiem.Size = new Size(490, 75);
            grpTimKiem.Text = "Tìm Kiếm Sách";
            grpTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpTimKiem.Name = "grpTimKiem";
            grpTimKiem.TabIndex = 1;
            // 
            // radTimMa
            // 
            radTimMa.AutoSize = true;
            radTimMa.Location = new Point(16, 29);
            radTimMa.Text = "Mã Sách";
            radTimMa.Name = "radTimMa";
            radTimMa.TabIndex = 0;
            // 
            // radTimTen
            // 
            radTimTen.AutoSize = true;
            radTimTen.Checked = true;
            radTimTen.Location = new Point(132, 29);
            radTimTen.Text = "Tên Sách";
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
            // lblMaSach
            // 
            lblMaSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaSach.Location = new Point(0, 30);
            lblMaSach.Size = new Size(112, 28);
            lblMaSach.Text = "Mã Sách";
            lblMaSach.TextAlign = ContentAlignment.MiddleRight;
            lblMaSach.Name = "lblMaSach";
            lblMaSach.TabIndex = 0;
            // 
            // txtMaSach
            // 
            txtMaSach.Location = new Point(120, 30);
            txtMaSach.Size = new Size(193, 23);
            txtMaSach.Name = "txtMaSach";
            txtMaSach.TabIndex = 1;
            // 
            // lblTenSach
            // 
            lblTenSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenSach.Location = new Point(0, 75);
            lblTenSach.Size = new Size(112, 28);
            lblTenSach.Text = "Tên Sách";
            lblTenSach.TextAlign = ContentAlignment.MiddleRight;
            lblTenSach.Name = "lblTenSach";
            lblTenSach.TabIndex = 2;
            // 
            // txtTenSach
            // 
            txtTenSach.Location = new Point(120, 75);
            txtTenSach.Size = new Size(193, 23);
            txtTenSach.Name = "txtTenSach";
            txtTenSach.TabIndex = 3;
            // 
            // lblTacGia
            // 
            lblTacGia.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTacGia.Location = new Point(0, 120);
            lblTacGia.Size = new Size(112, 28);
            lblTacGia.Text = "Tác Giả";
            lblTacGia.TextAlign = ContentAlignment.MiddleRight;
            lblTacGia.Name = "lblTacGia";
            lblTacGia.TabIndex = 4;
            // 
            // txtTacGia
            // 
            txtTacGia.Location = new Point(120, 120);
            txtTacGia.Size = new Size(193, 23);
            txtTacGia.Name = "txtTacGia";
            txtTacGia.TabIndex = 5;
            // 
            // lblNhaXuatBan
            // 
            lblNhaXuatBan.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNhaXuatBan.Location = new Point(0, 165);
            lblNhaXuatBan.Size = new Size(112, 28);
            lblNhaXuatBan.Text = "Nhà Xuất Bản";
            lblNhaXuatBan.TextAlign = ContentAlignment.MiddleRight;
            lblNhaXuatBan.Name = "lblNhaXuatBan";
            lblNhaXuatBan.TabIndex = 6;
            // 
            // cboNhaXuatBan
            // 
            cboNhaXuatBan.Location = new Point(120, 165);
            cboNhaXuatBan.Size = new Size(193, 23);
            cboNhaXuatBan.Name = "cboNhaXuatBan";
            cboNhaXuatBan.TabIndex = 7;
            // 
            // lblSoLuong
            // 
            lblSoLuong.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSoLuong.Location = new Point(0, 210);
            lblSoLuong.Size = new Size(112, 28);
            lblSoLuong.Text = "Số Lượng";
            lblSoLuong.TextAlign = ContentAlignment.MiddleRight;
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.TabIndex = 8;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(120, 210);
            txtSoLuong.Size = new Size(193, 23);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.TabIndex = 9;
            // 
            // lblTheLoai
            // 
            lblTheLoai.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTheLoai.Location = new Point(0, 255);
            lblTheLoai.Size = new Size(112, 28);
            lblTheLoai.Text = "Thể Loại";
            lblTheLoai.TextAlign = ContentAlignment.MiddleRight;
            lblTheLoai.Name = "lblTheLoai";
            lblTheLoai.TabIndex = 10;
            // 
            // cboTheLoai
            // 
            cboTheLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTheLoai.Location = new Point(120, 255);
            cboTheLoai.Size = new Size(193, 23);
            cboTheLoai.Name = "cboTheLoai";
            cboTheLoai.TabIndex = 11;
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
            btnThem.TabIndex = 12;
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
            btnSua.TabIndex = 13;
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
            btnXoa.TabIndex = 14;
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
            btnGhi.TabIndex = 15;
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
            btnHuy.TabIndex = 16;
            // 
            // dgvSach
            // 
            dgvSach.AllowUserToAddRows = false;
            dgvSach.AllowUserToDeleteRows = false;
            dgvSach.ReadOnly = true;
            dgvSach.AutoGenerateColumns = false;
            dgvSach.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSach.BackgroundColor = Color.DarkGray;
            dgvSach.ColumnHeadersHeight = 28;
            dgvSach.EnableHeadersVisualStyles = false;
            dgvSach.Location = new Point(370, 150);
            dgvSach.RowHeadersVisible = false;
            dgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSach.Size = new Size(490, 380);
            dgvSach.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(211, 231, 242);
            dgvSach.Columns.AddRange(new DataGridViewColumn[] { colMaSach, colTenSach, colTacGia, colMaTL, colNhaXuatBan, colSoLuong });
            dgvSach.Name = "dgvSach";
            dgvSach.TabIndex = 3;
            // 
            // colMaSach
            // 
            colMaSach.DataPropertyName = "MaSach";
            colMaSach.HeaderText = "Mã sách";
            colMaSach.Name = "colMaSach";
            colMaSach.ReadOnly = true;
            // 
            // colTenSach
            // 
            colTenSach.DataPropertyName = "TenSach";
            colTenSach.HeaderText = "Tên sách";
            colTenSach.Name = "colTenSach";
            colTenSach.ReadOnly = true;
            // 
            // colTacGia
            // 
            colTacGia.DataPropertyName = "TacGia";
            colTacGia.HeaderText = "Tác giả";
            colTacGia.Name = "colTacGia";
            colTacGia.ReadOnly = true;
            // 
            // colMaTL
            // 
            colMaTL.DataPropertyName = "MaTL";
            colMaTL.HeaderText = "Thể loại";
            colMaTL.Name = "colMaTL";
            colMaTL.ReadOnly = true;
            // 
            // colNhaXuatBan
            // 
            colNhaXuatBan.DataPropertyName = "NhaXuatBan";
            colNhaXuatBan.HeaderText = "Nhà xuất bản";
            colNhaXuatBan.Name = "colNhaXuatBan";
            colNhaXuatBan.ReadOnly = true;
            // 
            // colSoLuong
            // 
            colSoLuong.DataPropertyName = "SoLuong";
            colSoLuong.HeaderText = "Số lượng";
            colSoLuong.Name = "colSoLuong";
            colSoLuong.ReadOnly = true;
            grpTimKiem.Controls.Add(radTimMa);
            grpTimKiem.Controls.Add(radTimTen);
            grpTimKiem.Controls.Add(txtTimKiem);
            pnlNhapLieu.Controls.Add(lblMaSach);
            pnlNhapLieu.Controls.Add(txtMaSach);
            pnlNhapLieu.Controls.Add(lblTenSach);
            pnlNhapLieu.Controls.Add(txtTenSach);
            pnlNhapLieu.Controls.Add(lblTacGia);
            pnlNhapLieu.Controls.Add(txtTacGia);
            pnlNhapLieu.Controls.Add(lblNhaXuatBan);
            pnlNhapLieu.Controls.Add(cboNhaXuatBan);
            pnlNhapLieu.Controls.Add(lblSoLuong);
            pnlNhapLieu.Controls.Add(txtSoLuong);
            pnlNhapLieu.Controls.Add(lblTheLoai);
            pnlNhapLieu.Controls.Add(cboTheLoai);
            pnlNhapLieu.Controls.Add(btnThem);
            pnlNhapLieu.Controls.Add(btnSua);
            pnlNhapLieu.Controls.Add(btnXoa);
            pnlNhapLieu.Controls.Add(btnGhi);
            pnlNhapLieu.Controls.Add(btnHuy);
            // 
            // FrmSach
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(880, 580);
            Controls.Add(dgvSach);
            Controls.Add(pnlNhapLieu);
            Controls.Add(grpTimKiem);
            Controls.Add(lblTieuDe);
            Name = "FrmSach";
            Text = "Quản lý sách";
            Load += FrmSach_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSach).EndInit();
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
        private Label lblMaSach;
        private TextBox txtMaSach;
        private Label lblTenSach;
        private TextBox txtTenSach;
        private Label lblTacGia;
        private TextBox txtTacGia;
        private Label lblNhaXuatBan;
        private ComboBox cboNhaXuatBan;
        private Label lblSoLuong;
        private TextBox txtSoLuong;
        private Label lblTheLoai;
        private ComboBox cboTheLoai;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnGhi;
        private Button btnHuy;
        private DataGridView dgvSach;
        private DataGridViewTextBoxColumn colMaSach;
        private DataGridViewTextBoxColumn colTenSach;
        private DataGridViewTextBoxColumn colTacGia;
        private DataGridViewTextBoxColumn colMaTL;
        private DataGridViewTextBoxColumn colNhaXuatBan;
        private DataGridViewTextBoxColumn colSoLuong;
    }
}
