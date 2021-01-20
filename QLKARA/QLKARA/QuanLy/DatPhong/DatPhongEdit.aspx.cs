using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy.DatPhong
{
    public partial class DatPhongEdit : System.Web.UI.Page
    {
		KHDatPhong data = new KHDatPhong();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["TaiKhoan"] != null)
			{

			}
			else Response.Redirect("../../index.aspx");
			if (!IsPostBack)
			{
				dsOrderPhong dsOrderPhong = (dsOrderPhong)Session["datphong"];
				txtMaDatPhong.Text = dsOrderPhong.MaDatPhong.ToString();
				txtHoTen.Text = dsOrderPhong.HoTen;
				txtSDT.Text = dsOrderPhong.SDT;

				txtTimeIn.Text = dsOrderPhong.thoigianvao.ToString();
				txtTimeOut.Text = dsOrderPhong.thoigianra.ToString();


				DDL_MaPhong.DataSource = data.getAllPhong();
				DDL_MaPhong.DataValueField = "MaPhong";
				DDL_MaPhong.DataTextField = "TenPhong";
				DataBind();
				DDL_MaPhong.SelectedValue = dsOrderPhong.MaPhong.ToString();
				txtPhongCu.Text = dsOrderPhong.MaPhong.ToString();
			}
		}
		protected void btnSuaDatPhong_Click(object sender, EventArgs e)
		{
				dsOrderPhong dsOrderPhong = new dsOrderPhong();
				dsOrderPhong.MaDatPhong = int.Parse(txtMaDatPhong.Text);
				dsOrderPhong.HoTen = txtHoTen.Text;
				dsOrderPhong.SDT = txtSDT.Text;
				dsOrderPhong.thoigianvao = DateTime.Parse(txtTimeIn.Text);
				dsOrderPhong.thoigianra = DateTime.Parse(txtTimeOut.Text);
				dsOrderPhong.MaPhong = int.Parse(DDL_MaPhong.Text);

				data.updateSchedule(dsOrderPhong);
				// Cập nhật room_status phòng vừa đặt là 1 (Đã dùng)
				data.phongdaSuDung(dsOrderPhong.MaDatPhong);

				err_msg.ForeColor = System.Drawing.Color.Green;
				err_msg.Text = "Cập nhật đặt phòng thành công!";
	
		}
	}
}