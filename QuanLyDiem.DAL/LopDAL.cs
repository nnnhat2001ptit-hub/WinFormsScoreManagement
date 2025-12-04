using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiem.DAL
{
    public class LopDAL
    {
        public DataTable GetAll()
        {
            return DbHelper.ExecuteQuery("sp_Lop_GetAll");
        }

        public int Insert(string tenLop, string khoi, int siSo)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@TenLop", tenLop),
                new SqlParameter("@Khoi", khoi),
                new SqlParameter("@SiSo", siSo)
            };

            return DbHelper.ExecuteNonQuery("sp_Lop_Insert", param);
        }

        public int Update(int maLop, string tenLop, string khoi, int siSo)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MaLop", maLop),
                new SqlParameter("@TenLop", tenLop),
                new SqlParameter("@Khoi", khoi),
                new SqlParameter("@SiSo", siSo)
            };

            return DbHelper.ExecuteNonQuery("sp_Lop_Update", param);
        }

        public int Delete(int maLop)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MaLop", maLop)
            };

            return DbHelper.ExecuteNonQuery("sp_Lop_Delete", param);
        }
    }
}
