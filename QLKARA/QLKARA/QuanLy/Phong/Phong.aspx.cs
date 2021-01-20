using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy.Phong
{
    public partial class Phong : System.Web.UI.Page
    {
		KHDatPhong data = new KHDatPhong();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["TaiKhoan"] != null)
			{

			}
			else Response.Redirect("../../index.aspx");
			if (!IsPostBack)
				DanhSachDatPhong();

		}

		private void DanhSachDatPhong()
		{
			GV_DSDatPhong.DataSource = data.getAllPhong();
			DataBind();
		}
		int stt = 1;

		public string get_stt()

		{

			return Convert.ToString(stt++);

		}
		protected void Xoa_Click(object sender, CommandEventArgs e)
		{
			if (e.CommandName == "xoa")
			{
				int loaiphong = Convert.ToInt16(e.CommandArgument);
				data.deleteRoom(loaiphong);
				DanhSachDatPhong();
			}
		}

		protected void Sua_Click(object sender, CommandEventArgs e)
		{
			if (e.CommandName == "sua")
			{
				int room_id = Convert.ToInt16(e.CommandArgument);
				DSPhong dsphong= data.get1Room(room_id);
				Session["room"] = dsphong;
				Response.Redirect("EditPhong.aspx");
			}
		}

        protected void GV_DSDatPhong_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
			GV_DSDatPhong.PageIndex = e.NewPageIndex;   //trang hien tai

			int trang_thu = e.NewPageIndex;      //the hien trang thu may

			int so_dong = GV_DSDatPhong.PageSize;       //moi trang co bao nhieu dong

			stt = trang_thu * so_dong + 1;

			DanhSachDatPhong();
		}
    }
}