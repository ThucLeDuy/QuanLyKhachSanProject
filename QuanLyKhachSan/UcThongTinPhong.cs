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
using QuanLyKhachSan.BUS;

namespace QuanLyKhachSan
{
    public partial class UcThongTinPhong : UserControl
    {
        public Phong phongHienTai;
        public UcThongTinPhong(Phong phong)
        {
            InitializeComponent();
            phongHienTai = phong;
            btnTipInfo.ToolTip = "- Phòng " + phong.SoPhong + "\n"
                                + "- Loại " + phong.TenPhong + "\n"
                                + "- Tầng " + phong.SoTang + "\n"
                                + "- Sức chứa " + phong.SucChua + "\n"
                                + "- Giá 1 ngày " + phong.GiaTrenNgay + "\n"
                                + "- Giá qua đêm " + phong.GiaQuaDem + "\n";
            lblPhong.Text = phong.SoPhong;
            lblTinhTrang.Text = LayTinhTrangPhongQuaSo(Convert.ToInt16(phong.TinhTrang));

            this.BackColor = Color.LightSalmon;
            if (phong.TinhTrang == 0)
            {
                this.BackColor = Color.PaleGreen;
                              
            }
            else if (phong.TinhTrang == 1)
            {
                this.BackColor = Color.Khaki;
                
            }
        }
        public DevExpress.XtraEditors.PanelControl getPanelThongTinPhong()
        {
            return panelControl1;
        }
        public DevExpress.XtraEditors.SimpleButton getButtonThongTinPhong()
        {
            return btnTipInfo;
        }
        private String LayTinhTrangPhongQuaSo(int tinhTrang)
        {
            if (tinhTrang == 0) return "Trống";
            else if (tinhTrang == 2) return "Đang Sử Dụng";
            else return "Đã Đặt Trước";//1
        }

    }
}
