using QuanLyKhachSan.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.BUS
{
    class TaiKhoanTaiKhoanKHBUS
    {
        QLKSDataContext db = new QLKSDataContext();
        
        public bool KiemTraTrungMaKH(string maKH)
        {
            foreach (TaiKhoanKH taiKhoanKH in HienThiTaiKhoanKH())
            {
                if (taiKhoanKH.MaKH == maKH) return true;
            }
            return false;
        }
        
        public List<TaiKhoanKH> HienThiTaiKhoanKH()
        {
            return db.TaiKhoanKHs.ToList();
        }
        
        public bool XoaTaiKhoanKH(string maKH)
        {
            TaiKhoanKH taiKhoanKH = db.TaiKhoanKHs.Single(x => x.MaKH == maKH);
            db.TaiKhoanKHs.DeleteOnSubmit(taiKhoanKH);
            db.SubmitChanges();
            return true;
        }
        public bool ThemTaiKhoanKH(TaiKhoanKH taiKhoanKH)
        {
            db.TaiKhoanKHs.InsertOnSubmit(taiKhoanKH);
            db.SubmitChanges();
            return true;
        }
        public bool CapNhatTaiKhoanKH(TaiKhoanKH taiKhoanKH)
        {
            XoaTaiKhoanKH(taiKhoanKH.MaKH);
            ThemTaiKhoanKH(taiKhoanKH);
            return true;
        }
        
    }
}
