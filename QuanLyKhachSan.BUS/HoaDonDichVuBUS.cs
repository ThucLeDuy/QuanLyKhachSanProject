using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.DAO;
using System.Data.SqlClient;
using QuanLyKhachSan.BUS.ldvmservices;
namespace QuanLyKhachSan.BUS
{
    public class HoaDonDichVuBUS
    {
        QLKSDataContext db = new QLKSDataContext();
        private static KhachHangBUS khBUS = new KhachHangBUS();
        private WebService1 qlksWebservice = new WebService1();
        private static DataOfflineBUS dataOffBUS = new DataOfflineBUS();
        public List<HoaDonDV> HienThiHoaDonDV()
        {

            return db.HoaDonDVs.ToList();
        }
        //public bool KiemTraTonTaiHoaDonDV(string )
        public List<HoaDonDV> TimNhieuHoaDonByMaKhachHang(string maKH)
        {
            List<HoaDonDV> dsHD = new List<HoaDonDV>();
            foreach (HoaDonDV hdDV in db.HoaDonDVs.ToList())
            {
                if (maKH == hdDV.MaKH) dsHD.Add(hdDV);
            }
            return dsHD;
        }
        public int KiemTraTonTaiHoaDonDV(string maKH, string maDV, int? soLuongDV, DateTime ngaySuDung)
        {
            int countHD = 0;
            foreach(HoaDonDV hd in db.HoaDonDVs.ToList())
            {
                if (hd.MaKH == maKH)
                {
                    //bằng tất cả khóa chính -> update soLuong HD
                    if (hd.MaDV == maDV && hd.NgaySuDungDV == ngaySuDung)
                        return 2;
                    else countHD++;
                }
            }
            if (countHD > 1) return 1;// đã tồn tại Kh -> insert HD mới, kh cũ
            return 0; //ko tồn tại HD
        }
        public int XuLyLangNgheDichVu(string maKH, string maDV, int? soLuongDV, DateTime ngaySuDung)
        {
            HoaDonDV hdDV = new HoaDonDV();
            hdDV.MaDV = maDV;
            hdDV.MaKH = maKH;
            hdDV.NgaySuDungDV = ngaySuDung;
            hdDV.SoLuongDV = soLuongDV;
            
            
            try
            {
                int res = KiemTraTonTaiHoaDonDV(maKH, maDV, soLuongDV, ngaySuDung);
                if (res == 1)
                {
                    if (ThemHoaDonDVoffline(hdDV)) return 1;//return "inserted HDDV " + maKH;//insert
                    else return -11;
                }
                else if (res == 2)
                {
                    if (CapNhatSoLuongDVHoaDonDV(hdDV)) return 2;// "updated so luong HDDV " + maKH;//update HDDV
                    else return -12;
                }
                else if (res == 0)
                {
                    if (ThemHoaDonDVoffline(hdDV)) return 0; //"inserted HDDV " + maKH;//insert
                    else return -10;
                }
            }
            catch (Exception e) { return -1; }//{ return e.ToString(); }
            return 3;
            
        }
        public string KiemTraTonTaiHoaDonDV2(string maKH, string maDV, int? soLuongDV, DateTime ngaySuDung)
        {
            //if((db.HoaDonDVs.Single(x => x.MaKH == maKH)) != null)
            //{
            //    return true;
            //}
            //return false;
            try
            {
                db.HoaDonDVs.Single(x => x.MaKH == maKH);
            }
            catch (ArgumentNullException e1)
            {
                //Ko có KH nào
                return "e1";
            }
            catch (InvalidOperationException e2)
            {
                //có nhiều hóa đơn
                return "e2";
            }
            return null;
        }

        public bool XoaHoaDonDVTheoNgay(string maKH, DateTime ngaySuDung)
        {
            SqlConnection con = new SqlConnection(db.Connection.ConnectionString);
            SqlCommand command = new SqlCommand("delete from HoaDonDV where HoaDonDV.MaKH = '" + maKH + "' and HoaDonDV.NgaySuDungDV = '" + ngaySuDung + "'", con);
            con.Open();
            int result = command.ExecuteNonQuery();
            con.Close();
            if (result <= 0) return false;
            else return true;
        }

        public bool XoaMotDichVuKH(string maKhachHang, string maDV, DateTime ngaySuDungDV)
        {
            SqlConnection con = new SqlConnection(db.Connection.ConnectionString);
            SqlCommand command = new SqlCommand("Delete from HoaDonDV where MaKH = @maKH and MaDV = @maDV and NgaySuDungDV= @ngaySuDungDV", con);
            command.Parameters.AddWithValue("@maKH", maKhachHang);
            command.Parameters.AddWithValue("@maDV", maDV);
            command.Parameters.AddWithValue("@ngaySuDungDV", ngaySuDungDV);
            
            con.Open();
            int result = command.ExecuteNonQuery();
            con.Close();
            if (result <= 0) return false;
            else return true;
        }
        public bool XoaMotDichVuKH(string maKhachHang, string maDV)
        {
            SqlConnection con = new SqlConnection(db.Connection.ConnectionString);
            SqlCommand command = new SqlCommand("Delete from HoaDonDV where MaKH = @maKH and MaDV = @maDV", con);
            command.Parameters.AddWithValue("@maKH", maKhachHang);
            command.Parameters.AddWithValue("@maDV", maDV);

            con.Open();
            int result = command.ExecuteNonQuery();
            con.Close();
            if (result <= 0) return false;
            else return true;
        }
        public bool XoaTatCaDichVuCuaKH(string maKhachHang)
        {
            SqlConnection con = new SqlConnection(db.Connection.ConnectionString);
            SqlCommand command = new SqlCommand("Delete from HoaDonDV where MaKH = '" + maKhachHang + "'", con);
            con.Open();
            int result = command.ExecuteNonQuery();
            con.Close();
            if (result <= 0) return false;
            else return true;

            //db.ExecuteQuery<HoaDonDV>("Delete from HoaDonDV where MaKH = '" + maKhachHang+ "'");
            //db.SubmitChanges();

            //return true;
        }
        public void CapNhatHoaDonDVLenService()
        {
            String[] str_DichVu;
            foreach (DataOffline dataOff in dataOffBUS.HienThiDataOffline())
            {
                if (dataOff.TenTable == "HoaDonDV")
                {
                    if(dataOff.TenSuKien == "insert")
                    {
                        str_DichVu = dataOff.ID_Data.Split('_');
                        qlksWebservice.ThemHoaDonDichVuChoKH(str_DichVu[0], str_DichVu[1], dataOff.ThoiGian, Convert.ToInt32(str_DichVu[2]));
                        dataOffBUS.XoaDataOffline(dataOff.ID_Data, dataOff.ThoiGian);
                    }
                    if (dataOff.TenSuKien == "update")
                    {
                        str_DichVu = dataOff.ID_Data.Split('_');
                        //qlksWebservice.ThemHoaDonDichVuChoKH( (str_DichVu[0], str_DichVu[1], dataOff.ThoiGian, Convert.ToInt32(str_DichVu[2]));
                    }
                    if (dataOff.TenSuKien == "delete")
                    {
                        str_DichVu = dataOff.ID_Data.Split('_');
                        qlksWebservice.XoaMotHoaDonDichVu(str_DichVu[0], str_DichVu[1], dataOff.ThoiGian);
                    }
                }
            }
        }
        public bool ThemHoaDonDVoffline(HoaDonDV hoaDonDV)
        {
            //Thêm HD dịch vụ cho KH trong trường hợp ko có kết nối internet
            //Tạo Bảng DataOffline để lưu các thuộc tính của 1 record
            //Mục đích Cho đến khi khách hàng có kết nối internet lại sẽ thực hiện đồng bộ dựa trên các record này
            DataOffline dataOff = new DataOffline();
            dataOff.ID_Data = hoaDonDV.MaKH + "_" + hoaDonDV.MaDV + "_" + hoaDonDV.SoLuongDV;
            dataOff.TenSuKien = "insert";
            dataOff.TenTable = "HoaDonDV";
            dataOff.ThoiGian = hoaDonDV.NgaySuDungDV;

            try
            {
                db.HoaDonDVs.InsertOnSubmit(hoaDonDV);
                db.SubmitChanges();
                //dataOffBUS.ThemDataOffline(dataOff);
            }
            catch(Exception)
            {
                return false;
            }
            //qlksWebservice.ThemHoaDonDichVuChoKH(hoaDonDV.MaKH, hoaDonDV.MaDV, hoaDonDV.NgaySuDungDV, Convert.ToInt32(hoaDonDV.SoLuongDV));
            return true;
        }
        public bool ThemHoaDonDVoffline2(HoaDonDV hoaDonDV)//chỉ dùng để thêm khi off
        {
            //Thêm HD dịch vụ cho KH trong trường hợp ko có kết nối internet
            //Tạo Bảng DataOffline để lưu các thuộc tính của 1 record
            //Mục đích Cho đến khi khách hàng có kết nối internet lại sẽ thực hiện đồng bộ dựa trên các record này
            DataOffline dataOff = new DataOffline();
            dataOff.ID_Data = hoaDonDV.MaKH + "_" + hoaDonDV.MaDV + "_" + hoaDonDV.SoLuongDV;
            dataOff.TenSuKien = "insert";
            dataOff.TenTable = "HoaDonDV";
            dataOff.ThoiGian = hoaDonDV.NgaySuDungDV;

            try
            {
                db.HoaDonDVs.InsertOnSubmit(hoaDonDV);
                db.SubmitChanges();
                dataOffBUS.ThemDataOffline(dataOff);
            }
            catch (Exception)
            {
                return false;
            }
            //qlksWebservice.ThemHoaDonDichVuChoKH(hoaDonDV.MaKH, hoaDonDV.MaDV, hoaDonDV.NgaySuDungDV, Convert.ToInt32(hoaDonDV.SoLuongDV));
            return true;
        }
        public bool ThemHoaDonDVWeb(HoaDonDV hoaDonDV)
        {
            //Note: Chỉ sử dụng khi khách hàng có kết nối internet vì có gọi tới webservice
            try
            {
                db.HoaDonDVs.InsertOnSubmit(hoaDonDV);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            qlksWebservice.ThemHoaDonDichVuChoKH(hoaDonDV.MaKH, hoaDonDV.MaDV, hoaDonDV.NgaySuDungDV, Convert.ToInt32(hoaDonDV.SoLuongDV));
            return true;
        }
        //ko sử dụng cái này
        public bool ThemHoaDonDV(string maKhachHang, string maDV, int soLuongDV, DateTime ngaySuDung)
        {
            string ngaySuDungFormatted = ngaySuDung.ToString("MM-dd-yyyy");
            db.ExecuteQuery<HoaDonDV>("Insert into HoaDonDV values('" + maKhachHang + "','" + maDV + "'," + soLuongDV + ",'" + ngaySuDungFormatted + "')");
            db.SubmitChanges();
            return true;
        }
        public bool CapNhatSoLuongDVHoaDonDV(HoaDonDV hoaDonDV)
        {
            (db.HoaDonDVs.Single(x => x.MaDV == hoaDonDV.MaDV && x.MaKH == hoaDonDV.MaKH && x.NgaySuDungDV == hoaDonDV.NgaySuDungDV)).SoLuongDV = hoaDonDV.SoLuongDV;
            db.SubmitChanges();
            return true;
        }
        public bool CapNhatHoaDonDV(HoaDonDV hoaDonDV)
        {
            XoaMotDichVuKH(hoaDonDV.MaKH, hoaDonDV.MaDV, hoaDonDV.NgaySuDungDV);
            ThemHoaDonDVoffline(hoaDonDV);
            return true;
        }
    }
}
