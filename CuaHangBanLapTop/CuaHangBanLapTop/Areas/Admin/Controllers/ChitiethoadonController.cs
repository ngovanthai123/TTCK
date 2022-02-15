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
    [Area("Admin")]
    public class ChitiethoadonController : Controller
    {
        private readonly LAPTOPContext _context;

        public ChitiethoadonController(LAPTOPContext context)
        {
            _context = context;
        }

        // GET: Chitiethoadon
        public async Task<IActionResult> Index()
        {
            var lAPTOPContext = _context.Chitiethoadons.Include(c => c.IdhoaDonNavigation).Include(c => c.IdphuKienNavigation).Include(c => c.IdsanPhamNavigation);
            return View(await lAPTOPContext.ToListAsync());
        }

        // GET: Chitiethoadon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitiethoadon = await _context.Chitiethoadons
                .Include(c => c.IdhoaDonNavigation)
                .Include(c => c.IdphuKienNavigation)
                .Include(c => c.IdsanPhamNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chitiethoadon == null)
            {
                return NotFound();
            }

            return View(chitiethoadon);
        }

        // GET: Chitiethoadon/Create
        public IActionResult Create()
        {
            ViewData["IdhoaDon"] = new SelectList(_context.Hoadons, "Id", "Id");
            ViewData["IdphuKien"] = new SelectList(_context.Phukiens, "Id", "TenPhuKien");
            ViewData["IdsanPham"] = new SelectList(_context.Sanphams, "Id", "TenSanPham");
            return View();
        }

        // POST: Chitiethoadon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdhoaDon,IdsanPham,IdphuKien,SoLuongMua,DonGia")] Chitiethoadon chitiethoadon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chitiethoadon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdhoaDon"] = new SelectList(_context.Hoadons, "Id", "Id", chitiethoadon.IdhoaDon);
            ViewData["IdphuKien"] = new SelectList(_context.Phukiens, "Id", "TenPhuKien", chitiethoadon.IdphuKien);
            ViewData["IdsanPham"] = new SelectList(_context.Sanphams, "Id", "TenSanPham", chitiethoadon.IdsanPham);
            return View(chitiethoadon);
        }

        // GET: Chitiethoadon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitiethoadon = await _context.Chitiethoadons.FindAsync(id);
            if (chitiethoadon == null)
            {
                return NotFound();
            }
            ViewData["IdhoaDon"] = new SelectList(_context.Hoadons, "Id", "Id", chitiethoadon.IdhoaDon);
            ViewData["IdphuKien"] = new SelectList(_context.Phukiens, "Id", "TenPhuKien", chitiethoadon.IdphuKien);
            ViewData["IdsanPham"] = new SelectList(_context.Sanphams, "Id", "TenSanPham", chitiethoadon.IdsanPham);
            return View(chitiethoadon);
        }

        // POST: Chitiethoadon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdhoaDon,IdsanPham,IdphuKien,SoLuongMua,DonGia")] Chitiethoadon chitiethoadon)
        {
            if (id != chitiethoadon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chitiethoadon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChitiethoadonExists(chitiethoadon.Id))
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
            ViewData["IdhoaDon"] = new SelectList(_context.Hoadons, "Id", "Id", chitiethoadon.IdhoaDon);
            ViewData["IdphuKien"] = new SelectList(_context.Phukiens, "Id", "TenPhuKien", chitiethoadon.IdphuKien);
            ViewData["IdsanPham"] = new SelectList(_context.Sanphams, "Id", "TenSanPham", chitiethoadon.IdsanPham);
            return View(chitiethoadon);
        }

        // GET: Chitiethoadon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitiethoadon = await _context.Chitiethoadons
                .Include(c => c.IdhoaDonNavigation)
                .Include(c => c.IdphuKienNavigation)
                .Include(c => c.IdsanPhamNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chitiethoadon == null)
            {
                return NotFound();
            }

            return View(chitiethoadon);
        }

        // POST: Chitiethoadon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chitiethoadon = await _context.Chitiethoadons.FindAsync(id);
            _context.Chitiethoadons.Remove(chitiethoadon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChitiethoadonExists(int id)
        {
            return _context.Chitiethoadons.Any(e => e.Id == id);
        }
    }
}
