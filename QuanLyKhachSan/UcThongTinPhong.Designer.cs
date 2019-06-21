namespace QuanLyKhachSan
{
    partial class UcThongTinPhong
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcThongTinPhong));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnTipInfo = new DevExpress.XtraEditors.SimpleButton();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.lblPhong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnTipInfo);
            this.panelControl1.Controls.Add(this.lblTinhTrang);
            this.panelControl1.Controls.Add(this.lblPhong);
            this.panelControl1.Location = new System.Drawing.Point(14, 13);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(110, 84);
            this.panelControl1.TabIndex = 0;
            // 
            // btnTipInfo
            // 
            this.btnTipInfo.Appearance.Font = new System.Drawing.Font("Century", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTipInfo.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnTipInfo.Appearance.Options.UseFont = true;
            this.btnTipInfo.Appearance.Options.UseForeColor = true;
            this.btnTipInfo.Location = new System.Drawing.Point(45, 56);
            this.btnTipInfo.Name = "btnTipInfo";
            this.btnTipInfo.Size = new System.Drawing.Size(25, 23);
            this.btnTipInfo.TabIndex = 3;
            this.btnTipInfo.Text = "i";
            this.btnTipInfo.ToolTipController = this.toolTipController1;
            // 
            // toolTipController1
            // 
            this.toolTipController1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("toolTipController1.Appearance.Image")));
            this.toolTipController1.Appearance.Options.UseFont = true;
            this.toolTipController1.Appearance.Options.UseImage = true;
            this.toolTipController1.InitialDelay = 100;
            this.toolTipController1.Rounded = true;
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTinhTrang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblTinhTrang.Location = new System.Drawing.Point(5, 35);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(100, 13);
            this.lblTinhTrang.TabIndex = 1;
            this.lblTinhTrang.Text = "status";
            this.lblTinhTrang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPhong
            // 
            this.lblPhong.BackColor = System.Drawing.Color.Transparent;
            this.lblPhong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPhong.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhong.ForeColor = System.Drawing.Color.Red;
            this.lblPhong.Location = new System.Drawing.Point(36, 12);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(40, 14);
            this.lblPhong.TabIndex = 0;
            this.lblPhong.Text = "ANNN";
            this.lblPhong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UcThongTinPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.Controls.Add(this.panelControl1);
            this.Name = "UcThongTinPhong";
            this.Size = new System.Drawing.Size(138, 110);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.Label lblPhong;
        private DevExpress.XtraEditors.SimpleButton btnTipInfo;
        private DevExpress.Utils.ToolTipController toolTipController1;
    }
}
