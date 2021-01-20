using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy.ThongKe
{
    public partial class TKDV : System.Web.UI.Page
    {
        Services services = new Services();
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                DDL_DichVu.DataSource = services.getAllDichVu();
                DDL_DichVu.DataTextField = "TenDichVu";
                DDL_DichVu.DataValueField = "MaDichVu";
                DataBind();
            }    
        }
        public void hienthi()
        {
            var MaDichVu = int.Parse(DDL_DichVu.SelectedValue.ToString());
            GV_HoaDon.DataSource = services.Getsudungdv(MaDichVu);
            txtTongTien.Text = services.tongTien(MaDichVu);
            txtsoLuong.Text = services.soLuong(MaDichVu);
            DataBind();
        }
        protected void btnHienthi_Click(object sender, EventArgs e)
        {
            hienthi();
            txtsoLuong.Visible = true;
            txtTongTien.Visible = true;
            lb.Visible = true;
            lb1.Visible = true;
        }
    }
}