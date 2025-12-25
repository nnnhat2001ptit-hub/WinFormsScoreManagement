using QuanLyDiem.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiem.GUI
{
    public partial class frmHocSinh : Form
    {
        HocSinhBLL bll = new HocSinhBLL();
        private bool isAdding = false;
        DataTable dtHocSinh = null;

        public frmHocSinh()
        {
            InitializeComponent();
        }

        private void frmHocSinh_Load(object sender, EventArgs e)
        {
            LoadLop();
            LoadHS();
            SetControls(false);

            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";

            LoadSearchLop();


            dgvHocSinh.DataError += dgvHocSinh_DataError;
        }

        private void LoadLop()
        {
            cboLop.DataSource = bll.LayDanhSachLop();
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "IDLop";     
            cboLop.SelectedIndex = -1;
        }

        private void LoadHS()
        {
            dtHocSinh = bll.LayDanhSachHS();
            dgvHocSinh.DataSource = dtHocSinh;

            dgvHocSinh.Columns["IDHS"].Visible = false;   
            dgvHocSinh.Columns["MaHS"].HeaderText = "Mã HS";
            dgvHocSinh.Columns["HoTen"].HeaderText = "Họ tên";
            dgvHocSinh.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvHocSinh.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvHocSinh.Columns.Remove("GioiTinh");

            DataGridViewTextBoxColumn colGT = new DataGridViewTextBoxColumn();
            colGT.Name = "GioiTinh";
            colGT.HeaderText = "Giới tính";
            colGT.DataPropertyName = "GioiTinh"; 
            dgvHocSinh.Columns.Add(colGT);


            dgvHocSinh.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvHocSinh.Columns["IDLop"].Visible = false;
            dgvHocSinh.Columns["TenLop"].HeaderText = "Lớp";

            dgvHocSinh.Columns["MaHS"].DisplayIndex = 0;
            dgvHocSinh.Columns["HoTen"].DisplayIndex = 1;
            dgvHocSinh.Columns["NgaySinh"].DisplayIndex = 2;
            dgvHocSinh.Columns["GioiTinh"].DisplayIndex = 3;   
            dgvHocSinh.Columns["DiaChi"].DisplayIndex = 4;
            dgvHocSinh.Columns["TenLop"].DisplayIndex = 5;

            dgvHocSinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetControls(bool editing)
        {
            txtMaHS.Enabled = editing;
            txtHoTen.Enabled = editing;
            dtpNgaySinh.Enabled = editing;
            radNam.Enabled = editing;
            radNu.Enabled = editing;
            txtDiaChi.Enabled = editing;
            cboLop.Enabled = editing;

            btnThem.Enabled = !editing;
            btnSua.Enabled = !editing;
            btnXoa.Enabled = !editing;

            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;
        }

        private void ClearInputs()
        {
            txtIDHS.Text = "";
            txtMaHS.Text = "";
            txtHoTen.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            radNam.Checked = true;
            txtDiaChi.Text = "";
            cboLop.SelectedIndex = -1;
        }

        private void dgvHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtIDHS.Text = dgvHocSinh.CurrentRow.Cells["IDHS"].Value.ToString();
                txtMaHS.Text = dgvHocSinh.CurrentRow.Cells["MaHS"].Value.ToString();
                txtHoTen.Text = dgvHocSinh.CurrentRow.Cells["HoTen"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(dgvHocSinh.CurrentRow.Cells["NgaySinh"].Value);

                bool gt = Convert.ToBoolean(dgvHocSinh.CurrentRow.Cells["GioiTinh"].Value);
                radNam.Checked = gt;
                radNu.Checked = !gt;

                txtDiaChi.Text = dgvHocSinh.CurrentRow.Cells["DiaChi"].Value.ToString();
                cboLop.SelectedValue = dgvHocSinh.CurrentRow.Cells["IDLop"].Value;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearInputs();
            SetControls(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIDHS.Text))
            {
                MessageBox.Show("Hãy chọn học sinh muốn sửa!");
                return;
            }
            isAdding = false;
            SetControls(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIDHS.Text))
            {
                MessageBox.Show("Hãy chọn học sinh muốn xoá!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xoá?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string error;
                int id = int.Parse(txtIDHS.Text);

                if (bll.Xoa(id, out error))
                {
                    MessageBox.Show("Xoá thành công!");
                    LoadHS();
                }
                else
                {
                    MessageBox.Show("Lỗi: " + error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maHS = txtMaHS.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            DateTime ngaySinh = dtpNgaySinh.Value;
            bool gioiTinh = radNam.Checked;
            string diaChi = txtDiaChi.Text.Trim();
            int idLop = (cboLop.SelectedValue == null) ? -1 : (int)cboLop.SelectedValue;

            string error;
            bool success;

            if (isAdding)
            {
                success = bll.Them(maHS, hoTen, ngaySinh, gioiTinh, diaChi, idLop, out error);
            }
            else
            {
                int idHS = int.Parse(txtIDHS.Text);
                success = bll.Sua(idHS, maHS, hoTen, ngaySinh, gioiTinh, diaChi, idLop, out error);
            }

            if (success)
            {
                MessageBox.Show("Lưu thành công!");
                LoadHS();
                SetControls(false);
            }
            else
            {
                MessageBox.Show(error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetControls(false);
            if (dgvHocSinh.Rows.Count > 0)
                dgvHocSinh_CellClick(null, new DataGridViewCellEventArgs(0, dgvHocSinh.CurrentRow.Index));
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void dgvHocSinh_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void FilterHocSinh()
        {
            if (dtHocSinh == null) return;

            string ma = txtSearchMaHS.Text.Trim().Replace("'", "''");
            string ten = txtSearchTenHS.Text.Trim().Replace("'", "''");
            string lop = "";

            if (cboSearchLop.SelectedValue != null &&
                cboSearchLop.SelectedValue != DBNull.Value &&
                cboSearchLop.SelectedValue is int)
            {
                lop = cboSearchLop.SelectedValue.ToString();
            }


            List<string> filters = new List<string>();

            if (!string.IsNullOrEmpty(ma))
                filters.Add($"MaHS LIKE '%{ma}%'");

            if (!string.IsNullOrEmpty(ten))
                filters.Add($"HoTen LIKE '%{ten}%'");

            if (!string.IsNullOrEmpty(lop))
                filters.Add($"IDLop = {lop}");

            DataView dv = new DataView(dtHocSinh);
            dv.RowFilter = string.Join(" AND ", filters);

            dgvHocSinh.DataSource = dv;
        }

        private void txtSearchMaHS_TextChanged(object sender, EventArgs e)
        {
            FilterHocSinh();
        }

        private void txtSearchTenHS_TextChanged(object sender, EventArgs e)
        {
            FilterHocSinh();
        }

        private void cboSearchLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterHocSinh();
        }


        private void LoadSearchLop()
        {
            DataTable dtLop = bll.LayDanhSachLop();

            DataRow rowAll = dtLop.NewRow();
            rowAll["IDLop"] = DBNull.Value;   
            rowAll["TenLop"] = "Tất cả";
            dtLop.Rows.InsertAt(rowAll, 0);

            cboSearchLop.DataSource = dtLop;
            cboSearchLop.DisplayMember = "TenLop";
            cboSearchLop.ValueMember = "IDLop";
            cboSearchLop.SelectedIndex = 0; 
        }

    }
}
