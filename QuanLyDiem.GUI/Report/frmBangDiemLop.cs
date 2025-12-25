using QuanLyDiem.BLL;
using QuanLyDiem.BLL.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiem.GUI.Report
{
    public partial class frmBangDiemLop : Form
    {
        BangDiemLopBLL bll = new BangDiemLopBLL();
        LopBLL bllLop = new LopBLL();
        NamHocBLL bllNH = new NamHocBLL();
        HocKyBLL bllHK = new HocKyBLL();

        public frmBangDiemLop()
        {
            InitializeComponent();
        }

        private void frmBangDiemLop_Load(object sender, EventArgs e)
        {
            LoadLop();
            LoadNamHoc();
            LoadHocKy();
        }

        private void LoadLop()
        {
            cboLop.DisplayMember = "TenLop";   // hoặc MaLop tùy bạn
            cboLop.ValueMember = "IDLop";
            cboLop.DataSource = bllLop.LayDanhSachLop();
            cboLop.SelectedIndex = -1;
        }

        private void LoadNamHoc()
        {
            cboNamHoc.DataSource = bllNH.LayDanhSachNam();
            cboNamHoc.DisplayMember = "TenNamHoc";
            cboNamHoc.ValueMember = "IDNamHoc";
            cboNamHoc.SelectedIndex = -1;
        }

        private void LoadHocKy()
        {
            cboHocKy.DataSource = bllHK.LayDanhSachHocKy();
            cboHocKy.DisplayMember = "TenHocKy";
            cboHocKy.ValueMember = "IDHocKy";
            cboHocKy.SelectedIndex = -1;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cboLop.SelectedValue == null ||
        cboNamHoc.SelectedValue == null ||
        cboHocKy.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ điều kiện!");
                return;
            }

            int idHocKy = (int)cboHocKy.SelectedValue;

            if (idHocKy == 9) // ===== TỔNG KẾT (LẤY TỪ DB) =====
            {
                DataTable dt = bll.GetBangDiemTongKetNam(
                    (int)cboNamHoc.SelectedValue,
                    (int)cboLop.SelectedValue
                );
                dt.Columns.Add("XepLoai", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    double dtbNam = Convert.ToDouble(row["DTB_Nam"]);
                    row["XepLoai"] = XepLoai(dtbNam);
                }

                dgvBangDiem.DataSource = dt;
                FormatGridTongKet();
            }
            else // ===== HK1 / HK2 =====
            {
                DataTable dt = bll.GetBangDiemLop(
                    (int)cboNamHoc.SelectedValue,
                    idHocKy,
                    (int)cboLop.SelectedValue
                );

                dgvBangDiem.DataSource = TaoBangDiemRutGon(dt);
                FormatGrid();
            }
        }

        private DataTable TaoBangDiemRutGon(DataTable dtNguon)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaHS");
            dt.Columns.Add("HoTen");
            dt.Columns.Add("DiemTB", typeof(double));
            dt.Columns.Add("XepLoai");

            var nhomHocSinh = dtNguon.AsEnumerable()
                .GroupBy(r => new
                {
                    MaHS = r["MaHS"].ToString(),
                    HoTen = r["HoTen"].ToString()
                });

            foreach (var hs in nhomHocSinh)
            {
                double dtb = hs.Average(r => Convert.ToDouble(r["DTB"]));
                dt.Rows.Add(
                    hs.Key.MaHS,
                    hs.Key.HoTen,
                    Math.Round(dtb, 2),
                    XepLoai(dtb)
                );
            }

            return dt;
        }

        private void FormatGrid()
        {
            dgvBangDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBangDiem.RowHeadersVisible = false;

            dgvBangDiem.Columns["MaHS"].HeaderText = "Mã HS";
            dgvBangDiem.Columns["HoTen"].HeaderText = "Họ tên";
            dgvBangDiem.Columns["DiemTB"].HeaderText = "Điểm TB";
            dgvBangDiem.Columns["XepLoai"].HeaderText = "Xếp loại";
        }

        private void FormatGridTongKet()
        {
            dgvBangDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBangDiem.RowHeadersVisible = false;

            dgvBangDiem.Columns["MaHS"].HeaderText = "Mã HS";
            dgvBangDiem.Columns["HoTen"].HeaderText = "Họ tên";
            dgvBangDiem.Columns["DTB_HK1"].HeaderText = "Điểm TB HK1";
            dgvBangDiem.Columns["DTB_HK2"].HeaderText = "Điểm TB HK2";
            dgvBangDiem.Columns["DTB_Nam"].HeaderText = "Điểm TB cả năm";
            dgvBangDiem.Columns["XepLoai"].HeaderText = "Xếp loại";

            dgvBangDiem.Columns["MaHS"].DisplayIndex = 0;
            dgvBangDiem.Columns["HoTen"].DisplayIndex = 1;
            dgvBangDiem.Columns["DTB_HK1"].DisplayIndex = 2;
            dgvBangDiem.Columns["DTB_HK2"].DisplayIndex = 3;
            dgvBangDiem.Columns["DTB_Nam"].DisplayIndex = 4;
            dgvBangDiem.Columns["XepLoai"].DisplayIndex = 5;
        }



        private string XepLoai(double dtb)
        {
            if (dtb >= 8) return "Giỏi";
            if (dtb >= 6.5) return "Khá";
            if (dtb >= 5) return "Trung bình";
            return "Yếu";
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvBangDiem.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel (*.csv)|*.csv";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            using (var sw = new System.IO.StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
            {
                for (int i = 0; i < dgvBangDiem.Columns.Count; i++)
                {
                    sw.Write(dgvBangDiem.Columns[i].HeaderText);
                    if (i < dgvBangDiem.Columns.Count - 1) sw.Write(",");
                }
                sw.WriteLine();

                foreach (DataGridViewRow row in dgvBangDiem.Rows)
                {
                    for (int i = 0; i < dgvBangDiem.Columns.Count; i++)
                    {
                        sw.Write(row.Cells[i].Value);
                        if (i < dgvBangDiem.Columns.Count - 1) sw.Write(",");
                    }
                    sw.WriteLine();
                }
            }

            MessageBox.Show("Xuất Excel thành công!");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvBangDiem.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn học sinh!");
                return;
            }

            string maHS = dgvBangDiem.CurrentRow.Cells["MaHS"].Value.ToString();
            string hoTen = dgvBangDiem.CurrentRow.Cells["HoTen"].Value.ToString();

            frmChiTietBangDiemHocSinh frm = new frmChiTietBangDiemHocSinh(
                maHS,
                hoTen,
                (int)cboNamHoc.SelectedValue,
                (int)cboHocKy.SelectedValue
            );

            frm.ShowDialog();
        }

        private void dgvBangDiem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBangDiem.Columns[e.ColumnIndex].Name == "XepLoai" && e.Value != null)
            {
                if (e.Value.ToString() == "Giỏi")
                    e.CellStyle.ForeColor = Color.Green;
                else if (e.Value.ToString() == "Yếu")
                    e.CellStyle.ForeColor = Color.Red;
            }
        }
    }
}
