using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy.Order
{
    public partial class OrderList_Done : System.Web.UI.Page
    {
        OrderDichVu orderDichVu = new OrderDichVu();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TaiKhoan"] != null)
            {

            }
            else Response.Redirect("../../index.aspx");
            if (!IsPostBack)
            {
                drporderdone.DataSource = orderDichVu.getPhong();
                drporderdone.DataValueField = "MaDatPhong";
                drporderdone.DataTextField = "TenPhong";
                DataBind();
            }
        }
        public void hienthi()
        {
            var MaDatPhong = int.Parse(drporderdone.SelectedValue);
            grdOrderdonelistAdmin.DataSource = orderDichVu.getOrderdone(MaDatPhong);
            DataBind();
        }
        protected void btnhienthiorderdone_Click(object sender, EventArgs e)
        {
            hienthi();
        }
    }
}