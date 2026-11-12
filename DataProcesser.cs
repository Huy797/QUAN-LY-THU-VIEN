using System;
using System.Data;
using System.Data.SqlClient;

namespace Hệ_Thống_Quản_Lý_Thư_Viện.Classes
{
    internal class DataProcesser
    {
        // Giữ lại 2 trường public static để code cũ của các thành viên vẫn dùng được;
        // giá trị lấy từ appsettings.json / appsettings.local.json (xem CauHinhKetNoi).
        public static string TenServer = CauHinhKetNoi.Server;
        public static string TenCSDL = CauHinhKetNoi.Database;

        string strConnect = CauHinhKetNoi.TaoChuoiKetNoi();

        SqlConnection sqlConnect = null;

        private void KetNoiCSDL()
        {
            sqlConnect = new SqlConnection(strConnect);
            if (sqlConnect.State != ConnectionState.Open)
                sqlConnect.Open();
        }

        private void DongKetNoiCSDL()
        {
            if (sqlConnect != null && sqlConnect.State != ConnectionState.Closed)
                sqlConnect.Close();
            if (sqlConnect != null)
                sqlConnect.Dispose();
        }

        public bool KiemTraKetNoi(out string loi)
        {
            loi = "";
            try
            {
                KetNoiCSDL();
                DongKetNoiCSDL();
                return true;
            }
            catch (Exception ex)
            {
                loi = ex.Message;
                return false;
            }
        }

        public DataTable DocBang(string sql)
        {
            return DocBang(sql, null);
        }

        public DataTable DocBang(string sql, params SqlParameter[] thamSo)
        {
            DataTable dtBang = new DataTable();
            try
            {
                KetNoiCSDL();
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlConnect);
                if (thamSo != null)
                    da.SelectCommand.Parameters.AddRange(thamSo);
                da.Fill(dtBang);
            }
            finally
            {
                DongKetNoiCSDL();
            }
            return dtBang;
        }

        public void CapNhatDuLieu(string sql)
        {
            CapNhatDuLieu(sql, null);
        }

        public void CapNhatDuLieu(string sql, params SqlParameter[] thamSo)
        {
            try
            {
                KetNoiCSDL();
                SqlCommand cmd = new SqlCommand(sql, sqlConnect);
                if (thamSo != null)
                    cmd.Parameters.AddRange(thamSo);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            finally
            {
                DongKetNoiCSDL();
            }
        }

        public object LayGiaTri(string sql, params SqlParameter[] thamSo)
        {
            object kq = null;
            try
            {
                KetNoiCSDL();
                SqlCommand cmd = new SqlCommand(sql, sqlConnect);
                if (thamSo != null)
                    cmd.Parameters.AddRange(thamSo);
                kq = cmd.ExecuteScalar();
                cmd.Dispose();
            }
            finally
            {
                DongKetNoiCSDL();
            }
            return kq;
        }

        public static SqlParameter Tham(string ten, object giaTri)
        {
            if (giaTri == null || (giaTri is string && ((string)giaTri).Trim() == ""))
                return new SqlParameter(ten, DBNull.Value);
            return new SqlParameter(ten, giaTri);
        }

        public bool DaTonTai(string bang, string cot, string giaTri)
        {
            object kq = LayGiaTri("select count(*) from " + bang + " where " + cot + "=@v", Tham("@v", giaTri));
            return Convert.ToInt32(kq) > 0;
        }

        public string SinhMa(string bang, string cot, string tienTo, int soChuSo)
        {
            object kq = LayGiaTri("select max(" + cot + ") from " + bang + " where " + cot + " like @p",
                                  Tham("@p", tienTo + "%"));
            int so = 0;
            if (kq != null && kq != DBNull.Value)
            {
                string s = kq.ToString().Substring(tienTo.Length);
                int.TryParse(s, out so);
            }
            return tienTo + (so + 1).ToString().PadLeft(soChuSo, '0');
        }
    }
}
