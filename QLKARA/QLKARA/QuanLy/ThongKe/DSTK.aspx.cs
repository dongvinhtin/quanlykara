using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy.ThongKe
{
    public partial class DSTK : System.Web.UI.Page
    {
        Services svc = new Services();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TaiKhoan"] != null)
            {

            }
            else Response.Redirect("../../index.aspx");
        }
        public void hienthi()
        {
            var from = DateTime.Parse(Calendar1.SelectedDate.ToString());
            var to = DateTime.Parse(Calendar2.SelectedDate.ToString());
            GV_HoaDon.DataSource = svc.getHoaDon(from, to);
            txtsoLuong.Text = svc.soHoaDon(from,to);
            txtTongTien.Text = svc.tongTienHoaDon(from,to);
            DataBind();
        }
        protected void btnHienthi_Click(object sender, EventArgs e)
        {
            if (DateTime.Parse(Calendar1.SelectedDate.ToString()) > DateTime.Parse(Calendar2.SelectedDate.ToString()))
            {
                err_msg.Text = "Khoảng thời gian không hợp lệ";
                GV_HoaDon.Visible= false;
                lb1.Visible = false;
                lb.Visible = false;
                txtsoLuong.Visible = false;
                txtTongTien.Visible = false;
                GV_HoaDon.Visible = false;
            }
            else
            {
                err_msg.Text = "";
                hienthi();
                GV_HoaDon.Visible = true;
                lb1.Visible = true;
                lb.Visible = true;
                txtsoLuong.Visible = true;
                txtTongTien.Visible = true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtDateIn.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            Calendar1.Visible = false;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtDateOut.Text = Calendar2.SelectedDate.ToString("dd/MM/yyyy");
            Calendar2.Visible = false;
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Calendar2.Visible = true;
        }
        int stt = 1;
        protected void GV_HoaDon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_HoaDon.PageIndex = e.NewPageIndex;
            int trang_thu = e.NewPageIndex;
            int so_dong = GV_HoaDon.PageSize;
            stt = trang_thu * so_dong + 1;
            hienthi();
        }
    }
}