using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace QLKARA
{
    public class Services
    {
        SqlConnection conn;
        public Services()
        {
            string connectString = ConfigurationManager.ConnectionStrings["QLKARA"].ConnectionString;
            conn = new SqlConnection(connectString);
        }
        public List<DSDichVu> getAllDichVu()
        {
            List<DSDichVu> sudungDV = new List<DSDichVu>();
            conn.Open();
            string sql = "select * from dichvu";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DSDichVu dSDichVu = new DSDichVu();
                dSDichVu.MaDichVu = (int)reader["MaDichVu"];
                dSDichVu.TenDichVu = (string)reader["TenDichVu"];
                dSDichVu.Gia = (double)reader["Gia"];
                dSDichVu.danhmuc = (int)reader["danhmuc"];
                dSDichVu.MoTa = (string)reader["MoTa"];
                sudungDV.Add(dSDichVu);
            }
            conn.Close();
            return sudungDV;
        }
        // lay DSDichVu theo cat_id
        public List<DSDichVu> getServices(int danhmuc)
        {
            List<DSDichVu> li = new List<DSDichVu>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from dichvu,danh_muc where dichvu.danhmuc=danh_muc.danhmuc and dichvu.danhmuc='" + danhmuc + "'", conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DSDichVu svc = new DSDichVu();
                svc.MaDichVu = (int)rd["MaDichVu"];
                svc.TenDichVu = (string)rd["TenDichVu"];
                svc.Gia = (double)rd["Gia"];
                svc.danhmuc = (int)rd["danhmuc"];
                svc.MoTa = (string)rd["MoTa"];
                li.Add(svc);
            }
            conn.Close();
            return li;
        }
        public void xoaDichVu(int MaDichVu)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from dichvu where MaDichVu=" + MaDichVu + "", conn);
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("delete from sudungdv where MaDichVu=" + MaDichVu + "", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //them dich vu
        public void themDichVu(DSDichVu dSDichVu)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into dichvu values(@TenDichVu,@Gia,@danhmuc,@mota)", conn);
            cmd.Parameters.AddWithValue("@TenDichVu", dSDichVu.TenDichVu);
            cmd.Parameters.AddWithValue("@Gia", dSDichVu.Gia);
            cmd.Parameters.AddWithValue("@danhmuc", dSDichVu.danhmuc);
            cmd.Parameters.AddWithValue("@mota", dSDichVu.MoTa);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //lay ra 1 dich vu
        public DSDichVu layra1dv(int MaDichVu)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from dichvu where dichvu.madichvu=" +MaDichVu + "", conn);
            DSDichVu dSDichVu = null;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dSDichVu = new DSDichVu();
                dSDichVu.MaDichVu = (int)reader["MaDichVu"];
                dSDichVu.TenDichVu = (string)reader["TenDichVu"];
                dSDichVu.Gia = (double)reader["Gia"];
                dSDichVu.danhmuc = (int)reader["danhmuc"];
                dSDichVu.MoTa = (string)reader["MoTa"];
            }
            conn.Close();
            return dSDichVu;
        }

        //cap nhat dich vu
        public void capNhatDV(DSDichVu dSDichVu)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update dichvu set TenDichVu=N'" + dSDichVu.TenDichVu + "', Gia=" + dSDichVu.Gia + ", danhmuc=" + dSDichVu.danhmuc 
                + ",MoTa=N'" + dSDichVu.MoTa + "' where MaDichVu=" + dSDichVu.MaDichVu + "", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //lay gia dich vu
        public double getTien(int MaDichVu)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from dichvu where dichvu.MaDichVu=" + MaDichVu + "", conn);
            double pr = 0;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
                pr = (double)rd["Gia"];
            conn.Close();
            return pr;
        }
        // LayThongKeHoaDon
        public List<dshoadon> getHoaDon(DateTime from,DateTime to)
        { 
            List<dshoadon> dshoadons = new List<dshoadon>();
            conn.Open();
            to = to.AddDays(1);
            string sql = "select * from HOADON where NgayGioTao >= @from and NgayGioTao <= @to";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@from",from);
            cmd.Parameters.AddWithValue("@to", to);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dshoadon dshoadon = new dshoadon();
                dshoadon.MaDatPhong = (int)reader["MaDatPhong"];
                dshoadon.IDHoaDon = (int)reader["IDHoaDon"];
                dshoadon.getDate_in = (string)reader["NgayGioTao"].ToString();
                dshoadon.TongTien = (double)reader["TongTien"];
                dshoadons.Add(dshoadon);
            }
            conn.Close();
            return dshoadons;
        }
        public string tongTienHoaDon(DateTime from, DateTime to)
        {
            conn.Open();
            to = to.AddDays(1);
            string sql = "select sum(TongTien) from hoadon where NgayGioTao >= @from and NgayGioTao <= @to";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", to);
            object tongTien = cmd.ExecuteScalar();
            conn.Close();
            return Convert.ToString(tongTien);
        }
        public string soHoaDon(DateTime from, DateTime to)
        {
            conn.Open();
            to = to.AddDays(1);
            string sql = "select count(*) from hoadon where NgayGioTao >= @from and NgayGioTao <= @to";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@from", from);
            cmd.Parameters.AddWithValue("@to", to);
            object hoadon = cmd.ExecuteScalar();
            conn.Close();
            return Convert.ToString(hoadon);
        }
        public List<DSsudungDV> Getsudungdv(int MaDichVu)
        {
            List<DSsudungDV> li = new List<DSsudungDV>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select sudungdv.MaDichVu,sudungdv.SoLuong,sudungdv.Gia from dichvu,sudungdv where dichvu.MaDichVu=sudungdv.MaDichVu and sudungdv.MaDichVu='" + MaDichVu + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DSsudungDV svc = new DSsudungDV();
                svc.MaDichVu = (int)reader["MaDichVu"];
                svc.soLuong = (int)reader["SoLuong"];
                svc.Gia = (double)reader["Gia"];
                li.Add(svc);
            }
            conn.Close();
            return li;
        }

        public string tongTien(int MaDichVu)//////////////////////////////////////////////
        {
            conn.Open();
            string sql = "select sum(Gia) from sudungdv where MaDichVu='" + MaDichVu + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            object tongTien = cmd.ExecuteScalar();
            conn.Close();
            return Convert.ToString(tongTien);
        }
        public string soLuong(int MaDichVu)//////////////////////////////////////////////
        {
            conn.Open();
            string sql = "select sum(soLuong) from sudungdv where MaDichVu='" + MaDichVu + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            object soluong = cmd.ExecuteScalar();
            conn.Close();
            return Convert.ToString(soluong);
        }
    }
}