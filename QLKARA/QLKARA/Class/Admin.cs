using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKARA
{
    public class Admin
    {
        int idadmin;
        string taikhoan;
        string matkhau;
        public int maAdmin
        {
            get { return idadmin; }
            set { idadmin = value; }
        }
        public string TaiKhoan
        {
            get { return taikhoan; }
            set { taikhoan = value; }
        }
        public string MatKhau
        {
            get { return matkhau; }
            set { matkhau = value; }
        }
    }
}