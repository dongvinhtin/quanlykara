using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy.HoaDon
{
    public partial class HoaDonList : System.Web.UI.Page
    {
		KHDatPhong data = new KHDatPhong();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["TaiKhoan"] != null)
			{

			}
			else Response.Redirect("../../index.aspx");
			if (!IsPostBack)
				DanhSachHoaDon();
		}

		private void DanhSachHoaDon()
		{
			grvDSHoaDon.DataSource = data.getHoaDon();
			DataBind();
		}

		protected void ThanhToan_Click(object sender, CommandEventArgs e)
		{
			if (e.CommandName == "ThanhToan")
			{
				int bill_id = Convert.ToInt16(e.CommandArgument);
				data.ThanhToanHoaDon(bill_id);
				DanhSachHoaDon();
			}
		}
		int stt = 1;

		public string get_stt()

		{

			return Convert.ToString(stt++);

		}
		protected void grvDSHoaDon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
			grvDSHoaDon.PageIndex = e.NewPageIndex;
			int trang_thu = e.NewPageIndex;
			int so_dong = grvDSHoaDon.PageSize;
			stt = trang_thu * so_dong + 1;
			DanhSachHoaDon();
		}
    }
}