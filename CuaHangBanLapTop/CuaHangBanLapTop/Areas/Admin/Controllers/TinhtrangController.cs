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
    public class TinhtrangController : Controller
    {
        private readonly LAPTOPContext _context;

        public TinhtrangController(LAPTOPContext context)
        {
            _context = context;
        }

        // GET: Tinhtrang
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tinhtrangs.ToListAsync());
        }

        // GET: Tinhtrang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinhtrang = await _context.Tinhtrangs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tinhtrang == null)
            {
                return NotFound();
            }

            return View(tinhtrang);
        }

        // GET: Tinhtrang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tinhtrang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TinhTrang1")] Tinhtrang tinhtrang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tinhtrang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tinhtrang);
        }

        // GET: Tinhtrang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinhtrang = await _context.Tinhtrangs.FindAsync(id);
            if (tinhtrang == null)
            {
                return NotFound();
            }
            return View(tinhtrang);
        }

        // POST: Tinhtrang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TinhTrang1")] Tinhtrang tinhtrang)
        {
            if (id != tinhtrang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tinhtrang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TinhtrangExists(tinhtrang.Id))
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
            return View(tinhtrang);
        }

        // GET: Tinhtrang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinhtrang = await _context.Tinhtrangs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tinhtrang == null)
            {
                return NotFound();
            }

            return View(tinhtrang);
        }

        // POST: Tinhtrang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tinhtrang = await _context.Tinhtrangs.FindAsync(id);
            _context.Tinhtrangs.Remove(tinhtrang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TinhtrangExists(int id)
        {
            return _context.Tinhtrangs.Any(e => e.Id == id);
        }
    }
}
