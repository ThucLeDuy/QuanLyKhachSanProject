using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyKhachSan.BUS;
using QuanLyKhachSan.DAO;

namespace UnitTestQuanLyKhachSan
{
    [TestClass]
    public class UnitTestHoaDonDV
    {
        private HoaDonDichVuBUS hdDVBUS;
        HoaDonDV hD1;
        //private NhanVien nhanVien01;
        [TestInitialize]
        public void init()
        {
            hD1 = new HoaDonDV();
            hdDVBUS = new HoaDonDichVuBUS();
            hD1.MaDV = "Drink01";
            hD1.MaKH = "uytr";
            hD1.SoLuongDV = 1;

        }
        [TestMethod]
        public void TestMethodXoaMotHoaDonDV()
        {
            //bool res = hdDVBUS.XoaMotDichVuKH("USA001", "XachVL01");
            //Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void TestMethodXoaTatCaHoaDonDV()
        {
            //bool res = hdDVBUS.XoaTatCaDichVuCuaKH("uytr");

            //Assert.AreEqual(true, res);
            //Assert.AreEqual(true, false, hdDVBUS.getStringHDdv());
        }
        [TestMethod]
        public void TestMethodThem1HDDv()
        {
            bool res = hdDVBUS.ThemHoaDonDV("uytr", "Drink01", 2, DateTime.Now);
            Assert.AreEqual(true, res);
        }
    }
}
