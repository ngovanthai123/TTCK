using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuaHangBanLapTop.Data;
using CuaHangBanLapTop.Models;
using CuaHangBanLapTop.servie;

namespace CuaHangBanLapTop.Servie
{
    public class  Itemproductservice:iproduct
    {
        private readonly LAPTOPContext _db;
        private List<Phukien> pro = new List<Phukien>();
        public Itemproductservice (LAPTOPContext db)
        {
            _db = db;
            this.pro = _db.Phukiens.ToList();
        }
        public IEnumerable<Phukien> getProductAll()
        {
            return pro;
        }
        public int totalProduct()
        {
            return pro.Count + 1;
        }
        public int numberPage(int totalProduct, int limit)
        {
            float numberpage = ((float)totalProduct) / ((float)limit);
            return (int)Math.Ceiling(numberpage);
        }
        public IEnumerable<Phukien> paginationProduct(int start, int limit)
        {
            var sanpham = (from s in _db.Phukiens select s);
            var dataProduct = sanpham.OrderByDescending(x => x.Id).Skip(start).Take(limit);
            return dataProduct.ToList();
        }
    }

}
