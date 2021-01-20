using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLKARA.QuanLy.DanhMuc
{
    public partial class themDanhMuc : System.Web.UI.Page
    {
        getDanhMuc getDanhMuc = new getDanhMuc();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TaiKhoan"] != null)
            {

            }
            else Response.Redirect("../../index.aspx");
        }

        protected void btnaddcategory_Click(object sender, EventArgs e)
        {
                try
                {
                    danhMuc danhMuc = new danhMuc();
                    danhMuc.tendanhmuc = txtTenDanhMuc.Text;
                    getDanhMuc.themDanhMuc(danhMuc);
                    msgaddcategory.Text = "Thêm thành công";
                }
                catch
                {
                    msgaddcategory.Text = "Có lỗi";
                }
        }
    }
}