using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TEST.Models;

namespace TEST.Controllers
{
    public class TmProductVersionsController : Controller
    {
        private readonly TM_GORICOContext _context;

        public TmProductVersionsController(TM_GORICOContext context)
        {
            _context = context;
        }

        // GET: TmProductVersions
        public async Task<IActionResult> Index()
        {
            var tM_GORICOContext = _context.TmProductVersion.Include(t => t.TmProduct);
            return View(await tM_GORICOContext.ToListAsync());
        }

        // GET: TmProductVersions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TmProductVersion == null)
            {
                return NotFound();
            }

            var tmProductVersion = await _context.TmProductVersion
                .Include(t => t.TmProduct)
                .FirstOrDefaultAsync(m => m.id == id);
            if (tmProductVersion == null)
            {
                return NotFound();
            }

            return View(tmProductVersion);
        }

        // GET: TmProductVersions/Create
        public IActionResult Create()
        {
            ViewData["product_id"] = new SelectList(_context.Set<TmProduct>(), "id", "id");
            return View();
        }

        // POST: TmProductVersions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title,build_number,build_date,EOL,product_id")] TmProductVersion tmProductVersion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tmProductVersion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["product_id"] = new SelectList(_context.Set<TmProduct>(), "id", "id", tmProductVersion.product_id);
            return View(tmProductVersion);
        }

        // GET: TmProductVersions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TmProductVersion == null)
            {
                return NotFound();
            }

            var tmProductVersion = await _context.TmProductVersion.FindAsync(id);
            if (tmProductVersion == null)
            {
                return NotFound();
            }
            ViewData["product_id"] = new SelectList(_context.Set<TmProduct>(), "id", "id", tmProductVersion.product_id);
            return View(tmProductVersion);
        }

        // POST: TmProductVersions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,title,build_number,build_date,EOL,product_id")] TmProductVersion tmProductVersion)
        {
            if (id != tmProductVersion.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tmProductVersion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TmProductVersionExists(tmProductVersion.id))
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
            ViewData["product_id"] = new SelectList(_context.Set<TmProduct>(), "id", "id", tmProductVersion.product_id);
            return View(tmProductVersion);
        }

        // GET: TmProductVersions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TmProductVersion == null)
            {
                return NotFound();
            }

            var tmProductVersion = await _context.TmProductVersion
                .Include(t => t.TmProduct)
                .FirstOrDefaultAsync(m => m.id == id);
            if (tmProductVersion == null)
            {
                return NotFound();
            }

            return View(tmProductVersion);
        }

        // POST: TmProductVersions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TmProductVersion == null)
            {
                return Problem("Entity set 'TM_GORICOContext.TmProductVersion'  is null.");
            }
            var tmProductVersion = await _context.TmProductVersion.FindAsync(id);
            if (tmProductVersion != null)
            {
                _context.TmProductVersion.Remove(tmProductVersion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TmProductVersionExists(int id)
        {
          return _context.TmProductVersion.Any(e => e.id == id);
        }
    }
}
