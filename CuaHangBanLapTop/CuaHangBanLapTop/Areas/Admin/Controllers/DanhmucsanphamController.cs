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
    public class DanhmucsanphamController : Controller
    {
        private readonly LAPTOPContext _context;

        public DanhmucsanphamController(LAPTOPContext context)
        {
            _context = context;
        }

        // GET: Danhmucsanpham
        public async Task<IActionResult> Index()
        {
            return View(await _context.Danhmucsanphams.ToListAsync());
        }

        // GET: Danhmucsanpham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmucsanpham = await _context.Danhmucsanphams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (danhmucsanpham == null)
            {
                return NotFound();
            }

            return View(danhmucsanpham);
        }

        // GET: Danhmucsanpham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Danhmucsanpham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenDanhMuc")] Danhmucsanpham danhmucsanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhmucsanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhmucsanpham);
        }

        // GET: Danhmucsanpham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmucsanpham = await _context.Danhmucsanphams.FindAsync(id);
            if (danhmucsanpham == null)
            {
                return NotFound();
            }
            return View(danhmucsanpham);
        }

        // POST: Danhmucsanpham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenDanhMuc")] Danhmucsanpham danhmucsanpham)
        {
            if (id != danhmucsanpham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhmucsanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhmucsanphamExists(danhmucsanpham.Id))
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
            return View(danhmucsanpham);
        }

        // GET: Danhmucsanpham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmucsanpham = await _context.Danhmucsanphams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (danhmucsanpham == null)
            {
                return NotFound();
            }

            return View(danhmucsanpham);
        }

        // POST: Danhmucsanpham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danhmucsanpham = await _context.Danhmucsanphams.FindAsync(id);
            _context.Danhmucsanphams.Remove(danhmucsanpham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhmucsanphamExists(int id)
        {
            return _context.Danhmucsanphams.Any(e => e.Id == id);
        }
    }
}
