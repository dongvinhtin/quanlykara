using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy.Phong
{
    public partial class ThemPhong : System.Web.UI.Page
    {
		KHDatPhong data = new KHDatPhong();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{

				DDL_LoaiPhong.DataSource = data.getRoomTypes();
				DDL_LoaiPhong.DataValueField = "MaLoaiPhong";
				DDL_LoaiPhong.DataTextField = "TenLoaiPhong";
				DataBind();
			}
		}


		protected void btnThemPhong_Click(object sender, EventArgs e)
		{
			try
			{
				DSPhong ds= new DSPhong();
				ds.TenPhong = txtTenPhong.Text;
				ds.TrangThai = Convert.ToBoolean(DDL_TrangThai.SelectedValue);
				ds.MaLoaiPhong = Convert.ToInt32(DDL_LoaiPhong.SelectedValue);

				data.themPhong(ds);

				err_msg.ForeColor = System.Drawing.Color.Green;
				err_msg.Text = "Thêm phòng thành công!";
			}
			catch (Exception ex)
			{
				err_msg.ForeColor = System.Drawing.Color.Red;
				err_msg.Text = "Đã xảy ra lỗi: " + ex.Message;
			}
		}
	}
}