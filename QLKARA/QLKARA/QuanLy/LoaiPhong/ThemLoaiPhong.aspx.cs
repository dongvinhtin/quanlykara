using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy
{
    public partial class ThemLoaiPhong : System.Web.UI.Page
    {
        DataUtil data = new DataUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TaiKhoan"] != null)
            {

            }
            else Response.Redirect("../../index.aspx");
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                loaiphong loaiphong = new loaiphong();
                loaiphong.TenLoaiPhong = txtTenLoaiPhong.Text;
                data.them_loaiphong(loaiphong);
                msg.ForeColor = System.Drawing.Color.Red;
                msg.Text = "Thêm thành công";
            }
            catch (Exception ex)
            {

                msg.Text = "Không thêm được,có lỗi:" + ex.Message;
            }
        }
    }
}