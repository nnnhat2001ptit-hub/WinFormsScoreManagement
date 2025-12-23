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

            dgvBangDiem.DataSource = bll.GetBangDiemLop(
                (int)cboNamHoc.SelectedValue,
                (int)cboHocKy.SelectedValue,
                (int)cboLop.SelectedValue
            );

            dgvBangDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBangDiem.RowHeadersVisible = false;
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
    }
}
