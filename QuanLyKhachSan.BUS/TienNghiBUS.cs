using QuanLyKhachSan.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.BUS
{
    class TienNghiBUS
    {
        QLKSDataContext db = new QLKSDataContext();

        public bool KiemTraTrungMaTienNghi(string maTienNghi)
        {
            foreach (TienNghi tienNghi in HienThiTienNghi())
            {
                if (tienNghi.MaTienNghi == maTienNghi) return true;
            }
            return false;
        }

        public List<TienNghi> HienThiTienNghi()
        {
            return db.TienNghis.ToList();
        }

        public bool XoaTienNghi(string maTienNghi)
        {
            TienNghi tienNghi = db.TienNghis.Single(x => x.MaTienNghi == maTienNghi);
            db.TienNghis.DeleteOnSubmit(tienNghi);
            db.SubmitChanges();
            return true;
        }
        public bool ThemTienNghi(TienNghi tienNghi)
        {
            db.TienNghis.InsertOnSubmit(tienNghi);
            db.SubmitChanges();
            return true;
        }
        public bool CapNhatTienNghi(TienNghi tienNghi)
        {
            XoaTienNghi(tienNghi.MaTienNghi);
            ThemTienNghi(tienNghi);
            return true;
        }
    }
}
