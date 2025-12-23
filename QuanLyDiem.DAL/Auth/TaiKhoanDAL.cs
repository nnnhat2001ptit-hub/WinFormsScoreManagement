using System.Data;
using System.Data.SqlClient;

namespace QuanLyDiem.DAL.System
{
    public class TaiKhoanDAL
    {
        public DataTable DangNhap(string tenDangNhap, string matKhau)
        {
            SqlParameter[] p =
            {
        new SqlParameter("@TenDangNhap", tenDangNhap),
        new SqlParameter("@MatKhau", matKhau)
    };

            return DbHelper.ExecuteQuery("sp_TaiKhoan_Login", p);
        }

    }
}
