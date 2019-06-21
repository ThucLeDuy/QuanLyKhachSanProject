using QuanLyKhachSan.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.BUS
{
    public class DataOfflineBUS
    {
        QLKSDataContext db = new QLKSDataContext();
        public List<DataOffline> HienThiDataOffline()
        {
            return db.DataOfflines.ToList();
        }
        public List<DataOffline> LayListDataOfflineByID(string ID_DataOffline)
        {
            List<DataOffline> dsData = new List<DataOffline>();
            foreach (DataOffline dataOffline in db.DataOfflines.ToList())
            {
                if (dataOffline.ID_Data == ID_DataOffline)
                {
                    dsData.Add(dataOffline);
                }
            }
            return null;
        }
        public int DemSoLuongDataOff()
        {
            return db.DataOfflines.ToList().Count;
        }
        
        public bool XoaTatCaDataOfflineByID(string maDataOffline)
        {
            try
            {
                foreach (DataOffline dataOff in LayListDataOfflineByID(maDataOffline))
                {
                    db.DataOfflines.DeleteOnSubmit(dataOff);
                    db.SubmitChanges();
                }
            }
            catch (Exception) { return false; }
            return true;
        }
        public bool XoaDataOffline(string maDataOffline, DateTime thoiGianTaoData)
        {
            try
            {
                foreach (DataOffline dataOff in LayListDataOfflineByID(maDataOffline))
                {
                    if (dataOff.ThoiGian == thoiGianTaoData)
                    {
                        db.DataOfflines.DeleteOnSubmit(dataOff);
                        db.SubmitChanges();
                        return true;
                    }
                }
            }
            catch (Exception) { return false; }
            return false;
        }
        public bool ThemDataOffline(DataOffline DataOffline)
        {
            db.DataOfflines.InsertOnSubmit(DataOffline);
            db.SubmitChanges();
            return true;
        }
        public bool CapNhatDataOffline(DataOffline dataOffline)
        {
            XoaDataOffline(dataOffline.ID_Data, dataOffline.ThoiGian);
            ThemDataOffline(dataOffline);
            return true;
        }
    }
}
