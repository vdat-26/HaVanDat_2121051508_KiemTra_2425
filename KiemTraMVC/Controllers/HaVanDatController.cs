using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KiemTraMVC.Data;
using KiemTraMVC.Models;

namespace KiemTraMVC.Controllers
{
    public class HaVanDatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HaVanDatController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HaVanDat
        public async Task<IActionResult> Index()
        {
            return View(await _context.HaVanDat.ToListAsync());
        }

        // GET: HaVanDat/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haVanDat = await _context.HaVanDat
                .FirstOrDefaultAsync(m => m.id == id);
            if (haVanDat == null)
            {
                return NotFound();
            }

            return View(haVanDat);
        }

        // GET: HaVanDat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HaVanDat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FullName,Address")] HaVanDat haVanDat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(haVanDat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(haVanDat);
        }

        // GET: HaVanDat/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haVanDat = await _context.HaVanDat.FindAsync(id);
            if (haVanDat == null)
            {
                return NotFound();
            }
            return View(haVanDat);
        }

        // POST: HaVanDat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FullName,Address")] HaVanDat haVanDat)
        {
            if (id != haVanDat.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(haVanDat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HaVanDatExists(haVanDat.id))
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
            return View(haVanDat);
        }

        // GET: HaVanDat/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haVanDat = await _context.HaVanDat
                .FirstOrDefaultAsync(m => m.id == id);
            if (haVanDat == null)
            {
                return NotFound();
            }

            return View(haVanDat);
        }

        // POST: HaVanDat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var haVanDat = await _context.HaVanDat.FindAsync(id);
            if (haVanDat != null)
            {
                _context.HaVanDat.Remove(haVanDat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HaVanDatExists(int id)
        {
            return _context.HaVanDat.Any(e => e.id == id);
        }
    }
}
