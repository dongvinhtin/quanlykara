using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace QLKARA
{
    public partial class DatPhong : System.Web.UI.Page
    {
        KHDatPhong datPhong = new KHDatPhong();
        protected void Page_Load(object sender, EventArgs e)
        {
            RandomSlide();
            if (!IsPostBack)
            {
                DDL_Phong.DataSource = datPhong.getphongTrong();
                DDL_Phong.DataTextField = "TenPhong";
                DDL_Phong.DataValueField = "MaPhong";
                DataBind();
            }
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            RandomSlide();
        }

        private void RandomSlide()
        {
            Random r = new Random();
            int n = r.Next(1, 5);
            imgSlide.ImageUrl = "assets/images/ban" + n + ".jpg";
        }

        protected void btn_BookRoom_Click(object sender, EventArgs e)
        {
            dsOrderPhong orderPhong = new dsOrderPhong();
            orderPhong.HoTen = txtFullname.Text;
            orderPhong.SDT = txtPhone.Text;
            orderPhong.thoigianvao = DateTime.Parse(txtTimeStart.Text);
            orderPhong.thoigianra = DateTime.Parse(txtTimeEnd.Text);
            orderPhong.MaPhong = int.Parse(DDL_Phong.SelectedValue);
            DateTime DateIn = (orderPhong.thoigianvao);
            DateTime DateOut = (orderPhong.thoigianra);
            TimeSpan tmp = DateOut.Subtract(DateIn);
            double soGio = tmp.TotalMinutes;
            if (DateTime.Parse(txtTimeStart.Text)> DateTime.Parse(txtTimeEnd.Text))
            {
                err_msg.ForeColor = System.Drawing.Color.Aqua;
                err_msg.Text = "Khoảng thời gian không hợp lệ";
            }
            else
            {
                try
                {
                    var MaPhong = int.Parse(DDL_Phong.SelectedValue);
                    if (datPhong.checkPhong(MaPhong))
                    {
                        err_msg.Text = "Phòng này đã có người đặt";
                    }
                    else
                    {
                        // Thêm đặt phòng
                        Int32 MaDatPhong = datPhong.ThemDatPhong(orderPhong);

                        // Cập nhật trạng thái phòng = 1
                        datPhong.phongdaSuDung(orderPhong.MaPhong);

                        datPhong.taoHoaDon(MaDatPhong, soGio);

                        err_msg.ForeColor = System.Drawing.Color.Aqua;
                        err_msg.Text = "Bạn đã đặt phòng thành công!";
                    }
                }
                catch (Exception ex)
                {
                    err_msg.ForeColor = System.Drawing.Color.Red;
                    err_msg.Text = "Đã xảy ra lỗi: " + ex.Message;
                }
            }
        }
    }
}