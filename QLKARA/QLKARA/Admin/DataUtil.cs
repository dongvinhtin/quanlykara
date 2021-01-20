using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace QLKARA
{
    public class DataUtil
    {
        SqlConnection conn;
        public DataUtil()
        {
            string connectString = ConfigurationManager.ConnectionStrings["QLKARA"].ConnectionString;
            conn = new SqlConnection(connectString);
        }
        // Phần loại phòng
        // Get danh sách loại phòng
        public List<loaiphong> getLoaiPhong()
        {
            List<loaiphong> dsloaiphong = new List<loaiphong>();
            string sql = "select * from loaiphong";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                loaiphong loaiphong = new loaiphong();
                loaiphong.MaLoaiPhong = (int)reader["MaLoaiPhong"];
                loaiphong.TenLoaiPhong = (string)reader["TenLoaiPhong"];
                dsloaiphong.Add(loaiphong);
            }
            conn.Close();
            return dsloaiphong;
        }
        //Thêm 1 loại phòng
        public void them_loaiphong(loaiphong loaiphong)
        {
            conn.Open();
            string sql = "insert into loaiphong values(@name)";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", loaiphong.TenLoaiPhong);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Xóa một loại phòng
        public void xoa_loaiphong(int maloaiphong)
        {
            conn.Open();
            String sql = "delete from loaiphong where maloaiphong=@maloaiphong";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maloaiphong", maloaiphong);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Lấy ra 1 phòng
        public loaiphong Layra1phong(int maloaiphong)
        {
            List<loaiphong> li = new List<loaiphong>();
            string sql = "select * from loaiphong where maloaiphong=@maloaiphong";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@maloaiphong", maloaiphong);
            loaiphong loaiphong = null;
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                loaiphong = new loaiphong();
                loaiphong.MaLoaiPhong = (int)rd["MaLoaiPhong"];
                loaiphong.TenLoaiPhong = (string)rd["TenLoaiPhong"];
            }
            conn.Close();
            return loaiphong;
        }

        //Cập nhật loại phòng
        public void Capnhatloaiphong(loaiphong loaiphong)
        {
            conn.Open();
            string sql = "update loaiphong set TenLoaiPhong=@name where MaLoaiPhong=@maloaiphong";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", loaiphong.TenLoaiPhong);
            cmd.Parameters.AddWithValue("@maloaiphong", loaiphong.MaLoaiPhong);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}