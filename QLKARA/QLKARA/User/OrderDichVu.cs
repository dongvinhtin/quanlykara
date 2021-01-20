using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace QLKARA
{
    public class OrderDichVu
    {
        SqlConnection conn;
        Services svc = new Services();
        public OrderDichVu()
        {
            string connectString = ConfigurationManager.ConnectionStrings["QLKARA"].ConnectionString;
            conn = new SqlConnection(connectString);
        }
        // Lay madatphong va maphong(Tin)
        public List<DSsudungDV> getPhong()
        {
            List<DSsudungDV> dssdDV = new List<DSsudungDV>();
            conn.Open();
            string sql = "select * from datphong,phong where datphong.maphong = phong.maphong and datphong.TrangThai = 0";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                DSsudungDV dSsudungDV = new DSsudungDV();
                dSsudungDV.MaDatPhong = (int)reader["MaDatPhong"];
                dSsudungDV.TenPhong = (string)reader["TenPhong"];
                dssdDV.Add(dSsudungDV);
            }
            conn.Close();
            return dssdDV;
        }
        // lay du lieu ra gridview(huy)
        public List<DSsudungDV> getOrder(int MaDatPhong)
        {
            List<DSsudungDV> dssdDV = new List<DSsudungDV>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from sudungdv,datphong,phong,hoadon,dichvu,danh_muc where sudungdv.MaDatPhong=datphong.MaDatPhong and datphong.MaPhong=phong.MaPhong and sudungdv.IDHoaDon=hoadon.IDHoaDon and sudungdv.MaDichVu=dichvu.MaDichVu and dichvu.danhmuc=danh_muc.danhmuc and datphong.TrangThai=0 and sudungdv.TrangThai=0 and sudungdv.MaDatPhong=" + MaDatPhong + "",conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                DSsudungDV ssudungDV = new DSsudungDV();
                ssudungDV.madatdv = (int)reader["madatdv"];
                ssudungDV.MaDatPhong = (int)reader["MaDatPhong"];
                ssudungDV.MaDichVu = (int)reader["MaDichVu"];
                ssudungDV.soLuong = (int)reader["SoLuong"];
                ssudungDV.IDHoaDon = (int)reader["IDHoaDon"];
                ssudungDV.HoTen = (string)reader["HoTen"];
                ssudungDV.MaPhong = (int)reader["MaPhong"];
                ssudungDV.TenDichVu = (string)reader["TenDichVu"];
                ssudungDV.Gia = (double)reader["Gia"];
                ssudungDV.Order_Gia = (double)(ssudungDV.soLuong * svc.getTien(ssudungDV.MaDichVu));
                dssdDV.Add(ssudungDV);

            }
            conn.Close();
            return dssdDV;
        }
        // lay nhung order da xong(huy)
        public List<DSsudungDV> getOrderdone(int MaDatPhong)
        {
            List<DSsudungDV> dSsudung = new List<DSsudungDV>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from sudungdv,datphong,phong,hoadon,dichvu,danh_muc where sudungdv.MaDatPhong=datphong.MaDatPhong and datphong.MaPhong=phong.MaPhong and sudungdv.IDHoaDon=hoadon.IDHoaDon and sudungdv.MaDichVu=dichvu.MaDichVu and dichvu.danhmuc=danh_muc.danhmuc and datphong.TrangThai=0 and sudungdv.TrangThai=1 and sudungdv.MaDatPhong=" + MaDatPhong + "", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DSsudungDV suDungDV = new DSsudungDV();
                suDungDV.madatdv = (int)reader["madatdv"];
                suDungDV.MaDatPhong = (int)reader["MaDatPhong"];
                suDungDV.MaDichVu = (int)reader["MaDichVu"];
                suDungDV.soLuong = (int)reader["SoLuong"];
                suDungDV.Order_Gia = (double)(suDungDV.soLuong * svc.getTien(suDungDV.MaDichVu));
                suDungDV.IDHoaDon = (int)reader["IDHoaDon"];
                suDungDV.HoTen = (string)reader["HoTen"];
                suDungDV.TenPhong = (string)reader["Tenphong"];
                suDungDV.TenDichVu = (string)reader["TenDichVu"];
                dSsudung.Add(suDungDV);
            }
            conn.Close();
            return dSsudung;
        }
        // Them order(tin)
        public void themOrder(DSsudungDV dSsudung)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into sudungdv values(@MaDatPhong,@MaDichVu,@SoLuong,@Gia,@IDHoaDon,@TrangThai)", conn);
            cmd.Parameters.AddWithValue("@MaDatPhong", dSsudung.MaDatPhong);
            cmd.Parameters.AddWithValue("@MaDichVu", dSsudung.MaDichVu);
            cmd.Parameters.AddWithValue("@SoLuong", dSsudung.soLuong);
            cmd.Parameters.AddWithValue("@Gia", dSsudung.soLuong * svc.getTien(dSsudung.MaDichVu));
            cmd.Parameters.AddWithValue("@IDHoaDon", dSsudung.IDHoaDon);
            cmd.Parameters.AddWithValue("@TrangThai", false);//chưa thanh toán
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        // lay IDHoaDon(huy)
        public int getMaHoaDon(int MaDatPhong)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from hoadon where hoadon.MaDatPhong=" + MaDatPhong + "", conn);
            int mahoadon = 0;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                mahoadon = (int)reader["IDHoaDon"];
            conn.Close();
            return mahoadon;
        }
        //update order(huy)
        public void updateOrder(int madatdv)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update sudungdv set TrangThai=1 where madatdv=" + madatdv + "", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //xoa order(huy)
        public void deleteOrder(int madatdv)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from sudungdv where madatdv=" + madatdv + "", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //cap nhat gia dich vu va tong gia hoa don trong hoa don(Tin)
        public void updateService_price(int MaHoaDon)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update hoadon set giaDichVu=(select sum(Gia) as price_check from sudungdv where IDHoaDon = "+MaHoaDon+") where IDHoaDon =" +MaHoaDon+"",conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        // tong tien(Tin)
        public void updateTotal_price(int ID_HoaDon)
        {
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("update hoadon set TongTien=(select sum(giaDichVu+giaTien) as price_check2 from hoadon where IDHoaDon=" + ID_HoaDon+ ") where IDHoaDon=" + ID_HoaDon + "", conn);
            cmd2.ExecuteNonQuery();
            conn.Close();
        }
    }
}