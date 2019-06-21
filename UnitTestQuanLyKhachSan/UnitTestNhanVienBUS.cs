using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyKhachSan.BUS;
using QuanLyKhachSan.DAO;
namespace UnitTestQuanLyKhachSan
{
    [TestClass]
    public class UnitTestNhanVienBUS
    {
        private NhanVienBUS nhanVienBUS;
        private NhanVien nhanVien01;
        [TestInitialize]
        public void init()
        {
            nhanVienBUS = new NhanVienBUS();
            nhanVien01 = new NhanVien();
            nhanVien01.ChucVu = "Quản Lý";
            nhanVien01.DiaChi = "255/AD Thanh Lộc";
            nhanVien01.CMND = "09209324";
            nhanVien01.HoTenNV = "LDvm";

            
        }
        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
