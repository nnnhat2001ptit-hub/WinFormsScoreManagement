using QuanLyDiem.BLL;
using QuanLyDiem.BLL.Category;
using QuanLyDiem.BLL.Point;
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
using Excel = Microsoft.Office.Interop.Excel;


namespace QuanLyDiem.GUI.Report
{
    public partial class frmBangDiemHocSinh : Form
    {
        BangDiemHocSinhBLL bll = new BangDiemHocSinhBLL();
        NamHocBLL bllNH = new NamHocBLL();
        HocKyBLL bllHK = new HocKyBLL();

        int selectedIDLop = 0;
        int selectedIDHS = 0;
        public frmBangDiemHocSinh()
        {
            InitializeComponent();
        }

        private void frmBangDiemHocSinh_Load(object sender, EventArgs e)
        {
            LoadLop();
            LoadNamHoc();
            LoadHocKy();

            dgvHocSinh.ClearSelection();
            dgvBangDiem.ClearSelection();
        }

        private void LoadLop()
        {
            cboLop.DisplayMember = "TenLop";   // hoặc MaLop tùy bạn
            cboLop.ValueMember = "IDLop";
            cboLop.DataSource = bll.LayDanhSachLop();
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

        private void LoadHocSinh()
        {
            if (cboLop.SelectedValue == null) return;

            DataTable dt = bll.LayHocSinhTheoLop(Convert.ToInt32(cboLop.SelectedValue));

            cboHocSinh.DataSource = dt;
            cboHocSinh.DisplayMember = "HoTen";
            cboHocSinh.ValueMember = "IDHS";
            cboHocSinh.SelectedIndex = -1;
        }


        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLop.SelectedValue == null) return;

            LoadHocSinh();

            selectedIDLop = Convert.ToInt32(cboLop.SelectedValue);

            dgvHocSinh.DataSource = bll.LayHocSinhTheoLop(selectedIDLop);
            FormatDanhSachHocSinh();


            dgvHocSinh.Columns["IDHS"].Visible = false;
            dgvHocSinh.Columns["MaHS"].HeaderText = "Mã HS";
            dgvHocSinh.Columns["HoTen"].HeaderText = "Họ tên";
            dgvHocSinh.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvHocSinh.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvHocSinh.Columns["TenLop"].HeaderText = "Lớp";

            dgvHocSinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FormatDanhSachHocSinh()
        {
            // Ẩn các cột ID
            dgvHocSinh.Columns["IDHS"].Visible = false;
            if (dgvHocSinh.Columns.Contains("IDLop"))
                dgvHocSinh.Columns["IDLop"].Visible = false;


            // Hiển thị tên cột
            dgvHocSinh.Columns["MaHS"].HeaderText = "Mã HS";
            dgvHocSinh.Columns["HoTen"].HeaderText = "Họ tên";
            dgvHocSinh.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvHocSinh.Columns.Remove("GioiTinh");

            DataGridViewTextBoxColumn colGT = new DataGridViewTextBoxColumn();
            colGT.Name = "GioiTinh";
            colGT.HeaderText = "Giới tính";
            colGT.DataPropertyName = "GioiTinh";
            dgvHocSinh.Columns.Add(colGT);
            dgvHocSinh.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvHocSinh.Columns["TenLop"].HeaderText = "Lớp";

    

            // Set thứ tự cột
            dgvHocSinh.Columns["MaHS"].DisplayIndex = 0;
            dgvHocSinh.Columns["HoTen"].DisplayIndex = 1;
            dgvHocSinh.Columns["NgaySinh"].DisplayIndex = 2;
            dgvHocSinh.Columns["GioiTinh"].DisplayIndex = 3;
            dgvHocSinh.Columns["DiaChi"].DisplayIndex = 4;
            dgvHocSinh.Columns["TenLop"].DisplayIndex = 5;

            // Căn chỉnh
            dgvHocSinh.Columns["MaHS"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHocSinh.Columns["HoTen"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvHocSinh.Columns["NgaySinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHocSinh.Columns["GioiTinh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHocSinh.Columns["DiaChi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvHocSinh.Columns["TenLop"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvHocSinh.RowHeadersVisible = false;
        }


        private void dgvHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedIDHS = Convert.ToInt32(dgvHocSinh.Rows[e.RowIndex].Cells["IDHS"].Value);

            LoadBangDiem();
        }

        private void LoadBangDiem()
        {
            if (selectedIDHS == 0 ||
                cboNamHoc.SelectedValue == null ||
                cboHocKy.SelectedValue == null) return;

            dgvBangDiem.DataSource = bll.LayBangDiemHocSinh(
                selectedIDHS,
                Convert.ToInt32(cboNamHoc.SelectedValue),
                Convert.ToInt32(cboHocKy.SelectedValue)
            );

            if (dgvBangDiem.DataSource == null) return;

            //dgvBangDiem.Columns["IDBangDiem"].Visible = false;
            dgvBangDiem.Columns["IDHS"].Visible = false;
            dgvBangDiem.Columns["IDMon"].Visible = false;
            dgvBangDiem.Columns["IDNamHoc"].Visible = false;
            dgvBangDiem.Columns["IDHocKy"].Visible = false;
            dgvBangDiem.Columns["IDLoaiDiem"].Visible = false;

            dgvBangDiem.Columns["TenMon"].HeaderText = "Môn học";
            dgvBangDiem.Columns["TenLoaiDiem"].HeaderText = "Loại điểm";
            dgvBangDiem.Columns["Diem"].HeaderText = "Điểm";
            dgvBangDiem.Columns["NgayNhap"].HeaderText = "Ngày nhập";

            dgvBangDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBangDiem();
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBangDiem();
        }

        private void dgvBangDiem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string mon = dgvBangDiem.Rows[e.RowIndex].Cells["TenMon"].Value.ToString();
            string loai = dgvBangDiem.Rows[e.RowIndex].Cells["TenLoaiDiem"].Value.ToString();
            string diem = dgvBangDiem.Rows[e.RowIndex].Cells["Diem"].Value.ToString();

            MessageBox.Show(
                $"Môn: {mon}\nLoại điểm: {loai}\nĐiểm: {diem}",
                "Chi tiết điểm",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvBangDiem.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel!");
                return;
            }

            Excel.Application app = new Excel.Application();
            app.Visible = true;

            Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
            Excel.Worksheet ws = (Excel.Worksheet)wb.ActiveSheet;

            ws.Name = "Bảng điểm học sinh";

            // Tiêu đề
            for (int i = 1; i <= dgvBangDiem.Columns.Count; i++)
            {
                ws.Cells[1, i] = dgvBangDiem.Columns[i - 1].HeaderText;
            }

            // Dữ liệu
            for (int i = 0; i < dgvBangDiem.Rows.Count; i++)
            {
                for (int j = 0; j < dgvBangDiem.Columns.Count; j++)
                {
                    ws.Cells[i + 2, j + 1] = dgvBangDiem.Rows[i].Cells[j].Value?.ToString();
                }
            }

            MessageBox.Show("Xuất Excel thành công!");
        }

        private void dgvHocSinh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHocSinh.Columns[e.ColumnIndex].Name == "GioiTinh")
            {
                if (e.Value != null && e.Value is bool)
                {
                    bool gt = (bool)e.Value;
                    e.Value = gt ? "Nam" : "Nữ";
                    e.FormattingApplied = true;
                }
            }

        }
    }
}
