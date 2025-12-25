namespace QuanLyDiem.GUI.Report
{
    partial class frmBangDiemLop
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
            this.btnXem = new System.Windows.Forms.Button();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.cboNamHoc = new System.Windows.Forms.ComboBox();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.lblHocKy = new System.Windows.Forms.Label();
            this.lblNamHoc = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.grpBangDiem = new System.Windows.Forms.GroupBox();
            this.dgvBangDiem = new System.Windows.Forms.DataGridView();
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.btnXemChiTiet = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.grpFilter.SuspendLayout();
            this.grpBangDiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).BeginInit();
            this.grpAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.btnXem);
            this.grpFilter.Controls.Add(this.cboHocKy);
            this.grpFilter.Controls.Add(this.cboNamHoc);
            this.grpFilter.Controls.Add(this.cboLop);
            this.grpFilter.Controls.Add(this.lblHocKy);
            this.grpFilter.Controls.Add(this.lblNamHoc);
            this.grpFilter.Controls.Add(this.lblLop);
            this.grpFilter.Location = new System.Drawing.Point(9, 10);
            this.grpFilter.Margin = new System.Windows.Forms.Padding(2);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Padding = new System.Windows.Forms.Padding(2);
            this.grpFilter.Size = new System.Drawing.Size(720, 65);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Bộ lọc";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(615, 24);
            this.btnXem.Margin = new System.Windows.Forms.Padding(2);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 24);
            this.btnXem.TabIndex = 6;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cboHocKy
            // 
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Location = new System.Drawing.Point(480, 27);
            this.cboHocKy.Margin = new System.Windows.Forms.Padding(2);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(114, 21);
            this.cboHocKy.TabIndex = 5;
            // 
            // cboNamHoc
            // 
            this.cboNamHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNamHoc.FormattingEnabled = true;
            this.cboNamHoc.Location = new System.Drawing.Point(292, 27);
            this.cboNamHoc.Margin = new System.Windows.Forms.Padding(2);
            this.cboNamHoc.Name = "cboNamHoc";
            this.cboNamHoc.Size = new System.Drawing.Size(114, 21);
            this.cboNamHoc.TabIndex = 4;
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(68, 27);
            this.cboLop.Margin = new System.Windows.Forms.Padding(2);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(114, 21);
            this.cboLop.TabIndex = 3;
            // 
            // lblHocKy
            // 
            this.lblHocKy.AutoSize = true;
            this.lblHocKy.Location = new System.Drawing.Point(428, 29);
            this.lblHocKy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHocKy.Name = "lblHocKy";
            this.lblHocKy.Size = new System.Drawing.Size(44, 13);
            this.lblHocKy.TabIndex = 2;
            this.lblHocKy.Text = "Học kỳ:";
            // 
            // lblNamHoc
            // 
            this.lblNamHoc.AutoSize = true;
            this.lblNamHoc.Location = new System.Drawing.Point(240, 29);
            this.lblNamHoc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNamHoc.Name = "lblNamHoc";
            this.lblNamHoc.Size = new System.Drawing.Size(53, 13);
            this.lblNamHoc.TabIndex = 1;
            this.lblNamHoc.Text = "Năm học:";
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(15, 29);
            this.lblLop.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(28, 13);
            this.lblLop.TabIndex = 0;
            this.lblLop.Text = "Lớp:";
            // 
            // grpBangDiem
            // 
            this.grpBangDiem.Controls.Add(this.dgvBangDiem);
            this.grpBangDiem.Location = new System.Drawing.Point(9, 81);
            this.grpBangDiem.Margin = new System.Windows.Forms.Padding(2);
            this.grpBangDiem.Name = "grpBangDiem";
            this.grpBangDiem.Padding = new System.Windows.Forms.Padding(2);
            this.grpBangDiem.Size = new System.Drawing.Size(720, 309);
            this.grpBangDiem.TabIndex = 1;
            this.grpBangDiem.TabStop = false;
            this.grpBangDiem.Text = "Bảng điểm lớp";
            // 
            // dgvBangDiem
            // 
            this.dgvBangDiem.AllowUserToAddRows = false;
            this.dgvBangDiem.AllowUserToDeleteRows = false;
            this.dgvBangDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBangDiem.Location = new System.Drawing.Point(2, 15);
            this.dgvBangDiem.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBangDiem.Name = "dgvBangDiem";
            this.dgvBangDiem.ReadOnly = true;
            this.dgvBangDiem.RowHeadersVisible = false;
            this.dgvBangDiem.RowTemplate.Height = 24;
            this.dgvBangDiem.Size = new System.Drawing.Size(716, 292);
            this.dgvBangDiem.TabIndex = 0;
            this.dgvBangDiem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBangDiem_CellFormatting);
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.btnXemChiTiet);
            this.grpAction.Controls.Add(this.btnThoat);
            this.grpAction.Controls.Add(this.btnXuatExcel);
            this.grpAction.Location = new System.Drawing.Point(9, 398);
            this.grpAction.Margin = new System.Windows.Forms.Padding(2);
            this.grpAction.Name = "grpAction";
            this.grpAction.Padding = new System.Windows.Forms.Padding(2);
            this.grpAction.Size = new System.Drawing.Size(720, 57);
            this.grpAction.TabIndex = 2;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "Chức năng";
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.Location = new System.Drawing.Point(124, 20);
            this.btnXemChiTiet.Margin = new System.Windows.Forms.Padding(2);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(90, 24);
            this.btnXemChiTiet.TabIndex = 2;
            this.btnXemChiTiet.Text = "Xem chi tiết";
            this.btnXemChiTiet.UseVisualStyleBackColor = true;
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(615, 20);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 24);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(15, 20);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(90, 24);
            this.btnXuatExcel.TabIndex = 0;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // frmBangDiemLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 467);
            this.Controls.Add(this.grpAction);
            this.Controls.Add(this.grpBangDiem);
            this.Controls.Add(this.grpFilter);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmBangDiemLop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng điểm lớp";
            this.Load += new System.EventHandler(this.frmBangDiemLop_Load);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.grpBangDiem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).EndInit();
            this.grpAction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.ComboBox cboNamHoc;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblHocKy;
        private System.Windows.Forms.Label lblNamHoc;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.GroupBox grpBangDiem;
        private System.Windows.Forms.DataGridView dgvBangDiem;
        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnXemChiTiet;
    }
}
