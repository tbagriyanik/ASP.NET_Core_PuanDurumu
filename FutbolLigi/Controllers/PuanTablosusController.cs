using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FutbolLigi.Data;
using FutbolLigi.Models;

namespace FutbolLigi.Controllers
{
    public class PuanTablosusController : Controller
    {
        private readonly FutbolLigiContext _context;

        public PuanTablosusController(FutbolLigiContext context)
        {
            _context = context;
        }

        // GET: PuanTablosus
        public async Task<IActionResult> Index()
        {
            var puanT = await _context.PuanTablosu                
                .OrderByDescending(c=>c.Galibiyet * 3 + c.Beraberlik)
                .ToListAsync();                    
            return View(puanT);
        }

        // GET: PuanTablosus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puanTablosu = await _context.PuanTablosu
                .FirstOrDefaultAsync(m => m.ID == id);
            if (puanTablosu == null)
            {
                return NotFound();
            }

            return View(puanTablosu);
        }

        // GET: PuanTablosus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PuanTablosus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TakimAdi,Galibiyet,Beraberlik,Maglubiyet,AtilanGol,YenilenGol")] PuanTablosu puanTablosu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puanTablosu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(puanTablosu);
        }

        // GET: PuanTablosus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puanTablosu = await _context.PuanTablosu.FindAsync(id);
            if (puanTablosu == null)
            {
                return NotFound();
            }
            return View(puanTablosu);
        }

        // POST: PuanTablosus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TakimAdi,Galibiyet,Beraberlik,Maglubiyet,AtilanGol,YenilenGol")] PuanTablosu puanTablosu)
        {
            if (id != puanTablosu.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puanTablosu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuanTablosuExists(puanTablosu.ID))
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
            return View(puanTablosu);
        }

        // GET: PuanTablosus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puanTablosu = await _context.PuanTablosu
                .FirstOrDefaultAsync(m => m.ID == id);
            if (puanTablosu == null)
            {
                return NotFound();
            }

            return View(puanTablosu);
        }

        // POST: PuanTablosus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var puanTablosu = await _context.PuanTablosu.FindAsync(id);
            _context.PuanTablosu.Remove(puanTablosu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuanTablosuExists(int id)
        {
            return _context.PuanTablosu.Any(e => e.ID == id);
        }
    }
}
