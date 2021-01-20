using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy.DichVu
{
    public partial class DichVuAdd : System.Web.UI.Page
    {
        getDanhMuc getDanhMuc = new getDanhMuc();
        Services svc = new Services();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TaiKhoan"] != null)
            {

            }
            else Response.Redirect("../../index.aspx");
            //lay data ra dropdownlist
            if (!IsPostBack)
            {
                DDL_Danhmuc.DataSource = getDanhMuc.GetDanhMuc();
                DDL_Danhmuc.DataTextField = "tendanhmuc";
                DDL_Danhmuc.DataValueField = "madanhmuc";
                DataBind();
            }
        }

        protected void btnaddService_Click(object sender, EventArgs e)
        {
            try
            {
                DSDichVu dSDichVu = new DSDichVu();
                dSDichVu.TenDichVu = txtTenDichVu.Text;
                dSDichVu.Gia = double.Parse(txtGia.Text);
                dSDichVu.danhmuc = int.Parse(DDL_Danhmuc.SelectedValue.ToString());
                dSDichVu.MoTa = txtMoTa.Text;
                svc.themDichVu(dSDichVu);
                lbmsgaddservice.Text = "Thêm thành công";
            }
            catch
            {
                lbmsgaddservice.Text = "Có lỗi, không thêm được";
            }
        }
    }
}