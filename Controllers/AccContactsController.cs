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
    public class AccContactsController : Controller
    {
        private readonly TM_GORICOContext _context;

        public AccContactsController(TM_GORICOContext context)
        {
            _context = context;
        }

        // GET: AccContacts
        public async Task<IActionResult> Index()
        {
            var tM_GORICOContext = _context.Contact.Include(a => a.Account);
            return View(await tM_GORICOContext.ToListAsync());
        }

        // GET: AccContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contact == null)
            {
                return NotFound();
            }

            var accContact = await _context.Contact
                .Include(a => a.Account)
                .FirstOrDefaultAsync(m => m.id == id);
            if (accContact == null)
            {
                return NotFound();
            }

            return View(accContact);
        }

        // GET: AccContacts/Create
        public IActionResult Create()
        {
            ViewData["account_id"] = new SelectList(_context.Account, "id", "id");
            return View();
        }

        // POST: AccContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,title,department,email,phone,ext,champion,status,account_id")] AccContact accContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["account_id"] = new SelectList(_context.Account, "id", "id", accContact.account_id);
            return View(accContact);
        }

        // GET: AccContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contact == null)
            {
                return NotFound();
            }

            var accContact = await _context.Contact.FindAsync(id);
            if (accContact == null)
            {
                return NotFound();
            }
            ViewData["account_id"] = new SelectList(_context.Account, "id", "id", accContact.account_id);
            return View(accContact);
        }

        // POST: AccContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,title,department,email,phone,ext,champion,status,account_id")] AccContact accContact)
        {
            if (id != accContact.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccContactExists(accContact.id))
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
            ViewData["account_id"] = new SelectList(_context.Account, "id", "id", accContact.account_id);
            return View(accContact);
        }

        // GET: AccContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contact == null)
            {
                return NotFound();
            }

            var accContact = await _context.Contact
                .Include(a => a.Account)
                .FirstOrDefaultAsync(m => m.id == id);
            if (accContact == null)
            {
                return NotFound();
            }

            return View(accContact);
        }

        // POST: AccContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contact == null)
            {
                return Problem("Entity set 'TM_GORICOContext.Contact'  is null.");
            }
            var accContact = await _context.Contact.FindAsync(id);
            if (accContact != null)
            {
                _context.Contact.Remove(accContact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccContactExists(int id)
        {
          return _context.Contact.Any(e => e.id == id);
        }
    }
}
