using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiem.GUI.Model
{
    public static class Session
    {
        public static int IDTK { get; set; }
        public static string TenDangNhap { get; set; }
        public static string VaiTro { get; set; }
        public static string HoTen { get; set; }

        public static void Clear()
        {
            IDTK = 0;
            TenDangNhap = null;
            VaiTro = null;
            HoTen = null;
        }
    }
}
