using System.Data;
using QuanLyDiem.DAL.System;

namespace QuanLyDiem.BLL.System
{
    public class TaiKhoanBLL
    {
        TaiKhoanDAL dal = new TaiKhoanDAL();

        public DataRow DangNhap(string tenDN, string matKhau)
        {
            DataTable dt = dal.DangNhap(tenDN, matKhau);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
    }
}
