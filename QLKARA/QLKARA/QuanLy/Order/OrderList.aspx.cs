using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy.Order
{
    public partial class OrderList : System.Web.UI.Page
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

				DDL_Order.DataSource = orderDichVu.getPhong();
				DDL_Order.DataValueField = "MaDatPhong";
				DDL_Order.DataTextField = "TenPhong";
				DataBind();
			}
		}
		public void hienthi()
		{
			var MaDatPhong = int.Parse(DDL_Order.SelectedValue);
			grdOrderlistAdmin.DataSource = orderDichVu.getOrder(MaDatPhong);
			DataBind();
		}

		protected void btnodered_Command1(object sender, CommandEventArgs e)
		{
			if (e.CommandName == "btnorderred")
			{
				int x = Convert.ToInt16(e.CommandArgument);
				orderDichVu.updateOrder(x);
				hienthi();
			}
		}
		protected void btnhienthiorders_Click(object sender, EventArgs e)
		{
			hienthi();
		}
	}
}