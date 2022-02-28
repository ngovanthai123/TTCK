using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CuaHangBanLapTop.Data;
using CuaHangBanLapTop.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace CuaHangBanLapTop.Controllers
{
    [Area("Admin")]
    public class PhukienController : Controller
    {
        private readonly LAPTOPContext _context;

        public PhukienController(LAPTOPContext context)
        {
            _context = context;
        }

        // GET: Phukien
        public async Task<IActionResult> Index()
        {
            var lAPTOPContext = _context.Phukiens.Include(p => p.IdloaiPhuKienNavigation);
            return View(await lAPTOPContext.ToListAsync());
        }

        // GET: Phukien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phukien = await _context.Phukiens
                .Include(p => p.IdloaiPhuKienNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phukien == null)
            {
                return NotFound();
            }

            return View(phukien);
        }

        // GET: Phukien/Create
        public IActionResult Create()
        {
            ViewData["IdloaiPhuKien"] = new SelectList(_context.Loaiphukiens, "Id", "TenPhuKien");
            return View();
        }

        // POST: Phukien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file,[Bind("Id,IdloaiPhuKien,TenPhuKien,AnhMau,Gia,SoLuong,MoTa,BaoHanh")] Phukien phukien)
        {
            if (ModelState.IsValid)
            {
                phukien.AnhMau = Upload(file);
                _context.Add(phukien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdloaiPhuKien"] = new SelectList(_context.Loaiphukiens, "Id", "TenPhuKien", phukien.IdloaiPhuKien);
            return View(phukien);
        }

        // GET: Phukien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phukien = await _context.Phukiens.FindAsync(id);
            if (phukien == null)
            {
                return NotFound();
            }
            ViewData["IdloaiPhuKien"] = new SelectList(_context.Loaiphukiens, "Id", "TenPhuKien", phukien.IdloaiPhuKien);
            return View(phukien);
        }

        // POST: Phukien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormFile file, int id, [Bind("Id,IdloaiPhuKien,TenPhuKien,AnhMau,Gia,SoLuong,MoTa,BaoHanh")] Phukien phukien)
        {
            if (id != phukien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    phukien.AnhMau = Upload(file);
                    _context.Update(phukien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhukienExists(phukien.Id))
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
            ViewData["IdloaiPhuKien"] = new SelectList(_context.Loaiphukiens, "Id", "TenPhuKien", phukien.IdloaiPhuKien);
            return View(phukien);
        }

        // GET: Phukien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phukien = await _context.Phukiens
                .Include(p => p.IdloaiPhuKienNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phukien == null)
            {
                return NotFound();
            }

            return View(phukien);
        }

        // POST: Phukien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phukien = await _context.Phukiens.FindAsync(id);
            _context.Phukiens.Remove(phukien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhukienExists(int id)
        {
            return _context.Phukiens.Any(e => e.Id == id);
        }

        //Load ảnh phụ kiện
        public string Upload(IFormFile file)
        {
            string UploadFileName = null;
            if (file != null)
            {
                UploadFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var path = $"wwwroot\\images\\{ UploadFileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

            }
            return UploadFileName;
        }
    }
}
