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
    public class LoaiphukienController : Controller
    {
        private readonly LAPTOPContext _context;

        public LoaiphukienController(LAPTOPContext context)
        {
            _context = context;
        }

        // GET: Loaiphukien
        public async Task<IActionResult> Index()
        {
            var lAPTOPContext = _context.Loaiphukiens.Include(l => l.IddanhMucNavigation);
            return View(await lAPTOPContext.ToListAsync());
        }

        // GET: Loaiphukien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiphukien = await _context.Loaiphukiens
                .Include(l => l.IddanhMucNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiphukien == null)
            {
                return NotFound();
            }

            return View(loaiphukien);
        }

        // GET: Loaiphukien/Create
        public IActionResult Create()
        {
            ViewData["IddanhMuc"] = new SelectList(_context.Danhmucsanphams, "Id", "TenDanhMuc");
            return View();
        }

        // POST: Loaiphukien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IddanhMuc,TenPhuKien")] Loaiphukien loaiphukien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiphukien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IddanhMuc"] = new SelectList(_context.Danhmucsanphams, "Id", "TenDanhMuc", loaiphukien.IddanhMuc);
            return View(loaiphukien);
        }

        // GET: Loaiphukien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiphukien = await _context.Loaiphukiens.FindAsync(id);
            if (loaiphukien == null)
            {
                return NotFound();
            }
            ViewData["IddanhMuc"] = new SelectList(_context.Danhmucsanphams, "Id", "TenDanhMuc", loaiphukien.IddanhMuc);
            return View(loaiphukien);
        }

        // POST: Loaiphukien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IddanhMuc,TenPhuKien")] Loaiphukien loaiphukien)
        {
            if (id != loaiphukien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiphukien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiphukienExists(loaiphukien.Id))
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
            ViewData["IddanhMuc"] = new SelectList(_context.Danhmucsanphams, "Id", "TenDanhMuc", loaiphukien.IddanhMuc);
            return View(loaiphukien);
        }

        // GET: Loaiphukien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiphukien = await _context.Loaiphukiens
                .Include(l => l.IddanhMucNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiphukien == null)
            {
                return NotFound();
            }

            return View(loaiphukien);
        }

        // POST: Loaiphukien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiphukien = await _context.Loaiphukiens.FindAsync(id);
            _context.Loaiphukiens.Remove(loaiphukien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiphukienExists(int id)
        {
            return _context.Loaiphukiens.Any(e => e.Id == id);
        }
    }
}
