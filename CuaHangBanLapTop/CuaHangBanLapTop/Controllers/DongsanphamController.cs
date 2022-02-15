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
    public class DongsanphamController : Controller
    {
        private readonly LAPTOPContext _context;

        public DongsanphamController(LAPTOPContext context)
        {
            _context = context;
        }

        // GET: Dongsanpham
        public async Task<IActionResult> Index()
        {
            var lAPTOPContext = _context.Dongsanphams.Include(d => d.IddanhMucNavigation);
            return View(await lAPTOPContext.ToListAsync());
        }

        // GET: Dongsanpham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dongsanpham = await _context.Dongsanphams
                .Include(d => d.IddanhMucNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dongsanpham == null)
            {
                return NotFound();
            }

            return View(dongsanpham);
        }

        // GET: Dongsanpham/Create
        public IActionResult Create()
        {
            ViewData["IddanhMuc"] = new SelectList(_context.Danhmucsanphams, "Id", "TenDanhMuc");
            return View();
        }

        // POST: Dongsanpham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IddanhMuc,TenSanPham")] Dongsanpham dongsanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dongsanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IddanhMuc"] = new SelectList(_context.Danhmucsanphams, "Id", "TenDanhMuc", dongsanpham.IddanhMuc);
            return View(dongsanpham);
        }

        // GET: Dongsanpham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dongsanpham = await _context.Dongsanphams.FindAsync(id);
            if (dongsanpham == null)
            {
                return NotFound();
            }
            ViewData["IddanhMuc"] = new SelectList(_context.Danhmucsanphams, "Id", "TenDanhMuc", dongsanpham.IddanhMuc);
            return View(dongsanpham);
        }

        // POST: Dongsanpham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IddanhMuc,TenSanPham")] Dongsanpham dongsanpham)
        {
            if (id != dongsanpham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dongsanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DongsanphamExists(dongsanpham.Id))
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
            ViewData["IddanhMuc"] = new SelectList(_context.Danhmucsanphams, "Id", "TenDanhMuc", dongsanpham.IddanhMuc);
            return View(dongsanpham);
        }

        // GET: Dongsanpham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dongsanpham = await _context.Dongsanphams
                .Include(d => d.IddanhMucNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dongsanpham == null)
            {
                return NotFound();
            }

            return View(dongsanpham);
        }

        // POST: Dongsanpham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dongsanpham = await _context.Dongsanphams.FindAsync(id);
            _context.Dongsanphams.Remove(dongsanpham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DongsanphamExists(int id)
        {
            return _context.Dongsanphams.Any(e => e.Id == id);
        }
    }
}
