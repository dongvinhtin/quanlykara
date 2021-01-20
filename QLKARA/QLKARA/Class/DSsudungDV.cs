using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKARA
{
    public class DSsudungDV
    {
        public DSsudungDV() { }
        public int madatdv { get; set; }
        public int MaDatPhong { get; set; }
        public int MaDichVu { get; set; }
        public int soLuong { get; set; }
        public double Order_Gia { get; set; }
        public int IDHoaDon { get; set; }
        public Boolean TrangThai { get; set; }

        public string HoTen { get; set; }
        public string TenPhong { get; set; }
        public string TenDichVu { get; set; }
        public double Gia { get; set; }

        public int MaPhong { get; set; }
        public string TenDanhMuc { get; set; }
        public int MaDanhMuc { get; set; }
    }
}