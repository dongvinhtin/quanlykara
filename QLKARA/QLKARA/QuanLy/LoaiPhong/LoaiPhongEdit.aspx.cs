using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy
{
    public partial class LoaiPhongEdit : System.Web.UI.Page
    {
        DataUtil data = new DataUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TaiKhoan"] != null)
            {

            }
            else Response.Redirect("../../index.aspx");
            if (!IsPostBack)
            {
                loaiphong loaiphong = (loaiphong)Session["nn"];
                txtMaLoaiPhong.Text = Convert.ToString(loaiphong.MaLoaiPhong);
                txtTenLoaiPhong.Text = loaiphong.TenLoaiPhong;
                DataBind();
            }
        }
        protected void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                loaiphong loaiphong = new loaiphong();
                loaiphong.MaLoaiPhong = int.Parse(txtMaLoaiPhong.Text);
                loaiphong.TenLoaiPhong = txtTenLoaiPhong.Text;
                data.Capnhatloaiphong(loaiphong);
                msg.Text = "Bạn cập nhật thành công.";
            }
            catch (Exception ex)
            {

                msg.Text = "Có lỗi:" + ex;
            }
        }
    }
}