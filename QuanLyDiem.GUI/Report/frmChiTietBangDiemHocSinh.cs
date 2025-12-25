using QuanLyDiem.BLL.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiem.GUI.Report
{
    public partial class frmChiTietBangDiemHocSinh : Form
    {
        string _maHS;
        int _namHoc;
        int _hocKy;

        BangDiemHocSinhBLL bll = new BangDiemHocSinhBLL();

        public frmChiTietBangDiemHocSinh(string maHS, string hoTen, int namHoc, int hocKy)
        {
            InitializeComponent();
            _maHS = maHS;
            _namHoc = namHoc;
            _hocKy = hocKy;

            if (hocKy == 9)
                lblHocSinh.Text = $"Học sinh: {hoTen} ({maHS}) - Tổng kết năm";
            else if (hocKy == 7)
                lblHocSinh.Text = $"Học sinh: {hoTen} ({maHS}) - HK1";
            else if (hocKy == 8)
                lblHocSinh.Text = $"Học sinh: {hoTen} ({maHS}) - HK2";
            else
                lblHocSinh.Text = $"Học sinh: {hoTen} ({maHS})";


        }

        private void LoadChiTiet()
        {
            DataTable dt;

            if (_hocKy == 9)
            {
                // ===== TỔNG KẾT =====
                dt = bll.GetBangDiemChiTietTongKetHocSinh(_maHS, _namHoc);
                dgvChiTiet.DataSource = dt;
                FormatGridTongKet();
            }
            else
            {
                // ===== HK1 / HK2 =====
                dt = bll.GetBangDiemChiTietHocSinh(_maHS, _namHoc, _hocKy);
                dgvChiTiet.DataSource = dt;
                FormatGridHocKy();
            }
        }

        private void FormatGridHocKy()
        {
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.RowHeadersVisible = false;

            dgvChiTiet.Columns["TenMon"].HeaderText = "Môn";
            dgvChiTiet.Columns["DiemMieng"].HeaderText = "Miệng";
            dgvChiTiet.Columns["Diem15Phut"].HeaderText = "15 phút";
            dgvChiTiet.Columns["Diem1Tiet"].HeaderText = "1 tiết";
            dgvChiTiet.Columns["DiemGiuaKy"].HeaderText = "Giữa kỳ";
            dgvChiTiet.Columns["DiemCuoiKy"].HeaderText = "Cuối kỳ";
            dgvChiTiet.Columns["DiemTBMon"].HeaderText = "Điểm TB";
        }

        private void FormatGridTongKet()
        {
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.RowHeadersVisible = false;

            dgvChiTiet.Columns["TenMon"].HeaderText = "Môn";
            dgvChiTiet.Columns["DTB_HK1"].HeaderText = "Điểm TB HK1";
            dgvChiTiet.Columns["DTB_HK2"].HeaderText = "Điểm TB HK2";
            dgvChiTiet.Columns["DTB_Nam"].HeaderText = "Điểm TB cả năm";
        }


        private void FormatGrid()
        {
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.RowHeadersVisible = false;

            dgvChiTiet.Columns["TenMon"].HeaderText = "Môn";
            dgvChiTiet.Columns["DiemMieng"].HeaderText = "Miệng";
            dgvChiTiet.Columns["Diem15Phut"].HeaderText = "15 phút";
            dgvChiTiet.Columns["Diem1Tiet"].HeaderText = "1 tiết";
            dgvChiTiet.Columns["DiemGiuaKy"].HeaderText = "Giữa kỳ";
            dgvChiTiet.Columns["DiemCuoiKy"].HeaderText = "Cuối kỳ";
            dgvChiTiet.Columns["DiemTBMon"].HeaderText = "Điểm TB";

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChiTietBangDiemHocSinh_Load(object sender, EventArgs e)
        {
            LoadChiTiet();
        }
    }
}
