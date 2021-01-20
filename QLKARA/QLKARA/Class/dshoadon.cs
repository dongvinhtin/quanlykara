using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKARA
{
    public class dshoadon
    {
		public dshoadon() { }
		public int IDHoaDon { get; set; }
		public int MaDatPhong { get; set; }
		public int soGio { get; set; }
		public double giaTien { get; set; }
		public double giaDichVu { get; set; }
		public double TongTien { get; set; }
		public Boolean TrangThai { get; set; }
		public DateTime NgayGioTao { get ; set; }
		public string getDate_in
		{
			get { return this.NgayGioTao.ToString("dd-MM-yyyy HH:mm tt"); }
			set { this.NgayGioTao = Convert.ToDateTime(value); }

		}
		public string getTrangThai
		{
			get
			{
				if (this.TrangThai == true)
					return "Đã thanh toán";
				else
					return "Chưa thanh toán";
			}
			set
			{
				if (this.TrangThai == true)
					this.TrangThai = true;
				else
					this.TrangThai = false;
			}
		}
		public string HoTen { get; set; }
		public string sdt { get; set; }
	}
}