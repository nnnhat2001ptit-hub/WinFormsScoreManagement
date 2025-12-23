using QuanLyDiem.BLL.System;
using QuanLyDiem.GUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiem.GUI.Auth
{
    public partial class frmLogin : Form
    {
        TaiKhoanBLL bll = new TaiKhoanBLL();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTenDangNhap.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            var row = bll.DangNhap(user, pass);
            if (row == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                return;
            }

            // Lưu session
            Session.IDTK = Convert.ToInt32(row["IDTK"]);
            Session.TenDangNhap = row["TenDangNhap"].ToString();
            Session.VaiTro = row["VaiTro"].ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
