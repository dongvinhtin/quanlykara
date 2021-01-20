using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy.DichVu
{
    public partial class DichVuEdit : System.Web.UI.Page
    {
        Services svc = new Services();
        getDanhMuc getDanhMuc = new getDanhMuc();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TaiKhoan"] != null)
                {

                }
                else Response.Redirect("../../index.aspx");
                DSDichVu dSDichVu = (DSDichVu)Session["madichvu"];
                txtTenDichVu.Text = dSDichVu.TenDichVu;
                txtGia.Text = dSDichVu.Gia.ToString();
                txtMoTa.Text = dSDichVu.MoTa;
                DDL_Danhmuc.DataSource = getDanhMuc.GetDanhMuc();
                DDL_Danhmuc.DataTextField = "tendanhmuc";
                DDL_Danhmuc.DataValueField = "madanhmuc";
                DataBind();
                DDL_Danhmuc.SelectedValue = dSDichVu.danhmuc.ToString();
            }
        }
        protected void btnupdateService_Click(object sender, EventArgs e)
        {
            try
            {
                DSDichVu dSDichVu = (DSDichVu)Session["madichvu"];
                dSDichVu.TenDichVu = txtTenDichVu.Text;
                dSDichVu.Gia = double.Parse(txtGia.Text);
                dSDichVu.danhmuc = int.Parse(DDL_Danhmuc.SelectedValue.ToString());
                dSDichVu.MoTa = txtMoTa.Text;
                svc.capNhatDV(dSDichVu);
                lbmsgupdateservice.Text = "Cập nhật thành công";
            }
            catch
            {
                lbmsgupdateservice.Text = "Có lỗi, không cập nhật được";
            }
        }
    }
}