using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.DAO;

namespace QuanLyKhachSan.BUS
{
    public class DichVuBUS
    {
        QLKSDataContext db = new QLKSDataContext();
        public List<DichVu> HienThiDichVu()
        {
            return db.DichVus.ToList();
        }
        public DichVu LayDichVuByMaDV(string maDichVu)
        {
            foreach(DichVu dichVu in db.DichVus.ToList())
            {
                if(dichVu.MaDV == maDichVu)
                {
                    return dichVu;
                }
            }
            return null;
        }
        public string LayTenDichVuByMaDV(string maDichVu)
        {
            return db.DichVus.Single(x => x.MaDV == maDichVu).MoTaDV;
        }
        public bool KiemTraTrungMaDV(string maDichVu)
        {
            foreach (DichVu kh in HienThiDichVu())
            {
                if (kh.MaDV == maDichVu) return true;
            }
            return false;
        }
        public Decimal TinhTienTungDV(string maDichVu, int soLuong)
        {           
            return Convert.ToDecimal(LayDichVuByMaDV(maDichVu).GiaDV * soLuong);
        }
        public bool XoaDichVu(string maDichVu)
        {
            DichVu dichVU = db.DichVus.Single(x => x.MaDV == maDichVu);
            db.DichVus.DeleteOnSubmit(dichVU);
            db.SubmitChanges();
            return true;
        }
        public bool ThemDichVu(DichVu dichVu)
        {
            db.DichVus.InsertOnSubmit(dichVu);
            db.SubmitChanges();
            return true;
        }
        public bool CapNhatDichVu(DichVu dichVu)
        {
            XoaDichVu(dichVu.MaDV);
            ThemDichVu(dichVu);
            return true;
        }
    }
}
