namespace QuanLyDiem.GUI.Report
{
    partial class frmBangDiemHocSinh
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.cboNamHoc = new System.Windows.Forms.ComboBox();
            this.cboHocSinh = new System.Windows.Forms.ComboBox();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpHocSinh = new System.Windows.Forms.GroupBox();
            this.dgvHocSinh = new System.Windows.Forms.DataGridView();
            this.grpBangDiem = new System.Windows.Forms.GroupBox();
            this.dgvBangDiem = new System.Windows.Forms.DataGridView();
            this.grpChucNang = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnChiTietMon = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.grpFilter.SuspendLayout();
            this.grpHocSinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocSinh)).BeginInit();
            this.grpBangDiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).BeginInit();
            this.grpChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.cboHocKy);
            this.grpFilter.Controls.Add(this.cboNamHoc);
            this.grpFilter.Controls.Add(this.cboHocSinh);
            this.grpFilter.Controls.Add(this.cboLop);
            this.grpFilter.Controls.Add(this.label4);
            this.grpFilter.Controls.Add(this.label3);
            this.grpFilter.Controls.Add(this.label2);
            this.grpFilter.Controls.Add(this.label1);
            this.grpFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilter.Location = new System.Drawing.Point(20, 15);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(880, 85);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Bộ lọc";
            // 
            // cboHocKy
            // 
            this.cboHocKy.Location = new System.Drawing.Point(740, 27);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(110, 25);
            this.cboHocKy.TabIndex = 0;
            this.cboHocKy.SelectedIndexChanged += new System.EventHandler(this.cboHocKy_SelectedIndexChanged);
            // 
            // cboNamHoc
            // 
            this.cboNamHoc.Location = new System.Drawing.Point(550, 27);
            this.cboNamHoc.Name = "cboNamHoc";
            this.cboNamHoc.Size = new System.Drawing.Size(120, 25);
            this.cboNamHoc.TabIndex = 1;
            this.cboNamHoc.SelectedIndexChanged += new System.EventHandler(this.cboNamHoc_SelectedIndexChanged);
            // 
            // cboHocSinh
            // 
            this.cboHocSinh.Location = new System.Drawing.Point(280, 27);
            this.cboHocSinh.Name = "cboHocSinh";
            this.cboHocSinh.Size = new System.Drawing.Size(180, 25);
            this.cboHocSinh.TabIndex = 2;
            // 
            // cboLop
            // 
            this.cboLop.Location = new System.Drawing.Point(70, 27);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(120, 25);
            this.cboLop.TabIndex = 3;
            this.cboLop.SelectedIndexChanged += new System.EventHandler(this.cboLop_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(690, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Học kỳ :";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(480, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Năm học :";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(210, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Học sinh :";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Lớp :";
            // 
            // grpHocSinh
            // 
            this.grpHocSinh.Controls.Add(this.dgvHocSinh);
            this.grpHocSinh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpHocSinh.Location = new System.Drawing.Point(20, 110);
            this.grpHocSinh.Name = "grpHocSinh";
            this.grpHocSinh.Size = new System.Drawing.Size(880, 180);
            this.grpHocSinh.TabIndex = 1;
            this.grpHocSinh.TabStop = false;
            this.grpHocSinh.Text = "Danh sách học sinh";
            // 
            // dgvHocSinh
            // 
            this.dgvHocSinh.AllowUserToAddRows = false;
            this.dgvHocSinh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHocSinh.Location = new System.Drawing.Point(10, 25);
            this.dgvHocSinh.Name = "dgvHocSinh";
            this.dgvHocSinh.ReadOnly = true;
            this.dgvHocSinh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHocSinh.Size = new System.Drawing.Size(860, 150);
            this.dgvHocSinh.TabIndex = 0;
            this.dgvHocSinh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHocSinh_CellClick);
            this.dgvHocSinh.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHocSinh_CellFormatting);
            // 
            // grpBangDiem
            // 
            this.grpBangDiem.Controls.Add(this.dgvBangDiem);
            this.grpBangDiem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBangDiem.Location = new System.Drawing.Point(20, 300);
            this.grpBangDiem.Name = "grpBangDiem";
            this.grpBangDiem.Size = new System.Drawing.Size(880, 260);
            this.grpBangDiem.TabIndex = 2;
            this.grpBangDiem.TabStop = false;
            this.grpBangDiem.Text = "Bảng điểm";
            // 
            // dgvBangDiem
            // 
            this.dgvBangDiem.AllowUserToAddRows = false;
            this.dgvBangDiem.Location = new System.Drawing.Point(10, 25);
            this.dgvBangDiem.Name = "dgvBangDiem";
            this.dgvBangDiem.ReadOnly = true;
            this.dgvBangDiem.Size = new System.Drawing.Size(860, 230);
            this.dgvBangDiem.TabIndex = 0;
            this.dgvBangDiem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBangDiem_CellDoubleClick);
            // 
            // grpChucNang
            // 
            this.grpChucNang.Controls.Add(this.btnThoat);
            this.grpChucNang.Controls.Add(this.btnXuatExcel);
            this.grpChucNang.Controls.Add(this.btnChiTietMon);
            this.grpChucNang.Controls.Add(this.btnXem);
            this.grpChucNang.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.grpChucNang.Location = new System.Drawing.Point(20, 570);
            this.grpChucNang.Name = "grpChucNang";
            this.grpChucNang.Size = new System.Drawing.Size(880, 70);
            this.grpChucNang.TabIndex = 3;
            this.grpChucNang.TabStop = false;
            this.grpChucNang.Text = "Chức năng";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(740, 28);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(105, 28);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(300, 28);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(110, 28);
            this.btnXuatExcel.TabIndex = 1;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnChiTietMon
            // 
            this.btnChiTietMon.Location = new System.Drawing.Point(160, 28);
            this.btnChiTietMon.Name = "btnChiTietMon";
            this.btnChiTietMon.Size = new System.Drawing.Size(120, 28);
            this.btnChiTietMon.TabIndex = 2;
            this.btnChiTietMon.Text = "Chi tiết môn";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(40, 28);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(95, 28);
            this.btnXem.TabIndex = 3;
            this.btnXem.Text = "Xem";
            // 
            // frmBangDiemHocSinh
            // 
            this.ClientSize = new System.Drawing.Size(920, 660);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.grpHocSinh);
            this.Controls.Add(this.grpBangDiem);
            this.Controls.Add(this.grpChucNang);
            this.Name = "frmBangDiemHocSinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng điểm học sinh";
            this.Load += new System.EventHandler(this.frmBangDiemHocSinh_Load);
            this.grpFilter.ResumeLayout(false);
            this.grpHocSinh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocSinh)).EndInit();
            this.grpBangDiem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).EndInit();
            this.grpChucNang.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.ComboBox cboHocSinh;
        private System.Windows.Forms.ComboBox cboNamHoc;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.GroupBox grpHocSinh;
        private System.Windows.Forms.DataGridView dgvHocSinh;

        private System.Windows.Forms.GroupBox grpBangDiem;
        private System.Windows.Forms.DataGridView dgvBangDiem;

        private System.Windows.Forms.GroupBox grpChucNang;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnChiTietMon;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnThoat;
    }
}
