using QuanLyDiem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiem.BLL
{
    public class LopBLL
    {
        LopDAL dal = new LopDAL();

        public DataTable LayDanhSachLop()
        {
            return dal.GetAll();
        }

        public bool Them(string tenLop, string khoi, int siSo, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(tenLop))
            {
                error = "Tên lớp không được để trống!";
                return false;
            }

            if (siSo < 0)
            {
                error = "Sĩ số không hợp lệ!";
                return false;
            }

            return dal.Insert(tenLop, khoi, siSo) > 0;
        }

        public bool Sua(int maLop, string tenLop, string khoi, int siSo, out string error)
        {
            error = "";

            if (maLop <= 0)
            {
                error = "Mã lớp không hợp lệ!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(tenLop))
            {
                error = "Tên lớp không được để trống!";
                return false;
            }

            return dal.Update(maLop, tenLop, khoi, siSo) > 0;
        }

        public bool Xoa(int maLop, out string error)
        {
            error = "";

            if (maLop <= 0)
            {
                error = "Mã lớp không hợp lệ!";
                return false;
            }

            return dal.Delete(maLop) > 0;
        }
    }
}
