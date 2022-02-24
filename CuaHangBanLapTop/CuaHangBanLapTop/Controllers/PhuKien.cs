using CuaHangBanLapTop.Data;
using CuaHangBanLapTop.Models;
using CuaHangBanLapTop.Services;
using CuaHangBanLapTop.servie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CuaHangBanLapTop.Controllers
{
    public class PhuKien : Controller
    {
        private LAPTOPContext db = new LAPTOPContext();
        private readonly LAPTOPContext _context;
        private readonly iproduct _product;
        public PhuKien(LAPTOPContext context, iproduct product)

        {
            _context = context;
            _product = product;


        }
        public IActionResult Index(string timkiem, int? page = 0)
        {

            int limit = 12;
            int start;
            if (page > 0)
            {
                page = page;
            }
            else
            {
                page = 1;
            }
            start = (int)(page - 1) * limit;

            ViewBag.pageCurrent = page;


            int totalProduct = _product.totalProduct();

            ViewBag.totalProduct = totalProduct;

            ViewBag.numberPage = _product.numberPage(totalProduct, limit);
            var dress = _context.Phukiens
            .Skip((int)((page - 1) * limit)).Take(limit);

            if (!String.IsNullOrEmpty(timkiem))
            {
                dress = dress.Where(s => s.TenPhuKien.Contains(timkiem));
            }
            ViewBag.thongbao = dress.Count();
            return View(dress);
        }




        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pk = await _context.Phukiens
                .Include(s => s.IdloaiPhuKien)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pk == null)
            {
                return NotFound();
            }

            return View(pk);
        }
    }
}
