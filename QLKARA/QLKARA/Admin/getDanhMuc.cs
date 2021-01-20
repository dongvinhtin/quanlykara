using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace QLKARA
{
    public class getDanhMuc
    {
        SqlConnection conn;
        public getDanhMuc()
        {
            string connectString = ConfigurationManager.ConnectionStrings["QLKARA"].ConnectionString;
            conn = new SqlConnection(connectString);
        }
        // lấy dữ liệu danh mục
        public List<danhMuc> GetDanhMuc()
        {
            List<danhMuc> dsdanhmuc = new List<danhMuc>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from danh_muc",conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                danhMuc danhMuc = new danhMuc();
                danhMuc.madanhmuc = (int)reader["danhmuc"];
                danhMuc.tendanhmuc = (string)reader["tendanhmuc"];
                dsdanhmuc.Add(danhMuc);
            }
            conn.Close();
            return dsdanhmuc;
        }
        // lấy 1 danh mục
        public danhMuc get1danhMuc(int madanhmuc)
        {
            danhMuc danhMuc = new danhMuc();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * From danh_muc where danhmuc=@madanhmuc", conn);
            cmd.Parameters.AddWithValue("@madanhmuc", madanhmuc);
            danhMuc = null;
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                danhMuc = new danhMuc();
                danhMuc.madanhmuc = (int)rd["danhmuc"];
                danhMuc.tendanhmuc = (string)rd["tendanhmuc"];
            }
            conn.Close();
            return danhMuc;
        }

        // Tạo thêm danh mục
        public void themDanhMuc(danhMuc danhMuc)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into danh_muc values(@ten)", conn);
            cmd.Parameters.AddWithValue("@ten", danhMuc.tendanhmuc);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void xoadanhMuc(int madanhmuc)
        {
            conn.Open();
            //SqlCommand cmd = new SqlCommand("delete from services where cat_id=" + cat_id + "", conn);
            //cmd.ExecuteNonQuery();
            //SqlCommand cmd2 = new SqlCommand("delete from orders where cat_id=" + cat_id + "", conn);
            //cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("delete from danh_muc where danhmuc=" + madanhmuc + "", conn);
            cmd1.ExecuteNonQuery();
            conn.Close();
        }

        //cap nhat category
        public void suaDanhMuc(danhMuc danhMuc)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update danh_muc set tendanhmuc=N'" + danhMuc.tendanhmuc + "' where danhmuc=" + danhMuc.madanhmuc + "", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}