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
    public class NoisanxuatController : Controller
    {
        private readonly LAPTOPContext _context;

        public NoisanxuatController(LAPTOPContext context)
        {
            _context = context;
        }

        // GET: Noisanxuat
        public async Task<IActionResult> Index()
        {
            return View(await _context.Noisanxuats.ToListAsync());
        }

        // GET: Noisanxuat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noisanxuat = await _context.Noisanxuats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noisanxuat == null)
            {
                return NotFound();
            }

            return View(noisanxuat);
        }

        // GET: Noisanxuat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Noisanxuat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenNoiSanXuat")] Noisanxuat noisanxuat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noisanxuat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(noisanxuat);
        }

        // GET: Noisanxuat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noisanxuat = await _context.Noisanxuats.FindAsync(id);
            if (noisanxuat == null)
            {
                return NotFound();
            }
            return View(noisanxuat);
        }

        // POST: Noisanxuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenNoiSanXuat")] Noisanxuat noisanxuat)
        {
            if (id != noisanxuat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noisanxuat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoisanxuatExists(noisanxuat.Id))
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
            return View(noisanxuat);
        }

        // GET: Noisanxuat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noisanxuat = await _context.Noisanxuats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (noisanxuat == null)
            {
                return NotFound();
            }

            return View(noisanxuat);
        }

        // POST: Noisanxuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noisanxuat = await _context.Noisanxuats.FindAsync(id);
            _context.Noisanxuats.Remove(noisanxuat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoisanxuatExists(int id)
        {
            return _context.Noisanxuats.Any(e => e.Id == id);
        }
    }
}
