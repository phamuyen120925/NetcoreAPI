using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class ImportReceiptController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImportReceiptController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ImportReceipt
        public async Task<IActionResult> Index()
        {
            return View(await _context.ImportReceipt.ToListAsync());
        }

        // GET: ImportReceipt/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importReceipt = await _context.ImportReceipt
                .FirstOrDefaultAsync(m => m.ImportID == id);
            if (importReceipt == null)
            {
                return NotFound();
            }

            return View(importReceipt);
        }

        // GET: ImportReceipt/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ImportReceipt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImportID,ImportDate")] ImportReceipt importReceipt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(importReceipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(importReceipt);
        }

        // GET: ImportReceipt/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importReceipt = await _context.ImportReceipt.FindAsync(id);
            if (importReceipt == null)
            {
                return NotFound();
            }
            return View(importReceipt);
        }

        // POST: ImportReceipt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ImportID,ImportDate")] ImportReceipt importReceipt)
        {
            if (id != importReceipt.ImportID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(importReceipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImportReceiptExists(importReceipt.ImportID))
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
            return View(importReceipt);
        }

        // GET: ImportReceipt/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importReceipt = await _context.ImportReceipt
                .FirstOrDefaultAsync(m => m.ImportID == id);
            if (importReceipt == null)
            {
                return NotFound();
            }

            return View(importReceipt);
        }

        // POST: ImportReceipt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var importReceipt = await _context.ImportReceipt.FindAsync(id);
            if (importReceipt != null)
            {
                _context.ImportReceipt.Remove(importReceipt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImportReceiptExists(string id)
        {
            return _context.ImportReceipt.Any(e => e.ImportID == id);
        }
    }
}
