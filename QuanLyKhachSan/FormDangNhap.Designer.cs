namespace QuanLyKhachSan
{
    partial class FormDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_maNhanVien = new System.Windows.Forms.TextBox();
            this.txt_MatKhau = new System.Windows.Forms.TextBox();
            this.lblTenNhanVien = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // txt_maNhanVien
            // 
            this.txt_maNhanVien.BackColor = System.Drawing.Color.LightGray;
            this.txt_maNhanVien.Location = new System.Drawing.Point(136, 68);
            this.txt_maNhanVien.Name = "txt_maNhanVien";
            this.txt_maNhanVien.Size = new System.Drawing.Size(194, 20);
            this.txt_maNhanVien.TabIndex = 0;
            this.txt_maNhanVien.Text = "EB110";
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_MatKhau.Location = new System.Drawing.Point(136, 112);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.PasswordChar = '*';
            this.txt_MatKhau.Size = new System.Drawing.Size(194, 20);
            this.txt_MatKhau.TabIndex = 1;
            this.txt_MatKhau.Text = "1234";
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.AutoSize = true;
            this.lblTenNhanVien.Location = new System.Drawing.Point(25, 71);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(75, 13);
            this.lblTenNhanVien.TabIndex = 2;
            this.lblTenNhanVien.Text = "Mã Nhân Viên";
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.Location = new System.Drawing.Point(25, 115);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(53, 13);
            this.lblMatKhau.TabIndex = 3;
            this.lblMatKhau.Text = "Mật Khẩu";
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.Location = new System.Drawing.Point(136, 170);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(194, 28);
            this.btnDangNhap.TabIndex = 4;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.ForeColor = System.Drawing.Color.Red;
            this.lblThongBao.Location = new System.Drawing.Point(123, 23);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(0, 13);
            this.lblThongBao.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(49, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(269, 19);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Chương Trình Quản Lý Khách Sạn";
            // 
            // FormDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(376, 244);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.lblTenNhanVien);
            this.Controls.Add(this.txt_MatKhau);
            this.Controls.Add(this.txt_maNhanVien);
            this.Name = "FormDangNhap";
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_maNhanVien;
        private System.Windows.Forms.TextBox txt_MatKhau;
        private System.Windows.Forms.Label lblTenNhanVien;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Label lblThongBao;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}

