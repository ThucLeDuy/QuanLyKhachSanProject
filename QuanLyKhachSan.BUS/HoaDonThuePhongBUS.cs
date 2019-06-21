using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.DAO;

namespace QuanLyKhachSan.BUS
{
    public class HoaDonThuePhongBUS
    {
        QLKSDataContext db = new QLKSDataContext();
        public List<HoaDonThuePhong> HienThiHoaDonThuePhong()
        {
            return db.HoaDonThuePhongs.ToList();
        }

        public bool XoaHoaDonThuePhong(string maHoaDonThuePhong)
        {
            HoaDonThuePhong hoaDonThuePhong = db.HoaDonThuePhongs.Single(x => x.MaHD == maHoaDonThuePhong);
            db.HoaDonThuePhongs.DeleteOnSubmit(hoaDonThuePhong);
            db.SubmitChanges();
            return true;
        }
        public bool ThemHoaDonThue(HoaDonThuePhong hoaDonThuePhong)
        {
            db.HoaDonThuePhongs.InsertOnSubmit(hoaDonThuePhong);
            db.SubmitChanges();
            return true;
        }
        public bool CapNhatHoaDonThue(HoaDonThuePhong hoaDonThuePhong)
        {
            XoaHoaDonThuePhong(hoaDonThuePhong.MaHD);
            ThemHoaDonThue(hoaDonThuePhong);
            return true;
        }
    }
}
