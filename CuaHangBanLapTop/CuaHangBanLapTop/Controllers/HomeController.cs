using CuaHangBanLapTop.Data;
using CuaHangBanLapTop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CuaHangBanLapTop.Controllers
{
    public class HomeController : Controller
    {
        private LAPTOPContext db = new LAPTOPContext();
        private readonly LAPTOPContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, LAPTOPContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var dress = _context.Khuyenmais;

            return View(dress);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
