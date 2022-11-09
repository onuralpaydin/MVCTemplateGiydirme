using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ank9MVCTemplateGiydirme.Models;

namespace Ank9MVCTemplateGiydirme.Controllers
{
    public class MalzemeController : Controller
    {
        private readonly RestaurantContext _context;

        public MalzemeController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Malzeme
        public async Task<IActionResult> Index()
        {
              return View(await _context.Malzemeler.ToListAsync());
        }

        // GET: Malzeme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Malzemeler == null)
            {
                return NotFound();
            }

            var malzeme = await _context.Malzemeler
                .FirstOrDefaultAsync(m => m.MalzemeId == id);
            if (malzeme == null)
            {
                return NotFound();
            }

            return View(malzeme);
        }

        // GET: Malzeme/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Malzeme/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MalzemeId,MalzemeAdi")] Malzeme malzeme)
        {
            if (!string.IsNullOrEmpty(malzeme.MalzemeAdi))
            {
                Malzeme yeniMalzeme = malzeme;
                _context.Malzemeler.Add(yeniMalzeme);
                _context.SaveChanges();
                return RedirectToAction("Index", "Malzeme");

            }
            return View();
        }

        // GET: Malzeme/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Malzemeler == null)
            {
                return NotFound();
            }

            var malzeme = await _context.Malzemeler.FindAsync(id);
            if (malzeme == null)
            {
                return NotFound();
            }
            return View(malzeme);
        }

        // POST: Malzeme/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MalzemeId,MalzemeAdi")] Malzeme malzeme)
        {
            if (id != malzeme.MalzemeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Malzemeler.Update(malzeme);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Malzeme");

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MalzemeExists(malzeme.MalzemeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(malzeme);
        }

        // GET: Malzeme/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Malzemeler == null)
            {
                return NotFound();
            }

            var malzeme = await _context.Malzemeler
                .FirstOrDefaultAsync(m => m.MalzemeId == id);
            if (malzeme == null)
            {
                return NotFound();
            }

            return View(malzeme);
        }

        // POST: Malzeme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Malzemeler == null)
            {
                return Problem("Entity set 'RestaurantContext.Malzemeler'  is null.");
            }
            var malzeme = await _context.Malzemeler.FindAsync(id);
            if (malzeme != null)
            {
                _context.Malzemeler.Remove(malzeme);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MalzemeExists(int id)
        {
          return _context.Malzemeler.Any(e => e.MalzemeId == id);
        }
    }
}
