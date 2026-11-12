using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Hệ_Thống_Quản_Lý_Thư_Viện.Classes;

namespace Hệ_Thống_Quản_Lý_Thư_Viện.Forms
{
    /// <summary>
    /// Thống kê báo cáo - Form con (nhúng vào pnlContent của FrmMain, giống FrmSinhVien).
    /// Giao diện: TV3. Logic: TV4. Form KHÔNG tự mở/đóng FrmMain, không gọi Application.Exit().
    /// CSDL: view v_DangMuon, v_QuaHan. Các nhãn lblTongSach/lblTongPhieuMuon/lblTongSoPhieuMuon/lblSachChuaTra đang là chữ cố định của TV3 (có số mẫu, 2 nhãn phiếu mượn mâu thuẫn nhau) -> TV4 thay bằng dữ liệu thật. Biểu đồ dùng gói WinForms.DataVisualization (đã khai báo trong .csproj). Chỉ Admin được vào form này.
    /// </summary>
    public partial class FrmThongKe : Form
    {
        private readonly DataProcesser db = new();
        private Chart chartMuonTraTheoThang = null!;

        public FrmThongKe()
        {
            InitializeComponent();
            btnXuatBaoCao.Click += BtnXuatBaoCao_Click;
        }

        private void FrmThongKe_Load(object? sender, EventArgs e)
        {
            if (!TaiKhoanDangNhap.CoQuyen(ChucNang.ThongKe))
            {
                MessageBox.Show("Bạn không có quyền sử dụng chức năng thống kê.", "Phân quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BeginInvoke(Close);
                return;
            }

            TaoBieuDoMuonTra();
            TaiThongKe();
        }

        private void TaiThongKe()
        {
            try
            {
                lblTongSach.Text = "Tổng số sách: " + GiaTri("SELECT COUNT(*) FROM tblSach");
                lblTongPhieuMuon.Text = "Tổng phiếu mượn: " + GiaTri("SELECT COUNT(*) FROM tblPhieuMuon");
                lblTongSoPhieuMuon.Text = "Phiếu đang mượn: " + GiaTri("SELECT COUNT(DISTINCT MaPM) FROM v_DangMuon");
                lblSachChuaTra.Text = "Sách chưa trả: " + GiaTri("SELECT COUNT(*) FROM v_DangMuon");

                TaiThongKeTheLoai();
                TaiBieuDoSachMuonNhieu();
                TaiBieuDoMuonTraTheoThang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải báo cáo thống kê: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GiaTri(string sql)
        {
            return Convert.ToString(db.LayGiaTri(sql)) ?? "0";
        }

        private void TaiThongKeTheLoai()
        {
            flpThongKeTheLoai.Controls.Clear();
            flpThongKeTheLoai.Controls.Add(lblThongKeTheLoai);

            DataTable bang = db.DocBang(@"
                SELECT tl.TenTL, COUNT(s.MaSach) AS SoSach
                FROM tblTheLoai tl
                LEFT JOIN tblSach s ON s.MaTL = tl.MaTL
                GROUP BY tl.MaTL, tl.TenTL
                ORDER BY tl.TenTL");

            foreach (DataRow row in bang.Rows)
            {
                Label dong = new()
                {
                    AutoSize = false,
                    Width = 290,
                    Height = 28,
                    Text = $"{row["TenTL"]}: {row["SoSach"]} sách",
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(4, 0, 0, 0)
                };
                flpThongKeTheLoai.Controls.Add(dong);
            }
        }

        private void TaiBieuDoSachMuonNhieu()
        {
            DataTable bang = db.DocBang(@"
                SELECT TOP 5 s.TenSach, SUM(c.SoLuong) AS SoLuongMuon
                FROM tblChiTietMuon c
                INNER JOIN tblSach s ON s.MaSach = c.MaSach
                GROUP BY s.MaSach, s.TenSach
                ORDER BY SUM(c.SoLuong) DESC, s.TenSach");

            Series series = chartSachMuonNhieu.Series[0];
            series.Points.Clear();
            series.ChartType = SeriesChartType.Bar;
            series.IsValueShownAsLabel = true;
            series.ToolTip = "#VALX: #VAL";
            foreach (DataRow row in bang.Rows)
                series.Points.AddXY(Convert.ToString(row["TenSach"]), Convert.ToInt32(row["SoLuongMuon"]));

            chartSachMuonNhieu.ChartAreas[0].AxisX.Interval = 1;
            chartSachMuonNhieu.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 8F);
        }

        private void TaoBieuDoMuonTra()
        {
            chartMuonTraTheoThang = new Chart
            {
                Location = new Point(0, 34),
                Size = new Size(Math.Max(1, pnlMuonTraTheoThang.ClientSize.Width - 2),
                    Math.Max(1, pnlMuonTraTheoThang.ClientSize.Height - 36)),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                Name = "chartMuonTraTheoThang"
            };
            chartMuonTraTheoThang.ChartAreas.Add(new ChartArea("ChartArea1"));
            chartMuonTraTheoThang.Legends.Add(new Legend("Legend1"));
            chartMuonTraTheoThang.Series.Add(new Series("Đăng ký mượn")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "ChartArea1",
                Legend = "Legend1"
            });
            chartMuonTraTheoThang.Series.Add(new Series("Đã trả")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "ChartArea1",
                Legend = "Legend1"
            });
            pnlMuonTraTheoThang.Controls.Add(chartMuonTraTheoThang);
        }

        private void TaiBieuDoMuonTraTheoThang()
        {
            DataTable bang = db.DocBang(@"
                SELECT Thang, SUM(Muon) AS Muon, SUM(Tra) AS Tra
                FROM (
                    SELECT MONTH(NgayMuon) AS Thang, COUNT(*) AS Muon, 0 AS Tra
                    FROM tblPhieuMuon
                    GROUP BY MONTH(NgayMuon)
                    UNION ALL
                    SELECT MONTH(NgayTra) AS Thang, 0 AS Muon, COUNT(*) AS Tra
                    FROM tblChiTietMuon
                    WHERE NgayTra IS NOT NULL
                    GROUP BY MONTH(NgayTra)
                ) AS t
                GROUP BY Thang
                ORDER BY Thang");

            foreach (Series series in chartMuonTraTheoThang.Series)
                series.Points.Clear();

            foreach (DataRow row in bang.Rows)
            {
                string thang = "T" + Convert.ToString(row["Thang"]);
                chartMuonTraTheoThang.Series["Đăng ký mượn"].Points.AddXY(thang, Convert.ToInt32(row["Muon"]));
                chartMuonTraTheoThang.Series["Đã trả"].Points.AddXY(thang, Convert.ToInt32(row["Tra"]));
            }
            chartMuonTraTheoThang.ChartAreas[0].AxisX.Interval = 1;
        }

        private void BtnXuatBaoCao_Click(object? sender, EventArgs e)
        {
            using SaveFileDialog dialog = new()
            {
                Filter = "Excel CSV (*.csv)|*.csv|Tệp văn bản (*.txt)|*.txt",
                FileName = "BaoCaoThuVien_" + DateTime.Today.ToString("yyyyMMdd") + ".csv",
                Title = "Xuất báo cáo thống kê"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                DataTable bang = db.DocBang(@"
                    SELECT s.MaSach, s.TenSach, s.TacGia, tl.TenTL,
                           s.NhaXuatBan, s.SoLuong
                    FROM tblSach s
                    LEFT JOIN tblTheLoai tl ON tl.MaTL = s.MaTL
                    ORDER BY s.MaSach");

                StringBuilder noiDung = new();
                noiDung.AppendLine("MaSach,TenSach,TacGia,TheLoai,NhaXuatBan,SoLuong");
                foreach (DataRow row in bang.Rows)
                {
                    noiDung.AppendLine(string.Join(",", new[]
                    {
                        Csv(row["MaSach"]), Csv(row["TenSach"]), Csv(row["TacGia"]),
                        Csv(row["TenTL"]), Csv(row["NhaXuatBan"]), Csv(row["SoLuong"])
                    }));
                }

                File.WriteAllText(dialog.FileName, "\uFEFF" + noiDung, Encoding.UTF8);
                MessageBox.Show("Đã xuất báo cáo thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất báo cáo thất bại: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string Csv(object value)
        {
            if (value == DBNull.Value || value == null)
                return "";
            string text = Convert.ToString(value) ?? "";
            return "\"" + text.Replace("\"", "\"\"") + "\"";
        }
    }
}
