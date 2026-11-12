namespace Hệ_Thống_Quản_Lý_Thư_Viện.Forms
{
    partial class FrmThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            lblTieuDe = new Label();
            tlpTheThongKe = new TableLayoutPanel();
            pnlTheTongSach = new Panel();
            lblTongSach = new Label();
            pnlTheTongPhieuMuon = new Panel();
            lblTongPhieuMuon = new Label();
            pnlTheTongSoPhieuMuon = new Panel();
            lblTongSoPhieuMuon = new Label();
            pnlTheSachChuaTra = new Panel();
            lblSachChuaTra = new Label();
            flpThongKeTheLoai = new FlowLayoutPanel();
            lblThongKeTheLoai = new Label();
            btnXuatBaoCao = new Button();
            pnlSachMuonNhieu = new Panel();
            lblSachMuonNhieu = new Label();
            chartSachMuonNhieu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            pnlMuonTraTheoThang = new Panel();
            lblMuonTraTheoThang = new Label();
            tlpTheThongKe.SuspendLayout();
            pnlTheTongSach.SuspendLayout();
            pnlTheTongPhieuMuon.SuspendLayout();
            pnlTheTongSoPhieuMuon.SuspendLayout();
            pnlTheSachChuaTra.SuspendLayout();
            flpThongKeTheLoai.SuspendLayout();
            pnlSachMuonNhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartSachMuonNhieu).BeginInit();
            pnlMuonTraTheoThang.SuspendLayout();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.Dock = DockStyle.Top;
            lblTieuDe.BackColor = Color.FromArgb(0, 153, 150);
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTieuDe.Size = new Size(880, 47);
            lblTieuDe.Text = "Thống Kê Báo Cáo";
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.TabIndex = 0;
            // 
            // tlpTheThongKe
            // 
            tlpTheThongKe.ColumnCount = 4;
            tlpTheThongKe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTheThongKe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTheThongKe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTheThongKe.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpTheThongKe.RowCount = 1;
            tlpTheThongKe.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpTheThongKe.Location = new Point(20, 60);
            tlpTheThongKe.Size = new Size(840, 60);
            tlpTheThongKe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tlpTheThongKe.Name = "tlpTheThongKe";
            tlpTheThongKe.TabIndex = 1;
            // 
            // pnlTheTongSach
            // 
            pnlTheTongSach.BackColor = Color.White;
            pnlTheTongSach.BorderStyle = BorderStyle.FixedSingle;
            pnlTheTongSach.Dock = DockStyle.Fill;
            pnlTheTongSach.Margin = new Padding(0, 0, 15, 0);
            pnlTheTongSach.Name = "pnlTheTongSach";
            pnlTheTongSach.TabIndex = 1;
            // 
            // lblTongSach
            // 
            lblTongSach.Dock = DockStyle.Fill;
            lblTongSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongSach.ForeColor = Color.FromArgb(0, 153, 150);
            lblTongSach.Text = "Tổng số sách: 56";
            lblTongSach.TextAlign = ContentAlignment.MiddleCenter;
            lblTongSach.Name = "lblTongSach";
            lblTongSach.TabIndex = 0;
            // 
            // pnlTheTongPhieuMuon
            // 
            pnlTheTongPhieuMuon.BackColor = Color.White;
            pnlTheTongPhieuMuon.BorderStyle = BorderStyle.FixedSingle;
            pnlTheTongPhieuMuon.Dock = DockStyle.Fill;
            pnlTheTongPhieuMuon.Margin = new Padding(0, 0, 15, 0);
            pnlTheTongPhieuMuon.Name = "pnlTheTongPhieuMuon";
            pnlTheTongPhieuMuon.TabIndex = 2;
            // 
            // lblTongPhieuMuon
            // 
            lblTongPhieuMuon.Dock = DockStyle.Fill;
            lblTongPhieuMuon.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongPhieuMuon.ForeColor = Color.FromArgb(0, 153, 150);
            lblTongPhieuMuon.Text = "Tổng phiếu mượn: 290";
            lblTongPhieuMuon.TextAlign = ContentAlignment.MiddleCenter;
            lblTongPhieuMuon.Name = "lblTongPhieuMuon";
            lblTongPhieuMuon.TabIndex = 0;
            // 
            // pnlTheTongSoPhieuMuon
            // 
            pnlTheTongSoPhieuMuon.BackColor = Color.White;
            pnlTheTongSoPhieuMuon.BorderStyle = BorderStyle.FixedSingle;
            pnlTheTongSoPhieuMuon.Dock = DockStyle.Fill;
            pnlTheTongSoPhieuMuon.Margin = new Padding(0, 0, 15, 0);
            pnlTheTongSoPhieuMuon.Name = "pnlTheTongSoPhieuMuon";
            pnlTheTongSoPhieuMuon.TabIndex = 3;
            // 
            // lblTongSoPhieuMuon
            // 
            lblTongSoPhieuMuon.Dock = DockStyle.Fill;
            lblTongSoPhieuMuon.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongSoPhieuMuon.ForeColor = Color.FromArgb(0, 153, 150);
            lblTongSoPhieuMuon.Text = "Tổng số phiếu mượn: 0";
            lblTongSoPhieuMuon.TextAlign = ContentAlignment.MiddleCenter;
            lblTongSoPhieuMuon.Name = "lblTongSoPhieuMuon";
            lblTongSoPhieuMuon.TabIndex = 0;
            // 
            // pnlTheSachChuaTra
            // 
            pnlTheSachChuaTra.BackColor = Color.White;
            pnlTheSachChuaTra.BorderStyle = BorderStyle.FixedSingle;
            pnlTheSachChuaTra.Dock = DockStyle.Fill;
            pnlTheSachChuaTra.Margin = new Padding(0, 0, 0, 0);
            pnlTheSachChuaTra.Name = "pnlTheSachChuaTra";
            pnlTheSachChuaTra.TabIndex = 4;
            // 
            // lblSachChuaTra
            // 
            lblSachChuaTra.Dock = DockStyle.Fill;
            lblSachChuaTra.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSachChuaTra.ForeColor = Color.FromArgb(0, 153, 150);
            lblSachChuaTra.Text = "Sách chưa trả: 27";
            lblSachChuaTra.TextAlign = ContentAlignment.MiddleCenter;
            lblSachChuaTra.Name = "lblSachChuaTra";
            lblSachChuaTra.TabIndex = 0;
            // 
            // flpThongKeTheLoai
            // 
            flpThongKeTheLoai.AutoScroll = true;
            flpThongKeTheLoai.BackColor = Color.White;
            flpThongKeTheLoai.BorderStyle = BorderStyle.FixedSingle;
            flpThongKeTheLoai.FlowDirection = FlowDirection.TopDown;
            flpThongKeTheLoai.WrapContents = false;
            flpThongKeTheLoai.Padding = new Padding(10, 8, 10, 8);
            flpThongKeTheLoai.Location = new Point(20, 135);
            flpThongKeTheLoai.Size = new Size(335, 334);
            flpThongKeTheLoai.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flpThongKeTheLoai.Name = "flpThongKeTheLoai";
            flpThongKeTheLoai.TabIndex = 5;
            // 
            // lblThongKeTheLoai
            // 
            lblThongKeTheLoai.AutoSize = true;
            lblThongKeTheLoai.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblThongKeTheLoai.Text = "Thống kê thể loại sách";
            lblThongKeTheLoai.Name = "lblThongKeTheLoai";
            lblThongKeTheLoai.TabIndex = 0;
            // 
            // btnXuatBaoCao
            // 
            btnXuatBaoCao.BackColor = Color.White;
            btnXuatBaoCao.FlatStyle = FlatStyle.Flat;
            btnXuatBaoCao.ForeColor = Color.FromArgb(133, 178, 174);
            btnXuatBaoCao.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXuatBaoCao.Location = new Point(20, 484);
            btnXuatBaoCao.Size = new Size(335, 46);
            btnXuatBaoCao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnXuatBaoCao.Text = "Xuất báo cáo PDF/Excel";
            btnXuatBaoCao.UseVisualStyleBackColor = false;
            btnXuatBaoCao.Name = "btnXuatBaoCao";
            btnXuatBaoCao.TabIndex = 6;
            // 
            // pnlSachMuonNhieu
            // 
            pnlSachMuonNhieu.BackColor = Color.White;
            pnlSachMuonNhieu.BorderStyle = BorderStyle.FixedSingle;
            pnlSachMuonNhieu.Location = new Point(370, 135);
            pnlSachMuonNhieu.Size = new Size(490, 185);
            pnlSachMuonNhieu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSachMuonNhieu.Name = "pnlSachMuonNhieu";
            pnlSachMuonNhieu.TabIndex = 7;
            // 
            // lblSachMuonNhieu
            // 
            lblSachMuonNhieu.AutoSize = true;
            lblSachMuonNhieu.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSachMuonNhieu.Location = new Point(10, 8);
            lblSachMuonNhieu.Text = "Sách mượn nhiều nhất";
            lblSachMuonNhieu.Name = "lblSachMuonNhieu";
            lblSachMuonNhieu.TabIndex = 0;
            // 
            // chartSachMuonNhieu
            // 
            chartArea1.Name = "ChartArea1";
            chartSachMuonNhieu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartSachMuonNhieu.Legends.Add(legend1);
            chartSachMuonNhieu.Location = new Point(0, 34);
            chartSachMuonNhieu.Size = new Size(488, 149);
            chartSachMuonNhieu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartSachMuonNhieu.Name = "chartSachMuonNhieu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartSachMuonNhieu.Series.Add(series1);
            chartSachMuonNhieu.TabIndex = 1;
            chartSachMuonNhieu.Text = "chartSachMuonNhieu";
            // 
            // pnlMuonTraTheoThang
            // 
            pnlMuonTraTheoThang.BackColor = Color.White;
            pnlMuonTraTheoThang.BorderStyle = BorderStyle.FixedSingle;
            pnlMuonTraTheoThang.Location = new Point(370, 335);
            pnlMuonTraTheoThang.Size = new Size(490, 195);
            pnlMuonTraTheoThang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlMuonTraTheoThang.Name = "pnlMuonTraTheoThang";
            pnlMuonTraTheoThang.TabIndex = 8;
            // 
            // lblMuonTraTheoThang
            // 
            lblMuonTraTheoThang.AutoSize = true;
            lblMuonTraTheoThang.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMuonTraTheoThang.Location = new Point(10, 8);
            lblMuonTraTheoThang.Text = "Tình hình mượn trả theo tháng";
            lblMuonTraTheoThang.Name = "lblMuonTraTheoThang";
            lblMuonTraTheoThang.TabIndex = 0;
            tlpTheThongKe.Controls.Add(pnlTheTongSach, 0, 0);
            tlpTheThongKe.Controls.Add(pnlTheTongPhieuMuon, 1, 0);
            tlpTheThongKe.Controls.Add(pnlTheTongSoPhieuMuon, 2, 0);
            tlpTheThongKe.Controls.Add(pnlTheSachChuaTra, 3, 0);
            pnlTheTongSach.Controls.Add(lblTongSach);
            pnlTheTongPhieuMuon.Controls.Add(lblTongPhieuMuon);
            pnlTheTongSoPhieuMuon.Controls.Add(lblTongSoPhieuMuon);
            pnlTheSachChuaTra.Controls.Add(lblSachChuaTra);
            flpThongKeTheLoai.Controls.Add(lblThongKeTheLoai);
            pnlSachMuonNhieu.Controls.Add(chartSachMuonNhieu);
            pnlSachMuonNhieu.Controls.Add(lblSachMuonNhieu);
            pnlMuonTraTheoThang.Controls.Add(lblMuonTraTheoThang);
            // 
            // FrmThongKe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(880, 580);
            Controls.Add(pnlMuonTraTheoThang);
            Controls.Add(pnlSachMuonNhieu);
            Controls.Add(btnXuatBaoCao);
            Controls.Add(flpThongKeTheLoai);
            Controls.Add(tlpTheThongKe);
            Controls.Add(lblTieuDe);
            Name = "FrmThongKe";
            Text = "Thống kê báo cáo";
            Load += FrmThongKe_Load;
            tlpTheThongKe.ResumeLayout(false);
            pnlTheTongSach.ResumeLayout(false);
            pnlTheTongPhieuMuon.ResumeLayout(false);
            pnlTheTongSoPhieuMuon.ResumeLayout(false);
            pnlTheSachChuaTra.ResumeLayout(false);
            flpThongKeTheLoai.ResumeLayout(false);
            flpThongKeTheLoai.PerformLayout();
            pnlSachMuonNhieu.ResumeLayout(false);
            pnlSachMuonNhieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartSachMuonNhieu).EndInit();
            pnlMuonTraTheoThang.ResumeLayout(false);
            pnlMuonTraTheoThang.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTieuDe;
        private TableLayoutPanel tlpTheThongKe;
        private Panel pnlTheTongSach;
        private Label lblTongSach;
        private Panel pnlTheTongPhieuMuon;
        private Label lblTongPhieuMuon;
        private Panel pnlTheTongSoPhieuMuon;
        private Label lblTongSoPhieuMuon;
        private Panel pnlTheSachChuaTra;
        private Label lblSachChuaTra;
        private FlowLayoutPanel flpThongKeTheLoai;
        private Label lblThongKeTheLoai;
        private Button btnXuatBaoCao;
        private Panel pnlSachMuonNhieu;
        private Label lblSachMuonNhieu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSachMuonNhieu;
        private Panel pnlMuonTraTheoThang;
        private Label lblMuonTraTheoThang;
    }
}
