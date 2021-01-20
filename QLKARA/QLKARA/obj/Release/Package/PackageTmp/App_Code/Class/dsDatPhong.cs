﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKARA.App_Code.Class
{
    public class dsDatPhong
    {
        public dsDatPhong()
        {
            
        }
        public int MaDatPhong { get; set; }
        public string HoTen { get; set; }
        public string SDT{ get; set; }
        public DateTime thoigianvao { get; set; }
        public DateTime thoigianra { get; set; }
        public Boolean TrangThai { get; set; }
        public int MaPhong { get; set; }

        public string TenPhong { get; set; }
        public string getDatPhong_TrangThai
        {
            get
            {
                if (this.TrangThai == true)
                    return "Đã trả phòng";
                else
                    return "Đang sử dụng";
            }
            set
            {
                if (this.TrangThai == true)
                    this.TrangThai = true;
                else
                    this.TrangThai = false;
            }
        }
        public string getDate_in
        {
            get { return this.thoigianvao.ToString("HH/mm/ss"); }
            set { this.thoigianvao = Convert.ToDateTime(value); }

        }
        public string getDate_out
        {
            get { return this.thoigianra.ToString("HH/MM/ss"); }
            set { this.thoigianra = Convert.ToDateTime(value); }
        }
    }
}