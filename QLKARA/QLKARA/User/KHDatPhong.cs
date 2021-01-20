using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace QLKARA
{
    public class KHDatPhong
    {
		SqlConnection conn;
		public KHDatPhong()
		{
			string connectString = ConfigurationManager.ConnectionStrings["QLKARA"].ConnectionString;
			conn = new SqlConnection(connectString);
		}
		public bool checkPhong(int maphong)
		{
			conn.Open();
			string sql = "select count(*) from phong where TrangThai = 1 and MaPhong = @maphong";
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@maphong", maphong);
			int ketqua = (int)cmd.ExecuteScalar();
			conn.Close();
			return ketqua >= 1;
		}
		// Get tất cả các phòng còn trống chưa có người đặt
		public List<DSPhong> getphongTrong()
		{
			List<DSPhong> dsPhong = new List<DSPhong>();
			string sql = "select * from phong where TrangThai = 0";
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				DSPhong phong = new DSPhong();
				phong.MaPhong = (int)reader["MaPhong"];
				phong.TenPhong = reader["TenPhong"].ToString();
				phong.TrangThai = (Boolean)reader["TrangThai"];
				phong.MaLoaiPhong = (int)reader["MaLoaiPhong"];
				dsPhong.Add(phong);
			}
			conn.Close();
			return dsPhong;
		}
		// Get danh sách tất cả các phòng 
		public List<DSPhong> getAllPhong()
		{
			List<DSPhong> dsPhong = new List<DSPhong>();
			string sql = "Select * From phong,loaiphong where Phong.MaLoaiPhong = loaiphong.MaLoaiPhong ORDER BY MaPhong ASC";
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				DSPhong phong = new DSPhong();
				phong.MaPhong = (int)reader["MaPhong"];
				phong.TenPhong = reader["TenPhong"].ToString();
				phong.TrangThai = (Boolean)reader["TrangThai"];
				phong.MaLoaiPhong = (int)reader["MaLoaiPhong"];
				phong.TenLoaiPhong = (string)reader["TenLoaiPhong"];
				dsPhong.Add(phong);
			}
			conn.Close();
			return dsPhong;
		}
		// Khách hàng Thêm 1 đặt phòng
		public int ThemDatPhong(dsOrderPhong dsDatPhong)
		{
			string sql = "Insert into DatPhong(Hoten,sdt,thoigianvao,thoigianra,maphong) output INSERTED.MaDatPhong values (@hoten,@sdt,@timeIn,@timeOut,@maphong)";
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@hoten", dsDatPhong.HoTen);
			cmd.Parameters.AddWithValue("@sdt", dsDatPhong.SDT);
			cmd.Parameters.AddWithValue("@timeIn", dsDatPhong.thoigianvao);
			cmd.Parameters.AddWithValue("@timeOut", dsDatPhong.thoigianra);
			cmd.Parameters.AddWithValue("@maphong", dsDatPhong.MaPhong);
			int MaDatPhong = Convert.ToInt32(cmd.ExecuteScalar());
			conn.Close();
			return MaDatPhong;
		}
		// Cập nhật TrangThai của phòng là 1 (Đã dùng) sau khi phòng đó được đặt
		public void phongdaSuDung(int MaPhong)
		{
			string sql = "Update phong set TRANGTHAI = 1 where MaPhong=@maphong";
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("maphong", MaPhong);
			cmd.ExecuteNonQuery();
			conn.Close();
		}		
		// Cập nhật TrangThai của phòng là 0 (Phòng trống) sau khi thanh toán
		public void capnhatPhongTrong(int MaPhong)
		{
			string sql = "Update phong set TrangThai=0 where MaPhong=@maphong";
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@maphong", MaPhong);
			cmd.ExecuteNonQuery();
			conn.Close();
		}

		// Tạo hóa đơn HoaDon cho khách vừa đặt phòng
		public void taoHoaDon(int MaDatPhong, double soGio)
		{
			double tienPhong = soGio * 1500;
			float tienDichVu = 0;
			string sql = "Insert Into hoadon (MaDatPhong, soGio, giaTien, giaDichVu, TongTien,NgayGioTao) Values (@madatphong, @soGio, @tienPhong, @tienDV, @tongtien,@ngaygiotao)";
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@madatphong", MaDatPhong);
			cmd.Parameters.AddWithValue("@soGio", soGio);
			cmd.Parameters.AddWithValue("@tienphong", tienPhong);
			cmd.Parameters.AddWithValue("@tienDV", tienDichVu);
			cmd.Parameters.AddWithValue("@ngaygiotao", DateTime.Now.ToString());
			cmd.Parameters.AddWithValue("@tongtien", tienPhong);
			cmd.ExecuteNonQuery();
			conn.Close();
		}

		// Get ra danh sách đặt phòng đang ở vs MaDatPhong=0
		public List<dsOrderPhong> getdsOrderPhong()
		{
			string sql = "Select * From datphong, phong where datphong.MaPhong=phong.MaPhong and datphong.TrangThai=0 ORDER BY MaDatPhong DESC";
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			SqlDataReader reader = cmd.ExecuteReader();
			List<dsOrderPhong> ds = new List<dsOrderPhong>();
			while (reader.Read())
			{
				dsOrderPhong schedule = new dsOrderPhong();
				schedule.MaDatPhong = (int)reader["MaDatPhong"];
				schedule.HoTen = (string)reader["HoTen"];
				schedule.SDT = (string)reader["sdt"];
				
				schedule.MaPhong = (int)reader["MaPhong"];
				schedule.TenPhong = (string)reader["TenPhong"];
				schedule.thoigianvao = (DateTime)reader["thoigianvao"];
				schedule.thoigianra = (DateTime)reader["thoigianra"];
				schedule.TrangThai = (Boolean)reader["TrangThai"];

				ds.Add(schedule);
			}
			conn.Close();
			return ds;
		}

		// Get ra danh sách đặt phòng đã đi vs MaDatPhong=0
		public List<dsOrderPhong> getdatphong1()
		{
			string sql = "Select * From datphong, phong where datphong.MaPhong=phong.MaPhong and datphong.TrangThai=1 ORDER BY MaDatPhong DESC";
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			SqlDataReader reader = cmd.ExecuteReader();
			List<dsOrderPhong> li = new List<dsOrderPhong>();
			while (reader.Read())
			{
				dsOrderPhong schedule = new dsOrderPhong();
				schedule.MaDatPhong = (int)reader["MaDatPhong"];
				schedule.HoTen = (string)reader["HoTen"];
				schedule.SDT = (string)reader["sdt"];
				
				schedule.MaPhong = (int)reader["MaPhong"];
				schedule.TenPhong = (string)reader["TenPhong"];
				schedule.thoigianvao = (DateTime)reader["thoigianvao"];
				schedule.thoigianra = (DateTime)reader["thoigianra"];
				schedule.TrangThai = (Boolean)reader["TrangThai"];

				li.Add(schedule);
			}
			conn.Close();
			return li;
		}

		// Get danh sách loại phòng loaiphong
		public List<loaiphong> getRoomTypes()
		{
			List<loaiphong> li = new List<loaiphong>();
			string sql = "Select * From loaiphong";
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				loaiphong LoaiPhong = new loaiphong();
				LoaiPhong.MaLoaiPhong = (int)reader["MaLoaiPhong"];
				LoaiPhong.TenLoaiPhong = (string)reader["TenLoaiPhong"];
				li.Add(LoaiPhong);
			}
			conn.Close();
			return li;
		}

		// Thêm phòng vào bảng phong
		public void themPhong(DSPhong dsphong)
		{
			string sql = "Insert Into phong (TenPhong, TrangThai, MaLoaiPhong) Values (@TenPhong, @TrangThai, @MaLoaiPhong)";
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("TenPhong", dsphong.TenPhong);
			cmd.Parameters.AddWithValue("TrangThai", dsphong.TrangThai);
			cmd.Parameters.AddWithValue("MaLoaiPhong", dsphong.MaLoaiPhong);
			cmd.ExecuteNonQuery();
			conn.Close();
		}


		// Hiển thị danh sách hóa đơn chưa thanh toán
		public List<dshoadon> getHoaDon()
		{
			List<dshoadon> li = new List<dshoadon>();
			string sql = "Select * From hoadon, datphong where HoaDon.MaDatPhong=datphong.MaDatPhong AND hoadon.TrangThai=0 ORDER BY IDHoaDon DESC";
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				dshoadon bill = new dshoadon();
				bill.IDHoaDon = (int)reader["IDHoaDon"];
				bill.MaDatPhong = (int)reader["MaDatPhong"];
				bill.soGio = (int)reader["soGio"];
				bill.giaTien = Convert.ToDouble(reader["giaTien"]);
				bill.giaDichVu = Convert.ToDouble(reader["giaDichVu"]);
				bill.TongTien = Convert.ToDouble(reader["TongTien"]);
				bill.TrangThai = (Boolean)reader["TrangThai"];
				bill.HoTen = (string)reader["HoTen"];
				li.Add(bill);
			}
			conn.Close();
			return li;
		}

		// Hiển thị danh sách hóa đơn đã thanh toán
		public List<dshoadon> getHoaDon1()
		{
			List<dshoadon> li = new List<dshoadon>();
			string sql = "Select * From HoaDon, datphong where HoaDon.MaDatPhong=datphong.MaDatPhong AND hoadon.TrangThai=1 ORDER BY IDHoaDon DESC";
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				dshoadon bill = new dshoadon();
				bill.IDHoaDon = (int)reader["IDHoaDon"];
				bill.MaDatPhong = (int)reader["MaDatPhong"];
				bill.soGio = (int)reader["soGio"];
				bill.giaTien = Convert.ToInt32(reader["giaTien"]);
				bill.giaDichVu = Convert.ToInt32(reader["giaDichVu"]);
				bill.TongTien = Convert.ToInt32(reader["TongTien"]);
				bill.TrangThai = (Boolean)reader["TrangThai"];
				bill.HoTen = (string)reader["HoTen"];
				bill.sdt = (string)reader["sdt"];
				li.Add(bill);
			}
			conn.Close();
			return li;
		}

		// Xóa 1 phòng 
		public void deleteRoom(int MaPhong)
		{
			string sql = "Delete From phong Where MaPhong=@MaPhong";
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("MaPhong", MaPhong);
			cmd.ExecuteNonQuery();
			conn.Close();
		}

		// Lấy phòng theo mã phòng MaPhong
		public DSPhong get1Room(int MaPhong)
		{
			string sql = "Select * From phong, loaiphong where phong.MaLoaiPhong=loaiphong.MaLoaiPhong And MaPhong=@MaPhong";
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("MaPhong", MaPhong);
			SqlDataReader reader = cmd.ExecuteReader();
			DSPhong dsphong = null;
			if (reader.Read())
			{
				dsphong = new DSPhong();
				dsphong.MaPhong = (int)reader["MaPhong"];
				dsphong.TenPhong = (string)reader["TenPhong"];
				dsphong.TrangThai = (Boolean)reader["TrangThai"];
				dsphong.MaLoaiPhong = (int)reader["MaLoaiPhong"];
			}
			conn.Close();
			return dsphong;
		}

		// Cập nhật thông tin phòng
		public void updateRoom(DSPhong dsphong)
		{
			string sql = "Update phong Set TenPhong=@TenPhong, TrangThai=@TrangThai, MaLoaiPhong=@MaLoaiPhong Where MaPhong=@MaPhong";
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("TenPhong", dsphong.TenPhong);
			cmd.Parameters.AddWithValue("TrangThai", dsphong.TrangThai);
			cmd.Parameters.AddWithValue("MaLoaiPhong", dsphong.MaLoaiPhong);
			cmd.Parameters.AddWithValue("MaPhong", dsphong.MaPhong);
			cmd.ExecuteNonQuery();
			conn.Close();
		}

		// Thanh toán hóa đơn
		public void ThanhToanHoaDon(int IDHoaDon)
		{
			// Cập nhật TrangThai=1 là thành đã thanh toán
			conn.Open();
			string sql = "Update HoaDon Set TrangThai=1 OUTPUT INSERTED.MaDatPhong Where IDHoaDon=@IDHoaDon";
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("IDHoaDon", IDHoaDon);
			// Get last MaDatPhong updated
			int MaDatPhong = Convert.ToInt32(cmd.ExecuteScalar());

			// Cập nhật TrangThai=1 là người đặt phòng đã đi
			string sql_schedule = "Update datphong Set TrangThai=1 Where MaDatPhong=@MaDatPhong";
			SqlCommand cmd_schedule = new SqlCommand(sql_schedule, conn);
			cmd_schedule.Parameters.AddWithValue("MaDatPhong", MaDatPhong);
			cmd_schedule.ExecuteNonQuery();

			// Cập nhật TrangThai là 0 (Phòng trống) của MaPhong trong datphong
			string sql_room = "update phong set TrangThai=0 where MaPhong=(select datphong.MaPhong From datphong, phong where datphong.MaPhong=phong.MaPhong and datphong.MaDatPhong=@MaDatPhong)";
			SqlCommand cmd_room = new SqlCommand(sql_room, conn);
			cmd_room.Parameters.AddWithValue("MaDatPhong", MaDatPhong);
			cmd_room.ExecuteNonQuery();
			conn.Close();
		}

		// Xóa 1 đặt phòng
		public void deleteSchedue(int MaDatPhong)
		{
			conn.Open();
			// Cập nhật TrangThai là 0 (Phòng trống)
			string sql_room = "update phong set TrangThai=0 where MaPhong=(select datphong.MaPhong from datphong, phong where datphong.MaPhong=phong.MaPhong and datphong.MaDatPhong=@MaDatPhong)";
			SqlCommand cmd_room = new SqlCommand(sql_room, conn);
			cmd_room.Parameters.AddWithValue("@MaDatPhong", MaDatPhong);
			cmd_room.ExecuteNonQuery();

			string sql = "Delete from datphong Where MaDatPhong = @MaDatPhong";
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("@MaDatPhong", MaDatPhong);
			cmd.ExecuteNonQuery();

			conn.Close();
		}

		// Get 1 schedule theo MaDatPhong
		public dsOrderPhong get1Schedule(int MaDatPhong)
		{
			string sql = "Select * From datphong Where MaDatPhong=@MaDatPhong";
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("MaDatPhong", MaDatPhong);
			SqlDataReader reader = cmd.ExecuteReader();
			dsOrderPhong dsDatPhong = null;
			if (reader.Read())
			{
				dsDatPhong = new dsOrderPhong();
				dsDatPhong.MaDatPhong = (int)reader["MaDatPhong"];
				dsDatPhong.HoTen = (string)reader["HoTen"];
				dsDatPhong.SDT = (string)reader["sdt"];

				dsDatPhong.MaPhong = (int)reader["MaPhong"];
				dsDatPhong.thoigianvao = (DateTime)reader["thoigianvao"];
				dsDatPhong.thoigianra = (DateTime)reader["thoigianra"];
			}
			conn.Close();
			return dsDatPhong;
		}

		// Update schedule 
		public void updateSchedule(dsOrderPhong dsDatPhong)
		{
			string sql = "Update datphong Set HoTen=@HoTen, sdt=@sdt, MaPhong=@MaPhong, thoigianvao=@thoigianvao, thoigianra=@thoigianra Where MaDatPhong=@MaDatPhong";
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			cmd.Parameters.AddWithValue("MaDatPhong", dsDatPhong.MaDatPhong);
			cmd.Parameters.AddWithValue("HoTen", dsDatPhong.HoTen);
			cmd.Parameters.AddWithValue("sdt", dsDatPhong.SDT);
			cmd.Parameters.AddWithValue("MaPhong", dsDatPhong.MaPhong);
			cmd.Parameters.AddWithValue("thoigianvao", dsDatPhong.thoigianvao);
			cmd.Parameters.AddWithValue("thoigianra", dsDatPhong.thoigianra);
			cmd.ExecuteNonQuery();
			conn.Close();
		}
	}
}