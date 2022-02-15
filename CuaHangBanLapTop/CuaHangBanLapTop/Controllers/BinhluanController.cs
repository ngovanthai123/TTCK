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
    public class BinhluanController : Controller
    {
        private readonly LAPTOPContext _context;

        public BinhluanController(LAPTOPContext context)
        {
            _context = context;
        }

        // GET: Binhluan
        public async Task<IActionResult> Index()
        {
            var lAPTOPContext = _context.Binhluans.Include(b => b.IdphuKienNavigation).Include(b => b.IdsanPhamNavigation);
            return View(await lAPTOPContext.ToListAsync());
        }

        // GET: Binhluan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhluan = await _context.Binhluans
                .Include(b => b.IdphuKienNavigation)
                .Include(b => b.IdsanPhamNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (binhluan == null)
            {
                return NotFound();
            }

            return View(binhluan);
        }

        // GET: Binhluan/Create
        public IActionResult Create()
        {
            ViewData["IdphuKien"] = new SelectList(_context.Phukiens, "Id", "TenPhuKien");
            ViewData["IdsanPham"] = new SelectList(_context.Sanphams, "Id", "TenSanPham");
            return View();
        }

        // POST: Binhluan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdsanPham,IdphuKien,HoTen,NgayGio,NoiDung")] Binhluan binhluan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(binhluan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdphuKien"] = new SelectList(_context.Phukiens, "Id", "TenPhuKien", binhluan.IdphuKien);
            ViewData["IdsanPham"] = new SelectList(_context.Sanphams, "Id", "TenSanPham", binhluan.IdsanPham);
            return View(binhluan);
        }

        // GET: Binhluan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhluan = await _context.Binhluans.FindAsync(id);
            if (binhluan == null)
            {
                return NotFound();
            }
            ViewData["IdphuKien"] = new SelectList(_context.Phukiens, "Id", "TenPhuKien", binhluan.IdphuKien);
            ViewData["IdsanPham"] = new SelectList(_context.Sanphams, "Id", "TenSanPham", binhluan.IdsanPham);
            return View(binhluan);
        }

        // POST: Binhluan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdsanPham,IdphuKien,HoTen,NgayGio,NoiDung")] Binhluan binhluan)
        {
            if (id != binhluan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(binhluan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinhluanExists(binhluan.Id))
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
            ViewData["IdphuKien"] = new SelectList(_context.Phukiens, "Id", "TenPhuKien", binhluan.IdphuKien);
            ViewData["IdsanPham"] = new SelectList(_context.Sanphams, "Id", "TenSanPham", binhluan.IdsanPham);
            return View(binhluan);
        }

        // GET: Binhluan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhluan = await _context.Binhluans
                .Include(b => b.IdphuKienNavigation)
                .Include(b => b.IdsanPhamNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (binhluan == null)
            {
                return NotFound();
            }

            return View(binhluan);
        }

        // POST: Binhluan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var binhluan = await _context.Binhluans.FindAsync(id);
            _context.Binhluans.Remove(binhluan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinhluanExists(int id)
        {
            return _context.Binhluans.Any(e => e.Id == id);
        }
    }
}
