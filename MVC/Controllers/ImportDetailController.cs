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
    public class ImportDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImportDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ImportDetail
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ImportDetail.Include(i => i.Device).Include(i => i.ImportReceipt);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ImportDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importDetail = await _context.ImportDetail
                .Include(i => i.Device)
                .Include(i => i.ImportReceipt)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (importDetail == null)
            {
                return NotFound();
            }

            return View(importDetail);
        }

        // GET: ImportDetail/Create
        public IActionResult Create()
        {
            ViewData["DeviceID"] = new SelectList(_context.Device, "DeviceID", "DeviceName");
            ViewData["ImportID"] = new SelectList(_context.ImportReceipt, "ImportID", "ImportID");
            return View();
        }

        // POST: ImportDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImportID,DeviceID,Quantity,UnitPrice")] ImportDetail importDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(importDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceID"] = new SelectList(_context.Device, "DeviceID", "DeviceID", importDetail.DeviceID);
            ViewData["ImportID"] = new SelectList(_context.ImportReceipt, "ImportID", "ImportID", importDetail.ImportID);
            return View(importDetail);
        }

        // GET: ImportDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importDetail = await _context.ImportDetail.FindAsync(id);
            if (importDetail == null)
            {
                return NotFound();
            }
            ViewData["DeviceID"] = new SelectList(_context.Device, "DeviceID", "DeviceID", importDetail.DeviceID);
            ViewData["ImportID"] = new SelectList(_context.ImportReceipt, "ImportID", "ImportID", importDetail.ImportID);
            return View(importDetail);
        }

        // POST: ImportDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImportID,DeviceID,Quantity,UnitPrice")] ImportDetail importDetail)
        {
            if (id != importDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(importDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImportDetailExists(importDetail.Id))
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
            ViewData["DeviceID"] = new SelectList(_context.Device, "DeviceID", "DeviceName", importDetail.DeviceID);
            ViewData["ImportID"] = new SelectList(_context.ImportReceipt, "ImportID", "ImportID", importDetail.ImportID);
            return View(importDetail);
        }

        // GET: ImportDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var importDetail = await _context.ImportDetail
                .Include(i => i.Device)
                .Include(i => i.ImportReceipt)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (importDetail == null)
            {
                return NotFound();
            }

            return View(importDetail);
        }

        // POST: ImportDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var importDetail = await _context.ImportDetail.FindAsync(id);
            if (importDetail != null)
            {
                _context.ImportDetail.Remove(importDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImportDetailExists(int id)
        {
            return _context.ImportDetail.Any(e => e.Id == id);
        }
    }
}
