using QuanLyDiem.GUI.Auth;
using QuanLyDiem.GUI.Model;
using QuanLyDiem.GUI.Point;
using QuanLyDiem.GUI.Report;
using QuanLyDiem.GUI.Teaching;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace QuanLyDiem.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        // Hàm mở form con trong MDI
        private void OpenChildForm(Form childForm)
        {
            // Nếu form này đã mở rồi thì kích hoạt thay vì mở thêm
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType() == childForm.GetType())
                {
                    frm.Activate();
                    return;
                }
            }

            childForm.MdiParent = this;
            childForm.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình?",
                                "Xác nhận", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đăng nhập sẽ được xây dựng sau.",
                           "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất?", "Xác nhận",
        MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Session.Clear();
                this.Hide();

                frmLogin login = new frmLogin();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void mnuHocSinh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHocSinh());
        }

        private void mnuLop_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLop());
        }

        private void mnuMonHoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMonHoc());
        }

        private void mnuGiaoVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGiaoVien());
        }

        private void mnuNamHoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNamHoc());
        }

        private void mnuHocKy_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHocKy());
        }

        private void mnuLoaiDiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLoaiDiem());
        }

        private void mnuPhanCong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPhanCong());
        }

        private void mnuNhapDiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBangDiem());
        }

        private void mnuBangDiemHS_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBangDiemHocSinh());
        }

        private void mnuBangDiemLop_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBangDiemLop());
        }

        private void menuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = $"Xin chào: {Session.TenDangNhap} ({Session.VaiTro})";

            if (Session.VaiTro == "GiaoVien")
            {
                mnuDanhMuc.Enabled = false;
                mnuHeThong.Enabled = false;
            }
        }
    }
}
