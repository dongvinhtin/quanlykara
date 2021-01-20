using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKARA
{
    public class DSPhong
    {
        public DSPhong()
        {

        }
        public int MaPhong { get; set; }
        public string TenPhong { get; set; }
        public Boolean TrangThai { get; set; }
        public int MaLoaiPhong { get; set; }
        public string TenLoaiPhong { get; set; }
        public string getPhong_TrangThai
        {
            get
            {
                if (this.TrangThai == true)
                {
                    return "Đã có người đặt";
                }
                else return "Còn trống";
            }
            set
            {
                if (this.TrangThai == true)
                    this.TrangThai = true;
                else this.TrangThai = false;
            }
        }
    }
}