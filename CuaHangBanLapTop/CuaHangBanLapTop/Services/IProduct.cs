using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuaHangBanLapTop.Models;

namespace CuaHangBanLapTop.Services
{
    public interface IProduct
    {
        IEnumerable<Sanpham> getProductAll();
        int totalProduct();
        int numberPage(int totalProduct, int limit);
        IEnumerable<Sanpham> paginationProduct(int start, int limit);

    }
}