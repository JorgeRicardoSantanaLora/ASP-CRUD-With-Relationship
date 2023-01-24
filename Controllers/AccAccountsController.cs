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
    public class AccAccountsController : Controller
    {
        private readonly TM_GORICOContext _context;

        public AccAccountsController(TM_GORICOContext context)
        {
            _context = context;
        }

        // GET: AccAccounts
        public async Task<IActionResult> Index()
        {
            var tM_GORICOContext = _context.Account.Include(a => a.Country);
            return View(await tM_GORICOContext.ToListAsync());
        }

        // GET: AccAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            var accAccount = await _context.Account
                .Include(a => a.Country)
                .FirstOrDefaultAsync(m => m.id == id);
            if (accAccount == null)
            {
                return NotFound();
            }

            return View(accAccount);
        }

        // GET: AccAccounts/Create
        public IActionResult Create()
        {
            ViewData["country_id"] = new SelectList(_context.Set<AccCountry>(), "id", "id");
            return View();
        }

        // POST: AccAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title,wk_number,country_id,account_status")] AccAccount accAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["country_id"] = new SelectList(_context.Set<AccCountry>(), "id", "id", accAccount.country_id);
            return View(accAccount);
        }

        // GET: AccAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            var accAccount = await _context.Account.FindAsync(id);
            if (accAccount == null)
            {
                return NotFound();
            }
            ViewData["country_id"] = new SelectList(_context.Set<AccCountry>(), "id", "id", accAccount.country_id);
            return View(accAccount);
        }

        // POST: AccAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,title,wk_number,country_id,account_status")] AccAccount accAccount)
        {
            if (id != accAccount.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccAccountExists(accAccount.id))
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
            ViewData["country_id"] = new SelectList(_context.Set<AccCountry>(), "id", "id", accAccount.country_id);
            return View(accAccount);
        }

        // GET: AccAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            var accAccount = await _context.Account
                .Include(a => a.Country)
                .FirstOrDefaultAsync(m => m.id == id);
            if (accAccount == null)
            {
                return NotFound();
            }

            return View(accAccount);
        }

        // POST: AccAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Account == null)
            {
                return Problem("Entity set 'TM_GORICOContext.Account'  is null.");
            }
            var accAccount = await _context.Account.FindAsync(id);
            if (accAccount != null)
            {
                _context.Account.Remove(accAccount);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccAccountExists(int id)
        {
          return _context.Account.Any(e => e.id == id);
        }
    }
}
