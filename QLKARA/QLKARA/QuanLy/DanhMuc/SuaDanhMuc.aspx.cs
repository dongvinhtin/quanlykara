using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy.DanhMuc
{
    public partial class SuaDanhMuc : System.Web.UI.Page
    {
        getDanhMuc getDanhMuc = new getDanhMuc();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TaiKhoan"] != null)
            {

            }
            else Response.Redirect("../../index.aspx");
            if (!IsPostBack)
            {
                danhMuc danhMuc = (danhMuc)Session["ma"];
                txtTenDanhMuc.Text = danhMuc.tendanhmuc;
                DataBind();
            }
        }
        protected void btnupdatecategory_Click(object sender, EventArgs e)
        {
            try
            {
                danhMuc danhMuc = (danhMuc)Session["ma"];
                danhMuc.tendanhmuc = txtTenDanhMuc.Text;
                getDanhMuc.suaDanhMuc(danhMuc);
                msgudpatecategory.Text = "Cập nhật thành công";
            }
            catch
            {
                msgudpatecategory.Text = "Có lỗi, không cập nhật được";
            }
        }
    }
}