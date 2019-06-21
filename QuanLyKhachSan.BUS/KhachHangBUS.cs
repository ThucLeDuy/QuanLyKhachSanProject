using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.DAO;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKhachSan.BUS
{
    public class KhachHangBUS
    {
        QLKSDataContext db = new QLKSDataContext();
        private static HoaDonDichVuBUS hdDichVuBUS = new HoaDonDichVuBUS();
        private static DichVuBUS dichVuBUS = new DichVuBUS();
        private static DatPhongTaiChoBUS datPhongTCBUS = new DatPhongTaiChoBUS();
        

        public List<HoaDonDV> LayDanhSachDichVuKH(string maKhachHang)
        {
            List<HoaDonDV> dsCacDV = new List<HoaDonDV>();
            foreach (HoaDonDV hdDV in hdDichVuBUS.HienThiHoaDonDV())
            {
                if (hdDV.MaKH == maKhachHang)
                {
                    dsCacDV.Add(hdDV);
                }
            }
            return dsCacDV;
        }
        public bool KiemTraTrungMaKH(string maKhachHang)
        {
            foreach (KhachHang kh in HienThiKhachHang())
            {
                if (kh.MaKH == maKhachHang) return true;
            }
            return false;
        }
        public bool KiemTraTonTaiKhachHang(string maKH, string tenKH, string diaChi, string soDT, string quocTich, string CMND)
        {
            foreach(KhachHang kh in db.KhachHangs.ToList())
            {
                if (maKH == kh.MaKH) return true;
            }
            return false;
            //try
            //{
            //    db.KhachHangs.Single(x => x.MaKH == maKH);
            //}
            //catch(ArgumentNullException)
            //{
            //    return false;
            //}
            //return true;
            
        }
        public int XuLyLangNgheKhachHang(string maKH, string tenKH, string diaChi, string soDT, string quocTich, string CMND)
        {

            bool res = KiemTraTonTaiKhachHang(maKH, tenKH, diaChi, soDT, quocTich, CMND);
       
            KhachHang kh = new KhachHang();
            kh.HoTenKH = tenKH;
            kh.MaKH = maKH;
            kh.DiaChi = diaChi;
            kh.Sodt = soDT;
            kh.QuocTich = quocTich;
            kh.CMND = CMND;
            try
            {
                if (!res)//ko tồn tại kh -> insert
                {
                    if (ThemKhachHang(kh)) return 1;
                }
                else if (res)//tồn tại kh -> update
                {
                    if (CapNhatKhachHang(kh)) return 2;
                }
                
            }
            catch (Exception e) { return -1; }
            return -1;

        }
        public Decimal TongTienDichVu(string maKhachHang)
        {
            decimal tongTienDV = 0;
            List<HoaDonDV> dsCacDV = LayDanhSachDichVuKH(maKhachHang);
            int doDaiDS = dsCacDV.Count;
            if (doDaiDS != 0)
            {
                foreach (HoaDonDV hoaDonDV in dsCacDV)
                {
                    tongTienDV += dichVuBUS.TinhTienTungDV(hoaDonDV.MaDV, Convert.ToInt16(hoaDonDV.SoLuongDV));
                }
            }
            return tongTienDV;
        }
        public List<KhachHang> HienThiKhachHang()
        {
            return db.KhachHangs.ToList();
        }
        public String LayTenKhachHangByMaKH(string maKH)
        {
            if (maKH == null) { return ""; }
            foreach (KhachHang khachHang in db.KhachHangs.ToList())
            {
                if (khachHang.MaKH == maKH) return khachHang.HoTenKH;
            }
            return null;
        }

        //Note: Khi XoaKhachHang se xoa ca DatPhongTaiCho (neu co) va DatPhongTruoc (neu co)
        public bool XoaKhachHang(string maKhachHang)
        {
            KhachHang khachHang = db.KhachHangs.Single(x => x.MaKH == maKhachHang);
            //datPhongTCBUS.XoaDatPhongTaiCho(maKhachHang);
            //datPhongTruocBUS.XoaDatPhongTruoc(maKhachHang);
            db.KhachHangs.DeleteOnSubmit(khachHang);
            db.SubmitChanges();
            return true;
        }
        public bool ThemKhachHang(KhachHang khachHang)
        {
            KiemTraTrungMaKH(khachHang.MaKH);
            db.KhachHangs.InsertOnSubmit(khachHang);
            db.SubmitChanges();
            return true;
        }
        public bool CapNhatKhachHang(KhachHang khachHang)
        {
            SqlConnection con = new SqlConnection(db.Connection.ConnectionString);
            SqlCommand command = new SqlCommand("update KhachHang set HoTenKH = @hoTen, DiaChi = @diaChi, Sodt = @soDt, QuocTich = @quocTich, CMND = @CMND WHERE MaKH = @maKH", con);
            command.Parameters.AddWithValue("@hoTen", khachHang.HoTenKH);
            command.Parameters.AddWithValue("@diaChi", khachHang.DiaChi);
            command.Parameters.AddWithValue("@soDt", khachHang.Sodt);
            command.Parameters.AddWithValue("@quocTich", khachHang.QuocTich);
            command.Parameters.AddWithValue("@CMND", khachHang.CMND);
            command.Parameters.AddWithValue("@maKH", khachHang.MaKH);
            con.Open();
            int result = command.ExecuteNonQuery();
            con.Close();
            if (result <= 0) return false;
            else return true;

        }
        

    }
}
