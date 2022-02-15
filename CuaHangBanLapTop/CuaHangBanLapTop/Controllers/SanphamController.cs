using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CuaHangBanLapTop.Data;
using CuaHangBanLapTop.Models;

namespace CuaHangBanLapTop.Controllers
{
    public class SanphamController : Controller
    {
        private readonly LAPTOPContext _context;

        public SanphamController(LAPTOPContext context)
        {
            _context = context;
        }

        // GET: Sanpham
        public async Task<IActionResult> Index()
        {
            var lAPTOPContext = _context.Sanphams.Include(s => s.IddongSanPhamNavigation).Include(s => s.IdnoiSanXuatNavigation);
            return View(await lAPTOPContext.ToListAsync());
        }

        // GET: Sanpham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams
                .Include(s => s.IddongSanPhamNavigation)
                .Include(s => s.IdnoiSanXuatNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // GET: Sanpham/Create
        public IActionResult Create()
        {
            ViewData["IddongSanPham"] = new SelectList(_context.Dongsanphams, "Id", "TenSanPham");
            ViewData["IdnoiSanXuat"] = new SelectList(_context.Noisanxuats, "Id", "Id");
            return View();
        }

        // POST: Sanpham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdnoiSanXuat,IddongSanPham,TenSanPham,AnhSanPham,GiaSanPham,SoLuong,MoTa,BaoHanh")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IddongSanPham"] = new SelectList(_context.Dongsanphams, "Id", "TenSanPham", sanpham.IddongSanPham);
            ViewData["IdnoiSanXuat"] = new SelectList(_context.Noisanxuats, "Id", "Id", sanpham.IdnoiSanXuat);
            return View(sanpham);
        }

        // GET: Sanpham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            ViewData["IddongSanPham"] = new SelectList(_context.Dongsanphams, "Id", "TenSanPham", sanpham.IddongSanPham);
            ViewData["IdnoiSanXuat"] = new SelectList(_context.Noisanxuats, "Id", "Id", sanpham.IdnoiSanXuat);
            return View(sanpham);
        }

        // POST: Sanpham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdnoiSanXuat,IddongSanPham,TenSanPham,AnhSanPham,GiaSanPham,SoLuong,MoTa,BaoHanh")] Sanpham sanpham)
        {
            if (id != sanpham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanphamExists(sanpham.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IddongSanPham"] = new SelectList(_context.Dongsanphams, "Id", "TenSanPham", sanpham.IddongSanPham);
            ViewData["IdnoiSanXuat"] = new SelectList(_context.Noisanxuats, "Id", "Id", sanpham.IdnoiSanXuat);
            return View(sanpham);
        }

        // GET: Sanpham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams
                .Include(s => s.IddongSanPhamNavigation)
                .Include(s => s.IdnoiSanXuatNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // POST: Sanpham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanpham = await _context.Sanphams.FindAsync(id);
            _context.Sanphams.Remove(sanpham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanphamExists(int id)
        {
            return _context.Sanphams.Any(e => e.Id == id);
        }
    }
}
