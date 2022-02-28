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
    public class KhuyenmaiController : Controller
    {
        private readonly LAPTOPContext _context;

        public KhuyenmaiController(LAPTOPContext context)
        {
            _context = context;
        }

        // GET: Khuyenmai
        public async Task<IActionResult> Index()
        {
            var lAPTOPContext = _context.Khuyenmais.Include(k => k.IdphuKienNavigation).Include(k => k.IdsanPamNavigation);
            return View(await lAPTOPContext.ToListAsync());
        }

        // GET: Khuyenmai/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenmai = await _context.Khuyenmais
                .Include(k => k.IdphuKienNavigation)
                .Include(k => k.IdsanPamNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khuyenmai == null)
            {
                return NotFound();
            }

            return View(khuyenmai);
        }

        // GET: Khuyenmai/Create
        public IActionResult Create()
        {
            ViewData["IdphuKien"] = new SelectList(_context.Phukiens, "Id", "TenPhuKien");
            ViewData["IdsanPam"] = new SelectList(_context.Sanphams, "Id", "TenSanPham");
            ViewData["GiaBan"] = new SelectList(_context.Sanphams, "GiaSanPham", "GiaSanPham");
            ViewData["TenSP"] = new SelectList(_context.Sanphams, "TenSanPham", "TenSanPham");

            return View();
        }

        // POST: Khuyenmai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, [Bind("Id,IdsanPam,IdphuKien,TenSP,AnhMauSP,GiaBan,GiaKhuyenMai,NgayBatDauKhuenMai,NgayKetThucKhuyenMai")] Khuyenmai khuyenmai)
        {
            if (ModelState.IsValid)
            {
                khuyenmai.AnhMauSP = Upload(file);
                _context.Add(khuyenmai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdphuKien"] = new SelectList(_context.Phukiens, "Id", "TenPhuKien", khuyenmai.IdphuKien);
            ViewData["IdsanPam"] = new SelectList(_context.Sanphams, "Id", "TenSanPham", khuyenmai.IdsanPam);
            ViewData["GiaBan"] = new SelectList(_context.Sanphams, "GiaSanPham", "GiaSanPham", khuyenmai.GiaBan);
            ViewData["TenSP"] = new SelectList(_context.Sanphams, "TenSanPham", "TenSanPham", khuyenmai.TenSP);

            return View(khuyenmai);
        }

        // GET: Khuyenmai/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenmai = await _context.Khuyenmais.FindAsync(id);
            if (khuyenmai == null)
            {
                return NotFound();
            }
            ViewData["IdphuKien"] = new SelectList(_context.Phukiens, "Id", "TenPhuKien", khuyenmai.IdphuKien);
            ViewData["IdsanPam"] = new SelectList(_context.Sanphams, "Id", "TenSanPham", khuyenmai.IdsanPam);
            ViewData["GiaBan"] = new SelectList(_context.Sanphams, "GiaSanPham", "GiaSanPham", khuyenmai.GiaBan);
            ViewData["TenSP"] = new SelectList(_context.Sanphams, "TenSanPham", "TenSanPham", khuyenmai.TenSP);

            return View(khuyenmai);
        }

        // POST: Khuyenmai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormFile file, int id, [Bind("Id,IdsanPam,IdphuKien,TenSP,AnhMauSP,GiaBan,GiaKhuyenMai,NgayBatDauKhuenMai,NgayKetThucKhuyenMai")] Khuyenmai khuyenmai)
        {
            if (id != khuyenmai.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    khuyenmai.AnhMauSP = Upload(file);
                    _context.Update(khuyenmai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhuyenmaiExists(khuyenmai.Id))
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
            ViewData["IdphuKien"] = new SelectList(_context.Phukiens, "Id", "TenPhuKien", khuyenmai.IdphuKien);
            ViewData["IdsanPam"] = new SelectList(_context.Sanphams, "Id", "TenSanPham", khuyenmai.IdsanPam);
            ViewData["GiaBan"] = new SelectList(_context.Sanphams, "GiaSanPham", "GiaSanPham", khuyenmai.GiaBan);
            ViewData["TenSP"] = new SelectList(_context.Sanphams, "TenSanPham", "TenSanPham", khuyenmai.TenSP);
            return View(khuyenmai);
        }

        // GET: Khuyenmai/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenmai = await _context.Khuyenmais
                .Include(k => k.IdphuKienNavigation)
                .Include(k => k.IdsanPamNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khuyenmai == null)
            {
                return NotFound();
            }

            return View(khuyenmai);
        }

        // POST: Khuyenmai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khuyenmai = await _context.Khuyenmais.FindAsync(id);
            _context.Khuyenmais.Remove(khuyenmai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhuyenmaiExists(int id)
        {
            return _context.Khuyenmais.Any(e => e.Id == id);
        }
        //Load ảnh khuyến mãi
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
