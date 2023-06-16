using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactAPI.Models;

namespace ContactAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContactDbApiContext _context;

        public HomeController(ContactDbApiContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
              return _context.ContactListTables != null ? 
                          View(await _context.ContactListTables.ToListAsync()) :
                          Problem("Entity set 'ContactDbApiContext.ContactListTables'  is null.");
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ContactListTables == null)
            {
                return NotFound();
            }

            var contactListTable = await _context.ContactListTables
                .FirstOrDefaultAsync(m => m.ContactName == id);
            if (contactListTable == null)
            {
                return NotFound();
            }

            return View(contactListTable);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactName,ContactPhone,ContactRemarks")] ContactListTable contactListTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactListTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactListTable);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ContactListTables == null)
            {
                return NotFound();
            }

            var contactListTable = await _context.ContactListTables.FindAsync(id);
            if (contactListTable == null)
            {
                return NotFound();
            }
            return View(contactListTable);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ContactName,ContactPhone,ContactRemarks")] ContactListTable contactListTable)
        {
            if (id != contactListTable.ContactName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactListTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactListTableExists(contactListTable.ContactName))
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
            return View(contactListTable);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ContactListTables == null)
            {
                return NotFound();
            }

            var contactListTable = await _context.ContactListTables
                .FirstOrDefaultAsync(m => m.ContactName == id);
            if (contactListTable == null)
            {
                return NotFound();
            }

            return View(contactListTable);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ContactListTables == null)
            {
                return Problem("Entity set 'ContactDbApiContext.ContactListTables'  is null.");
            }
            var contactListTable = await _context.ContactListTables.FindAsync(id);
            if (contactListTable != null)
            {
                _context.ContactListTables.Remove(contactListTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactListTableExists(string id)
        {
          return (_context.ContactListTables?.Any(e => e.ContactName == id)).GetValueOrDefault();
        }
    }
}
