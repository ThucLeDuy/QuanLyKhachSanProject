using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKhachSan.DAO;

namespace QuanLyKhachSan.BUS
{
    public class PhongBUS
    {
        QLKSDataContext db = new QLKSDataContext();
        private static DatPhongTaiChoBUS datPhongBUS = new DatPhongTaiChoBUS();
        private static HoaDonThuePhongBUS hdThuePhongBUS = new HoaDonThuePhongBUS();
        Random rd = new Random();
        public List<Phong> HienThiPhong()
        {
            return db.Phongs.ToList();
        }
        /* 0: TRỐNG
         * 1: ĐẶT TRƯỚC - CHỜ
         * 2: ĐANG Ở
         */
        public void CapNhatTrangThaiPhong()
        {
            DateTime soNgayDuocPhepThue;
            DateTime ngayDatPhongTruocHienTai;
            DateTime ngayDatPhongTruocLonNhat = DateTime.Now;
            foreach (DatPhongTaiCho phieuDatPhong in datPhongBUS.HienThiDatPhongTaiCho())
            {
                if (phieuDatPhong.TrangThaiDatPhong != "T")//chỉ phiếu đang ở hoặc đang chờ
                {

                    //ngày hết hạn = ngày đặt + số ngày sẽ ở
                    soNgayDuocPhepThue = phieuDatPhong.NgayDat.AddDays(Convert.ToDouble(phieuDatPhong.SoNgaySeThue));
                    //kiểm tra các phiếu đang chờ
                    if (phieuDatPhong.TrangThaiDatPhong == "C")
                    {
                        ngayDatPhongTruocHienTai = phieuDatPhong.NgayDat.AddDays(Convert.ToDouble(phieuDatPhong.SoNgaySeThue));
                        /*kiểm tra tất cả phiếu đang CHỜ của các khách hàng. Lưu khách hàng có ngày chờ nhận phòng lớn nhất cho tới hiện tại
                            mục đích: xem xét xem 1 phòng nào đó có còn ai đang chờ - đặt trước hay ko*/
                        if(ngayDatPhongTruocHienTai > ngayDatPhongTruocLonNhat)
                        {
                            ngayDatPhongTruocLonNhat = ngayDatPhongTruocHienTai;
                        }

                        //kiểm tra các phiếu đặt phòng trước có bị hết hạn không(quá hạn ngày tới)
                        if (DateTime.Now > phieuDatPhong.NgayToi) //ngày hiện tại lớn hơn ngày sẽ tới nhận phòng -> hủy phiếu. Cho kh kế tiếp thuê
                        {
                            phieuDatPhong.TrangThaiDatPhong = "T";//thanh toán + hủy phiếu
                            datPhongBUS.CapNhatTrangThaiCho1Phieu(phieuDatPhong);
                            LayPhongQuaSoPhong(phieuDatPhong.SoPhong).TinhTrang = 0;//tình trạng phòng về TRỐNG
                            db.SubmitChanges();
                        }
                        
                    }

                    //kiểm tra các phiếu và phòng đang ở
                    else if (phieuDatPhong.TrangThaiDatPhong == "O")
                    {
                        if (soNgayDuocPhepThue < DateTime.Now)//quá hạn -> tự động thanh toán
                        {
                            phieuDatPhong.TrangThaiDatPhong = "T";//tình trạng phiếu về thanh toán
                            LayPhongQuaSoPhong(phieuDatPhong.SoPhong).TinhTrang = 0; //phòng từ ĐANG Ở sẽ về TRỐNG
                            datPhongBUS.CapNhatTrangThaiCho1Phieu(phieuDatPhong);
                            db.SubmitChanges();
                            HoaDonThuePhong hdThanhToan = new HoaDonThuePhong();
                            hdThanhToan.MaHD = phieuDatPhong.MaKH + phieuDatPhong.SoPhong + rd.Next(999);
                            hdThanhToan.MaKH = phieuDatPhong.MaKH;
                            hdThanhToan.MaNV = "SYS001";
                            hdThanhToan.SoPhong = phieuDatPhong.SoPhong;
                            hdThanhToan.NgayLap = DateTime.Now;
                            hdThanhToan.NgayDatPhong = phieuDatPhong.NgayDat;
                            hdThanhToan.TongTienThuePhong = LayPhongQuaSoPhong(phieuDatPhong.SoPhong).GiaTrenNgay * Convert.ToDecimal((DateTime.Now -  hdThanhToan.NgayDatPhong.Value).TotalDays);
                            hdThuePhongBUS.ThemHoaDonThue(hdThanhToan);
                        }
                    }

                }
            }
            //cập nhật lại danh sách phòng lần nữa
            Phong p;
            foreach(DatPhongTaiCho phieuDatPhong in datPhongBUS.HienThiDatPhongTaiCho())
            {
                p = LayPhongQuaSoPhong(phieuDatPhong.SoPhong);
                if(phieuDatPhong.TrangThaiDatPhong == "O")
                {
                    p.TinhTrang = 2;
                }
                else if (phieuDatPhong.TrangThaiDatPhong == "C")
                {
                    p.TinhTrang = 1;
                }
            }
            db.SubmitChanges();
        }
        public bool KiemTraTrungPhong(string soPhong)
        {
            foreach (Phong phong in HienThiPhong())
            {
                if (phong.SoPhong == soPhong) return true;
            }
            return false;
        }
        public Phong LayPhongQuaSoPhong(string soPhong)
        {
            foreach(Phong phong in HienThiPhong())
            {
                if (phong.SoPhong == soPhong) return phong;
            }
            return null;
        }
        public string LayMaLoaiPhongQuaSoPhong(string soPhong)
        {
            foreach (Phong phong in HienThiPhong())
            {
                if (phong.SoPhong == soPhong) return phong.MaLoaiP;
            }
            return null;
        }
        public bool XoaPhong(string soPhong)
        {
            Phong Phong = db.Phongs.Single(x => x.SoPhong == soPhong);
            db.Phongs.DeleteOnSubmit(Phong);
            db.SubmitChanges();
            return true;
        }
        public bool ThemPhong(Phong Phong)
        {
            db.Phongs.InsertOnSubmit(Phong);
            db.SubmitChanges();
            return true;
        }
        public bool CapNhatPhong(Phong phong)
        {
            XoaPhong(phong.SoPhong);
            ThemPhong(phong);
            return true;
        }
    }
}
