using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy.DanhMuc
{
    public partial class DanhMucList : System.Web.UI.Page
    {
        getDanhMuc getDanhMuc = new getDanhMuc();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TaiKhoan"] != null)
            {

            }
            else Response.Redirect("../../index.aspx");
            if (!IsPostBack)
            {
                hienthi();
            }

        }
        public void hienthi()
        {
            GV_DanhMuc.DataSource = getDanhMuc.GetDanhMuc();
            DataBind();
        }

        protected void xoaDanhMuc_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "xoaDanhMuc")
            {
                int xoa = Convert.ToInt16(e.CommandArgument);
                getDanhMuc.xoadanhMuc(xoa);
                hienthi();
            }
        }

        protected void suaDanhMuc_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "suaDanhMuc")
            {
                int update = Convert.ToInt16(e.CommandArgument);
                danhMuc danhMuc = getDanhMuc.get1danhMuc(update);
                Session["ma"] = danhMuc;
                Response.Redirect("SuaDanhMuc.aspx");
            }
        }
        int stt = 1;

        public string get_stt()

        {

            return Convert.ToString(stt++);

        }
        protected void GV_DanhMuc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_DanhMuc.PageIndex = e.NewPageIndex;   //trang hien tai

            int trang_thu = e.NewPageIndex;      //the hien trang thu may

            int so_dong = GV_DanhMuc.PageSize;       //moi trang co bao nhieu dong

            stt = trang_thu * so_dong + 1;

            hienthi();
        }
    }
}