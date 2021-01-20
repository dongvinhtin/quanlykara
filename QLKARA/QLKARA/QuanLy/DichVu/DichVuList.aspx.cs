using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy.DichVu
{
    public partial class DichVuList : System.Web.UI.Page
    {
        getDanhMuc danhMuc = new getDanhMuc();
        Services svc = new Services();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TaiKhoan"] != null)
            {

            }
            else Response.Redirect("../../index.aspx");
            //lay data ra dropdownlist
            if (!IsPostBack)
            {
                DDL_Danhmuc.DataSource = danhMuc.GetDanhMuc();
                DDL_Danhmuc.DataTextField = "tendanhmuc";
                DDL_Danhmuc.DataValueField = "madanhmuc";
                DataBind();
            }
        }
        public void hienthi()
        {
            var madanhmuc = int.Parse(DDL_Danhmuc.SelectedValue);
            GV_DSDichVu.DataSource = svc.getServices(madanhmuc);
            DataBind();
        }
        protected void btnhienthi_Click(object sender, EventArgs e)
        {
            hienthi();
        }
        protected void deleteservices_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "deleteservices")
            {
                int xoa = Convert.ToInt16(e.CommandArgument);
                svc.xoaDichVu(xoa);
                hienthi();
            }
        }
        protected void updateservices_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "updateservices")
            {
                int update = Convert.ToInt16(e.CommandArgument);
                DSDichVu madichvu = svc.layra1dv(update);
                Session["madichvu"] = madichvu;
                Response.Redirect("DichVuEdit.aspx");
            }
        }
    }
}