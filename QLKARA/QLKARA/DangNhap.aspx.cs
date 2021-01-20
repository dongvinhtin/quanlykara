using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using QLKARA;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    AdminDAO adminDAO = new AdminDAO();
    protected void Button1_Click(object sender, EventArgs e)
    {
        Admin admin = new Admin()
        {
            TaiKhoan = txtTK.Text,
            MatKhau = txtMK.Text,
        };
        if (adminDAO.Dangnhap(admin))
        {
            Session["TaiKhoan"] = txtTK.Text;
            Response.Redirect("QuanLy/Phong/Phong.aspx");
        }
        //---------------------------
        else
            Label1.Text = "Tài khoản hoặc mật khẩu không đúng";
    }
}