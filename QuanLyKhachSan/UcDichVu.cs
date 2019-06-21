using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachSan.DAO;
using DevExpress.LookAndFeel;
using System.Globalization;

namespace QuanLyKhachSan
{
    public partial class UcDichVu : UserControl
    {
        public DichVu dichVuHienTai;
        public UcDichVu(DichVu dv)
        {
            InitializeComponent();
            dichVuHienTai = dv;
            lblGiaDichVu_UcDV.Text = string.Format("{0:0,0}", dv.GiaDV.Value) + " VND";
            lblTenDichVu_UcDV.Text = dv.MoTaDV;
            panelControl1.BackColor = Color.Magenta;
            panelControl1.Appearance.BackColor = Color.LightGreen;
            panelControl1.Appearance.Options.UseBackColor = true;
            panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            panelControl1.LookAndFeel.Style = LookAndFeelStyle.Flat;
        }
        public DevExpress.XtraEditors.PanelControl getPanelThongTinDV()
        {
            return panelControl1;
        }
    }
}
