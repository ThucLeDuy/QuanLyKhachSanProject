using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachSan.BUS;
namespace QuanLyKhachSan
{
    public partial class FormDangNhap : Form
    {
        private NhanVienBUS nhanVienBUS = new NhanVienBUS();
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txt_maNhanVien.Text == "" || txt_MatKhau.Text == "")
            {
                lblThongBao.Text = "Tài khoản và mật khẩu không được để trống!";
            }
            else
            {

                if (nhanVienBUS.KiemTraDangNhap(txt_maNhanVien.Text, txt_MatKhau.Text))
                {
                    if (nhanVienBUS.LayNhanVienByMaNV(txt_maNhanVien.Text).ChucVu == "Phục Vụ")
                    {
                        lblThongBao.Text = "Nhân viên này không đủ quyền truy cập";                        
                        return;
                    }
                    lblThongBao.Text = "Đăng Nhập Thành Công";
                    this.Hide();
                    FormChinh f1 = new FormChinh(nhanVienBUS.LayNhanVienByMaNV(txt_maNhanVien.Text));
                    f1.ShowDialog();                  
                    this.Close();                   
                }
                else lblThongBao.Text = "Sai tên đăng nhập hoặc mật khẩu";

            }
        }
    }
}
