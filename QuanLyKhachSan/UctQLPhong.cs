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
    public partial class UctQLPhong : UserControl
    {
        private static PhongBUS phongBUS = new PhongBUS();
        private static KhachHangBUS khBUS = new KhachHangBUS();
        private static DatPhongTaiChoBUS datPhongBUS = new DatPhongTaiChoBUS();
        public Phong phongHienTai;
        public DatPhongTaiCho datPhongTC;
        public UctQLPhong(Phong phong)
        {
            InitializeComponent();
            datPhongTC = datPhongBUS.LayPhieuDatPhongDangThueQuaSoP(phong.SoPhong);
            phongHienTai = phong;
            lblSoPhongUct.Text = phong.SoPhong;
            if(datPhongTC == null)
            {
                lblTenKHuct.Text = "";
            }
            else
            {
                lblTenKHuct.Text = khBUS.LayTenKhachHangByMaKH(datPhongTC.MaKH);
            }
                      
            lblTinhTrang.Text = LayTinhTrangPhongQuaSo(Convert.ToInt16(phong.TinhTrang));
            this.BackColor = Color.LightSalmon;
            
            if (phong.TinhTrang == 0)
            {
                //chỉ có thể đặt phòng
                this.BackColor = Color.PaleGreen;
                btnThemDVuct.Enabled = false;
                btnThanhToan.Enabled = false;
                btnXacNhanThuePhong.Enabled = false;

                lblTenKHuct.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            }
            else if(phong.TinhTrang == 1)//đặt trước
            {
                //chỉ có đặt phòng, thanh toán, xác nhận
                this.BackColor = Color.Khaki;
                btnThemDVuct.Enabled = false;
                if (datPhongTC != null)
                {
                    lblTenKHuct.Text = khBUS.LayTenKhachHangByMaKH(datPhongTC.MaKH);
                }
                else lblTenKHuct.Text = "Đã đặt trước";
                //lblTenKHuct.Text = khBUS.LayTenKhachHangByMaKH(datPhongTC.MaKH);
                lblTenKHuct.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            }
            else if (phong.TinhTrang == 2)//đang xài
            {
                //chỉ có thêm dịch vụ, thanh toán, đặt phòng
                btnXacNhanThuePhong.Enabled = false;
                lblTenKHuct.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            }
        }
        private String LayTinhTrangPhongQuaSo(int tinhTrang)
        {
            if (tinhTrang == 0) return "Trống";
            else if (tinhTrang == 2) return "Đang Sử Dụng";
            else return "Đã Đặt Trước";//1
        }
        public DevExpress.XtraEditors.SimpleButton getButtonThemDV()
        {
            return this.btnThemDVuct;
        }
        public DevExpress.XtraEditors.PanelControl getPanelQLP()
        {
            return this.pnlQuanLyPhong;
        }
        public DevExpress.XtraEditors.SimpleButton getButtonThanhToan()
        {
            return this.btnThanhToan;
        }
        public DevExpress.XtraEditors.SimpleButton getButtonDatPhong()
        {
            return this.btnDatPhongUct;
        }
        public DevExpress.XtraEditors.SimpleButton getButtonXacThuePhong()
        {
            return this.btnXacNhanThuePhong;
        }
    }
}
