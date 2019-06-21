using QuanLyKhachSan.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.BUS
{
    class ChiTietLoaiPhongBUS
    {
        QLKSDataContext db = new QLKSDataContext();

        

        public List<ChiTietLoaiPhong> HienThiChiTietLoaiPhong()
        {
            return db.ChiTietLoaiPhongs.ToList();
        }

        public bool XoaChiTietLoaiPhong(string maTienNghi, string maLoaiPhong)
        {
            SqlConnection con = new SqlConnection(db.Connection.ConnectionString);
            SqlCommand command = new SqlCommand("delete from ChiTietLoaiPhong where MaTienNghi = @maTienNghi and MaLoai = @maLoai", con);

            command.Parameters.AddWithValue("@maTienNghi", maTienNghi);
            command.Parameters.AddWithValue("@maLoai", maLoaiPhong);
            con.Open();
            int result = command.ExecuteNonQuery();
            con.Close();
            if (result <= 0) return false;
            else return true;
        }
        public bool ThemChiTietLoaiPhong(ChiTietLoaiPhong chiTietLoaiPhong)
        {
            SqlConnection con = new SqlConnection(db.Connection.ConnectionString);
            SqlCommand command = new SqlCommand("insert into ChiTietLoaiPhong values(@maTienNghi, @maLoai, @soLuong)", con);

            command.Parameters.AddWithValue("@maTienNghi", chiTietLoaiPhong.MaTienNghi);
            command.Parameters.AddWithValue("@maLoai", chiTietLoaiPhong.MaLoai);
            command.Parameters.AddWithValue("@maLoai", chiTietLoaiPhong.SoLuong);
            con.Open();
            int result = command.ExecuteNonQuery();
            con.Close();
            if (result <= 0) return false;
            else return true; ;
        }
        public bool CapNhatChiTietLoaiPhong(ChiTietLoaiPhong chiTietLoaiPhong)
        {
            XoaChiTietLoaiPhong(chiTietLoaiPhong.MaTienNghi, chiTietLoaiPhong.MaLoai);
            ThemChiTietLoaiPhong(chiTietLoaiPhong);
            return true;
        }
    }
}
