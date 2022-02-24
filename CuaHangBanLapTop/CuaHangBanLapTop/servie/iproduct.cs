using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuaHangBanLapTop.Models;

namespace CuaHangBanLapTop.servie
{
    public interface iproduct
    {
        IEnumerable<Phukien> getProductAll();
        int totalProduct();
        int numberPage(int totalProduct, int limit);
        IEnumerable<Phukien> paginationProduct(int start, int limit);

    }
}