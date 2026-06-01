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
    public class ExportReceiptController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExportReceiptController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExportReceipt
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExportReceipt.ToListAsync());
        }

        // GET: ExportReceipt/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportReceipt = await _context.ExportReceipt
                .FirstOrDefaultAsync(m => m.ExportID == id);
            if (exportReceipt == null)
            {
                return NotFound();
            }

            return View(exportReceipt);
        }

        // GET: ExportReceipt/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExportReceipt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExportID,ExportDate")] ExportReceipt exportReceipt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exportReceipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exportReceipt);
        }

        // GET: ExportReceipt/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportReceipt = await _context.ExportReceipt.FindAsync(id);
            if (exportReceipt == null)
            {
                return NotFound();
            }
            return View(exportReceipt);
        }

        // POST: ExportReceipt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ExportID,ExportDate")] ExportReceipt exportReceipt)
        {
            if (id != exportReceipt.ExportID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exportReceipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExportReceiptExists(exportReceipt.ExportID))
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
            return View(exportReceipt);
        }

        // GET: ExportReceipt/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportReceipt = await _context.ExportReceipt
                .FirstOrDefaultAsync(m => m.ExportID == id);
            if (exportReceipt == null)
            {
                return NotFound();
            }

            return View(exportReceipt);
        }

        // POST: ExportReceipt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var exportReceipt = await _context.ExportReceipt.FindAsync(id);
            if (exportReceipt != null)
            {
                _context.ExportReceipt.Remove(exportReceipt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExportReceiptExists(string id)
        {
            return _context.ExportReceipt.Any(e => e.ExportID == id);
        }
    }
}
