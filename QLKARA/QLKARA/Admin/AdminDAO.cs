using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLKARA
{
    public class AdminDAO
    {
        string connectString = ConfigurationManager.ConnectionStrings["QLKARA"].ConnectionString;

        public bool Dangnhap(Admin admin)
        {
            string sql = @"select * from admin where taikhoan=@TK and matkhau=@MK";
            SqlConnection connection = new SqlConnection(connectString);
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@TK", admin.TaiKhoan);
            command.Parameters.AddWithValue("@MK", admin.MatKhau);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            else return false;
        }
    }
}