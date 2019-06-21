namespace QuanLyKhachSan
{
    partial class UcDichVu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcDichVu));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblTenDichVu_UcDV = new DevExpress.XtraEditors.LabelControl();
            this.lblGiaDichVu_UcDV = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.LightGreen;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lblTenDichVu_UcDV);
            this.panelControl1.Controls.Add(this.lblGiaDichVu_UcDV);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(323, 77);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("labelControl1.Appearance.Image")));
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(25, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 49);
            this.labelControl1.TabIndex = 2;
            // 
            // lblTenDichVu_UcDV
            // 
            this.lblTenDichVu_UcDV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTenDichVu_UcDV.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTenDichVu_UcDV.Appearance.ForeColor = System.Drawing.Color.SlateBlue;
            this.lblTenDichVu_UcDV.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTenDichVu_UcDV.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblTenDichVu_UcDV.Location = new System.Drawing.Point(164, 14);
            this.lblTenDichVu_UcDV.Name = "lblTenDichVu_UcDV";
            this.lblTenDichVu_UcDV.Size = new System.Drawing.Size(77, 17);
            this.lblTenDichVu_UcDV.TabIndex = 0;
            this.lblTenDichVu_UcDV.Text = "Dọn phòng";
            // 
            // lblGiaDichVu_UcDV
            // 
            this.lblGiaDichVu_UcDV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGiaDichVu_UcDV.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.lblGiaDichVu_UcDV.Appearance.ForeColor = System.Drawing.Color.Magenta;
            this.lblGiaDichVu_UcDV.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblGiaDichVu_UcDV.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lblGiaDichVu_UcDV.Location = new System.Drawing.Point(147, 39);
            this.lblGiaDichVu_UcDV.Name = "lblGiaDichVu_UcDV";
            this.lblGiaDichVu_UcDV.Size = new System.Drawing.Size(104, 24);
            this.lblGiaDichVu_UcDV.TabIndex = 1;
            this.lblGiaDichVu_UcDV.Text = "10000000";
            // 
            // UcDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.Controls.Add(this.panelControl1);
            this.Name = "UcDichVu";
            this.Size = new System.Drawing.Size(323, 77);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblTenDichVu_UcDV;
        private DevExpress.XtraEditors.LabelControl lblGiaDichVu_UcDV;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
