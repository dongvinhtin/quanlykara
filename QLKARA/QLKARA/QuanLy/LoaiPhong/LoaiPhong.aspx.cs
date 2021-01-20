using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy
{
    public partial class LoaiPhong : System.Web.UI.Page
    {
        DataUtil data = new DataUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TaiKhoan"] != null)
            {

            }
            else Response.Redirect("../../index.aspx");
            if (!IsPostBack)
                Hienthi();
        }

        private void Hienthi()
        {
            GV_LoaiPhong.DataSource = data.getLoaiPhong();
            DataBind();
        }

        protected void Xoa_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "xoa")
            {
                int maloaiphong = Convert.ToInt16(e.CommandArgument);
                data.xoa_loaiphong(maloaiphong);
                Hienthi();
            }
        }

        protected void Sua_Click(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "sua")
            {
                int ma = Convert.ToInt16(e.CommandArgument);
                loaiphong loaiphong = data.Layra1phong(ma);
                Session["nn"] = loaiphong;

                Response.Redirect("LoaiPhongEdit.aspx");
            }
        }
    }
}