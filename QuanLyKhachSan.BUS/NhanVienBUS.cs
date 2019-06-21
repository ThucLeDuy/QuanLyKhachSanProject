using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.DAO;

namespace QuanLyKhachSan.BUS
{
    public class NhanVienBUS
    {
        QLKSDataContext db = new QLKSDataContext();
        public List<NhanVien> HienThiNhanVien()
        {
            return db.NhanViens.ToList();
        }
        public NhanVien LayNhanVienByMaNV(string maNhanVien)
        {
            foreach(NhanVien nv in HienThiNhanVien())
            {
                if (nv.MaNV == maNhanVien) return nv;
            }
            return null;
        }
        public bool KiemTraTrungMaNV(string maNhanVien)
        {
            foreach(NhanVien nv in HienThiNhanVien())
            {
                if (nv.MaNV == maNhanVien) return true;
            }
            return false;
        }
        public bool KiemTraDangNhap(string maNhanVien, string matKhau)
        {
            foreach(NhanVien nv in HienThiNhanVien())
            {
                if(nv.MaNV == maNhanVien && nv.Password == matKhau)
                {
                    return true;
                }            
            }
            return false;
        }
        public bool XoaNhanVien(string maNhanVien)
        {
            NhanVien nhanVien = db.NhanViens.Single(x => x.MaNV == maNhanVien);
            db.NhanViens.DeleteOnSubmit(nhanVien);
            db.SubmitChanges();
            return true;
        }
        public bool ThemNhanVien(NhanVien nhanVien)
        {
            db.NhanViens.InsertOnSubmit(nhanVien);
            db.SubmitChanges();
            return true;
        }
        public bool CapNhatNhanVien(NhanVien nv)
        {
            XoaNhanVien(nv.MaNV);
            ThemNhanVien(nv);
            return true;
        }
    }
}
