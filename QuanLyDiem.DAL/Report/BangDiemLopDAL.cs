using System.Data;
using System.Data.SqlClient;

namespace QuanLyDiem.DAL.Report
{
    public class BangDiemLopDAL
    {
        public DataTable GetBangDiemLop(int idNamHoc, int idHocKy, int idLop)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@IDNamHoc", idNamHoc),
                new SqlParameter("@IDHocKy", idHocKy),
                new SqlParameter("@IDLop", idLop)
            };

            return DbHelper.ExecuteQuery("sp_BaoCao_BangDiemLop", p);
        }

        public DataTable GetBangDiemTongKetNam(int idNamHoc, int idLop)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@IDNamHoc", idNamHoc),
                new SqlParameter("@IDLop", idLop)
            };

            return DbHelper.ExecuteQuery("sp_BaoCao_BangDiemTongKetNam", p);
        }
    }
}
