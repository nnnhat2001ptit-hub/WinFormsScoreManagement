using System;
using System.Data;
using System.Linq;
using QuanLyDiem.DAL.Report;

namespace QuanLyDiem.BLL.Report
{
    public class BangDiemLopBLL
    {
        BangDiemLopDAL dal = new BangDiemLopDAL();

        public DataTable GetBangDiemLop(int idNamHoc, int idHocKy, int idLop)
        {
            DataTable raw = dal.GetBangDiemLop(idNamHoc, idHocKy, idLop);
            DataTable tb = new DataTable();

            tb.Columns.Add("MaHS");
            tb.Columns.Add("HoTen");

            var monHoc = raw.AsEnumerable()
                            .Select(r => r["TenMon"].ToString())
                            .Distinct()
                            .ToList();

            foreach (var mon in monHoc)
                tb.Columns.Add(mon, typeof(double));

            tb.Columns.Add("DTB", typeof(double));
            tb.Columns.Add("XepLoai");

            var hsGroup = raw.AsEnumerable()
                             .GroupBy(r => new
                             {
                                 MaHS = r["MaHS"].ToString(),
                                 HoTen = r["HoTen"].ToString()
                             });

            foreach (var hs in hsGroup)
            {
                DataRow row = tb.NewRow();
                row["MaHS"] = hs.Key.MaHS;
                row["HoTen"] = hs.Key.HoTen;

                double tong = 0;
                int dem = 0;

                foreach (var mon in monHoc)
                {
                    var diemMon = hs.Where(x => x["TenMon"].ToString() == mon);
                    if (diemMon.Any())
                    {
                        double tbMon = diemMon.Sum(x => Convert.ToDouble(x["Diem"]) * Convert.ToInt32(x["HeSo"]))
                                      / diemMon.Sum(x => Convert.ToInt32(x["HeSo"]));

                        tbMon = Math.Round(tbMon, 2);
                        row[mon] = tbMon;
                        tong += tbMon;
                        dem++;
                    }
                }

                double dtb = dem > 0 ? Math.Round(tong / dem, 2) : 0;
                row["DTB"] = dtb;
                row["XepLoai"] = XepLoai(dtb);

                tb.Rows.Add(row);
            }

            return tb;
        }

        private string XepLoai(double dtb)
        {
            if (dtb >= 8) return "Giỏi";
            if (dtb >= 6.5) return "Khá";
            if (dtb >= 5) return "Trung bình";
            return "Yếu";
        }
    }
}
