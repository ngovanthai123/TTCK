using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuaHangBanLapTop.Models
{
    public class CartItem
    {
        public Sanpham Sanpham { get; set; }
        public Phukien Phukien { get; set; }
        public int Quantity { get; set; }
    }
}
