using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA
{
    public partial class DatDichVu : System.Web.UI.Page
    {
        OrderDichVu OrderDichVu = new OrderDichVu();
        Services services = new Services();
        protected void Page_Load(object sender, EventArgs e)
        {
            RandomSlide();
            if (!IsPostBack)
            {
                DDL_Phong.DataSource = OrderDichVu.getPhong();
                DDL_Phong.DataValueField = "MaDatPhong";
                DDL_Phong.DataTextField = "TenPhong";

                DDL_SanPham.DataSource = services.getAllDichVu();
                DDL_SanPham.DataTextField = "TenDichVu";
                DDL_SanPham.DataValueField = "MaDichVu";
                DataBind();
            }
        }
        protected void Timer2_Tick(object sender, EventArgs e)
        {
            RandomSlide();
        }
        private void RandomSlide()
        {
            Random r = new Random();
            int n = r.Next(1, 4);
            imgSlide.ImageUrl = "assets/images/ban" + n + ".jpg";
        }
        protected void btnOderUser_Click(object sender, EventArgs e)
        {
                DSsudungDV dSsudung = new DSsudungDV();
                dSsudung.MaDatPhong = int.Parse(DDL_Phong.SelectedValue.ToString());
                dSsudung.MaDichVu = int.Parse(DDL_SanPham.SelectedValue.ToString());
                dSsudung.soLuong = int.Parse(txtpickquantity.Text.ToString());
                dSsudung.IDHoaDon = OrderDichVu.getMaHoaDon(int.Parse(DDL_Phong.SelectedValue.ToString()));
                OrderDichVu.themOrder(dSsudung);
                OrderDichVu.updateService_price(int.Parse(DDL_Phong.SelectedValue.ToString()));
                OrderDichVu.updateTotal_price(int.Parse(DDL_Phong.SelectedValue.ToString()));
                err_msg.ForeColor = System.Drawing.Color.Aqua;
                err_msg.Text = "Đặt dịch vụ thành công";
        }
    }
}