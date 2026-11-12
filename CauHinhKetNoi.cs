using System.Text.Json;

namespace Hệ_Thống_Quản_Lý_Thư_Viện.Classes
{
    /// <summary>
    /// Đọc cấu hình kết nối SQL Server từ appsettings.json (dùng chung cho cả nhóm)
    /// và appsettings.local.json (riêng từng máy, KHÔNG đưa lên Git - ghi đè giá trị cùng tên).
    /// Không ghi mật khẩu hay chuỗi kết nối ra thông báo/log.
    /// </summary>
    internal static class CauHinhKetNoi
    {
        public static string Server { get; private set; } = ".";
        public static string Database { get; private set; } = "QuanLyThuVien";
        public static bool IntegratedSecurity { get; private set; } = true;
        public static string User { get; private set; } = "";
        public static string Password { get; private set; } = "";
        public static int ConnectTimeout { get; private set; } = 5;

        /// <summary>Danh sách file cấu hình đã nạp được (để báo lỗi dễ hiểu).</summary>
        public static string FileDaNap { get; private set; } = "(không có file cấu hình, dùng giá trị mặc định)";

        static CauHinhKetNoi()
        {
            string thuMuc = AppContext.BaseDirectory;
            var daNap = new List<string>();
            foreach (string ten in new[] { "appsettings.json", "appsettings.local.json" })
            {
                string duongDan = Path.Combine(thuMuc, ten);
                if (!File.Exists(duongDan)) continue;
                try
                {
                    NapFile(duongDan);
                    daNap.Add(ten);
                }
                catch (Exception ex)
                {
                    // File sai cú pháp: báo rõ tên file, không làm sập chương trình khi khởi động.
                    LoiCauHinh += $"File {ten} không hợp lệ: {ex.Message}\n";
                }
            }
            if (daNap.Count > 0) FileDaNap = string.Join(", ", daNap);
        }

        /// <summary>Khác rỗng nếu có file cấu hình bị lỗi cú pháp.</summary>
        public static string LoiCauHinh { get; private set; } = "";

        private static void NapFile(string duongDan)
        {
            using JsonDocument doc = JsonDocument.Parse(File.ReadAllText(duongDan),
                new JsonDocumentOptions { CommentHandling = JsonCommentHandling.Skip, AllowTrailingCommas = true });
            if (!doc.RootElement.TryGetProperty("Database", out JsonElement db)) return;

            if (db.TryGetProperty("Server", out var v) && v.ValueKind == JsonValueKind.String && v.GetString()!.Trim() != "")
                Server = v.GetString()!.Trim();
            if (db.TryGetProperty("Database", out v) && v.ValueKind == JsonValueKind.String && v.GetString()!.Trim() != "")
                Database = v.GetString()!.Trim();
            if (db.TryGetProperty("IntegratedSecurity", out v) && (v.ValueKind == JsonValueKind.True || v.ValueKind == JsonValueKind.False))
                IntegratedSecurity = v.GetBoolean();
            if (db.TryGetProperty("User", out v) && v.ValueKind == JsonValueKind.String)
                User = v.GetString() ?? "";
            if (db.TryGetProperty("Password", out v) && v.ValueKind == JsonValueKind.String)
                Password = v.GetString() ?? "";
            if (db.TryGetProperty("ConnectTimeout", out v) && v.ValueKind == JsonValueKind.Number && v.TryGetInt32(out int t) && t > 0)
                ConnectTimeout = t;
        }

        public static string TaoChuoiKetNoi()
        {
            string auth = IntegratedSecurity
                ? "Integrated Security=True;"
                : "User ID=" + User + ";Password=" + Password + ";";
            return "Data Source=" + Server + ";Initial Catalog=" + Database + ";" + auth +
                   "TrustServerCertificate=True;Connect Timeout=" + ConnectTimeout + ";";
        }
    }
}
