using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.DAO;

namespace QuanLyKhachSan.BUS
{
    class LoaiPhongBUS
    {
        QLKSDataContext db = new QLKSDataContext();
        public List<LoaiPhong> HienThiLoaiPhong()
        {
            return db.LoaiPhongs.ToList();
        }

        public bool XoaLoaiPhong(string maLoaiPhong)
        {
            LoaiPhong LoaiPhong = db.LoaiPhongs.Single(x => x.MaLoai == maLoaiPhong);
            db.LoaiPhongs.DeleteOnSubmit(LoaiPhong);
            db.SubmitChanges();
            return true;
        }
        public bool ThemLoaiPhong(LoaiPhong LoaiPhong)
        {
            db.LoaiPhongs.InsertOnSubmit(LoaiPhong);
            db.SubmitChanges();
            return true;
        }
        public bool CapNhatLoaiPhong(LoaiPhong loaiPhong)
        {
            XoaLoaiPhong(loaiPhong.MaLoai);
            ThemLoaiPhong(loaiPhong);
            return true;
        }
    }
}
