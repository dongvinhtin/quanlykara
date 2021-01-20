using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy.Phong
{
	public partial class EditPhong : System.Web.UI.Page
	{
		KHDatPhong data = new KHDatPhong();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				DSPhong dsphong = (DSPhong)Session["room"];
				txtMaPhong.Text = dsphong.MaPhong.ToString();
				txtTenPhong.Text = dsphong.TenPhong;

				DDL_LoaiPhong.DataSource = data.getRoomTypes();
				DDL_LoaiPhong.DataValueField = "MaLoaiPhong";
				DDL_LoaiPhong.DataTextField = "TenLoaiPhong";
				DataBind();
				DDL_LoaiPhong.SelectedValue = dsphong.MaLoaiPhong.ToString();
				DDL_TrangThai.Items.FindByValue(dsphong.TrangThai.ToString()).Selected = true;


			}
		}

		protected void btnSuaPhong_Click(object sender, EventArgs e)
		{
			try
			{
				DSPhong dsPhong= new DSPhong();
				dsPhong.MaPhong = int.Parse(txtMaPhong.Text);
				dsPhong.TenPhong = txtTenPhong.Text;
				dsPhong.TrangThai = Convert.ToBoolean(DDL_TrangThai.SelectedValue);
				dsPhong.MaLoaiPhong = int.Parse(DDL_LoaiPhong.SelectedValue);

				data.updateRoom(dsPhong);

				err_msg.ForeColor = System.Drawing.Color.Green;
				err_msg.Text = "Cập nhật phòng thành công!";
			}
			catch (Exception ex)
			{
				err_msg.ForeColor = System.Drawing.Color.Red;
				err_msg.Text = "Da xay ra loi: " + ex.Message;
			}
		}
	}
}