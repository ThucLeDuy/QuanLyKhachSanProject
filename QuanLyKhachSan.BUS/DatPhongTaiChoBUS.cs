using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.DAO;
using System.Data.SqlClient;

namespace QuanLyKhachSan.BUS
{
    public class DatPhongTaiChoBUS
    {
        QLKSDataContext db = new QLKSDataContext();
        private static PhongBUS phongBUS = new PhongBUS();
        
        public List<DatPhongTaiCho> HienThiDatPhongTaiCho()
        {
            return db.DatPhongTaiChos.ToList();
        }
        public DatPhongTaiCho LayPhieuDatPhongByMaKH(string maKH, string soPhong, DateTime ngayDat)
        {
            foreach (DatPhongTaiCho datPhongTaiCho in HienThiDatPhongTaiCho())
            {
                if (datPhongTaiCho.MaKH == maKH && datPhongTaiCho.SoPhong == soPhong 
                    && datPhongTaiCho.NgayDat == ngayDat)
                {
                    return datPhongTaiCho;
                }
            }
            return null;
        }
        public bool KiemTraTrungMaKh_SoPhong(string maKhachHang, string soPhong)
        {
            foreach (DatPhongTaiCho datPgTC in HienThiDatPhongTaiCho())
            {
                if (datPgTC.MaKH == maKhachHang && datPgTC.SoPhong == soPhong) return true;
            }
            return false;
        }
        public bool XoaDatPhongTaiCho(string maKH, string soPhong, DateTime ngayDat)
        {
            //Kiem tra neu CO' KH trong DatPhongTC moi duoc xoa
            if (!KiemTraTrungMaKh_SoPhong(maKH, soPhong)) return false;
            DatPhongTaiCho datPhongTaiCho = db.DatPhongTaiChos.Single(x => x.MaKH == maKH && x.SoPhong == soPhong && x.NgayDat == ngayDat);
            db.DatPhongTaiChos.DeleteOnSubmit(datPhongTaiCho);
            db.SubmitChanges();
            return true;
        } 
        public bool ThemDatPhongTaiCho(DatPhongTaiCho datPhongTaiCho)
        {
            //Kiem tra neu KO co KH trong DatPhongTC moi duoc them
            if (KiemTraTrungMaKh_SoPhong(datPhongTaiCho.MaKH, datPhongTaiCho.SoPhong))
            {
                return false;
            }
            phongBUS.CapNhatTrangThaiPhong();
            if (phongBUS.LayPhongQuaSoPhong(datPhongTaiCho.SoPhong).TinhTrang == 0)//vì đặt ở ngay nên chỉ lấy phòng trống
            {
                datPhongTaiCho.TrangThaiDatPhong = "O";
            }
            else { return false; }
            db.DatPhongTaiChos.InsertOnSubmit(datPhongTaiCho);
            db.SubmitChanges();
            phongBUS.LayPhongQuaSoPhong(datPhongTaiCho.SoPhong).TinhTrang = 1;//đưa tình trạng phòng về mức 1 = đang thuê
            return true;
        }

        public bool ThemDatPhongTruoc(DatPhongTaiCho datPhongTaiCho)
        {
            //Kiem tra neu KO co KH trong DatPhongTC moi duoc them
            if (KiemTraTrungMaKh_SoPhong(datPhongTaiCho.MaKH, datPhongTaiCho.SoPhong))
            {
                return false;
            }
            phongBUS.CapNhatTrangThaiPhong();
            if (phongBUS.LayPhongQuaSoPhong(datPhongTaiCho.SoPhong).TinhTrang == 0)//trống
            {
                phongBUS.LayPhongQuaSoPhong(datPhongTaiCho.SoPhong).TinhTrang = 2;//đưa tình trạng phòng về mức 2 = đã đặt
                datPhongTaiCho.TrangThaiDatPhong = "C";//đưa tình trạng phiếu datPhongTaiCho về mức C = Chờ
            }
            if (phongBUS.LayPhongQuaSoPhong(datPhongTaiCho.SoPhong).TinhTrang == 1)//đã đặt
            {
                datPhongTaiCho.TrangThaiDatPhong = "C";//đưa tình trạng phiếu datPhongTaiCho về mức C = Chờ
            }
            if (phongBUS.LayPhongQuaSoPhong(datPhongTaiCho.SoPhong).TinhTrang == 2)//đang xài
            {
                datPhongTaiCho.TrangThaiDatPhong = "C";//đưa tình trạng phiếu datPhongTaiCho về mức C = Chờ
            }
            db.DatPhongTaiChos.InsertOnSubmit(datPhongTaiCho);
            db.SubmitChanges();
            return true;
        }
        public DateTime LayNgayDatPhongLonNhatCuaPhong(Phong p)
        {
            DateTime ngayDatPhongTruocHienTai;
            DateTime ngayDatPhongTruocLonNhat = DateTime.Now;
            foreach (DatPhongTaiCho datPhong in db.DatPhongTaiChos.ToList())
            {
                ngayDatPhongTruocHienTai = datPhong.NgayDat.AddDays(Convert.ToDouble(datPhong.SoNgaySeThue));

                if (ngayDatPhongTruocHienTai > ngayDatPhongTruocLonNhat)
                {
                    ngayDatPhongTruocLonNhat = ngayDatPhongTruocHienTai;
                }
            }
            return ngayDatPhongTruocLonNhat.AddHours(1.0);
        }
        public bool CapNhatDatPhongTaiCho(DatPhongTaiCho datPTaiCho)
        {
            XoaDatPhongTaiCho(datPTaiCho.MaKH, datPTaiCho.SoPhong, datPTaiCho.NgayDat);
            ThemDatPhongTaiCho(datPTaiCho);
            return true;
        }
        public bool CapNhatTrangThaiCho1Phieu(DatPhongTaiCho datPTaiCho)
        {
            SqlConnection con = new SqlConnection(db.Connection.ConnectionString);
            SqlCommand command = new SqlCommand("update DatPhongTaiCho set TrangThaiDatPhong = @trangThai where MaKH = @maKH and SoPhong = @soPhong and NgayDat = @ngayDat", con);
 
            command.Parameters.AddWithValue("@trangThai", datPTaiCho.TrangThaiDatPhong);
            command.Parameters.AddWithValue("@maKH", datPTaiCho.MaKH);
            command.Parameters.AddWithValue("@soPhong", datPTaiCho.SoPhong);
            command.Parameters.AddWithValue("@ngayDat", datPTaiCho.NgayDat);
            con.Open();
            int result = command.ExecuteNonQuery();
            con.Close();
            if (result <= 0) return false;
            else return true;
            //db.DatPhongTaiChos.DeleteOnSubmit(datPTaiCho);
            //db.SubmitChanges();
            //db.DatPhongTaiChos.InsertOnSubmit(datPTaiCho);
            //db.SubmitChanges();
            //return true;
        }
        public DatPhongTaiCho LayPhieuDatPhongDangThueQuaSoP(string soPhong)
        {
            phongBUS.LayPhongQuaSoPhong(soPhong);
            DateTime ngayDatPhongTruocNhoNhat = DateTime.Now;
            DatPhongTaiCho datPhongGanNhat = null;
            foreach (DatPhongTaiCho datPTaiCho in db.DatPhongTaiChos.ToList())
            {

                if (datPTaiCho.SoPhong == soPhong && datPTaiCho.TrangThaiDatPhong != "T")
                {
                    if(datPTaiCho.TrangThaiDatPhong != "O")
                    {

                    }
                    else if(datPTaiCho.TrangThaiDatPhong != "C")
                    {

                    }
                    if (datPTaiCho.NgayDat < ngayDatPhongTruocNhoNhat)
                    {
                        ngayDatPhongTruocNhoNhat = datPTaiCho.NgayDat;
                        datPhongGanNhat = datPTaiCho;
                    }
                    
                }
                
            }
            if (datPhongGanNhat == null) return null;
            else return datPhongGanNhat;
        }
        public DatPhongTaiCho LayPhieuDatPhongDatTruocQuaSoPhong(string soPhong)
        {
            phongBUS.LayPhongQuaSoPhong(soPhong);
            DateTime ngayDatPhongTruocNhoNhat = DateTime.Now;
            DatPhongTaiCho datPhongGanNhat = null;
            foreach (DatPhongTaiCho datPTaiCho in db.DatPhongTaiChos.ToList())
            {

                if (datPTaiCho.SoPhong == soPhong && datPTaiCho.TrangThaiDatPhong != "T")
                {
                    if (datPTaiCho.TrangThaiDatPhong != "O")
                    {

                    }
                    if (datPTaiCho.TrangThaiDatPhong == "C")
                    {
                        return datPTaiCho;
                    }
                    

                }

            }
            return null;
        }

    }

}
