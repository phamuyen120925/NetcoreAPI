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
    public class DeviceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Device
        // GET: Device
         public async Task<IActionResult> Index(string searchString)
         { 
             var devices = _context.Device
                 .Include(d => d.DeviceCategory)
                 .Include(d => d.Supplier)
                 .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
             {
                 devices = devices.Where(d =>
                 d.DeviceName.Contains(searchString));
             }

             return View(await devices.ToListAsync());
        }

        // GET: Device/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device
                .Include(d => d.DeviceCategory)
                .Include(d => d.Supplier)
                .FirstOrDefaultAsync(m => m.DeviceID == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Device/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.DeviceCategory, "CategoryID", "CategoryID");
            ViewData["SupplierID"] = new SelectList(_context.Supplier, "SupplierID", "SupplierID");
            return View();
        }

        // POST: Device/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceID,DeviceName,SupplierID,CategoryID")] Device device)
        {
            if (ModelState.IsValid)
            {
                _context.Add(device);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.DeviceCategory, "CategoryID", "CategoryID", device.CategoryID);
            ViewData["SupplierID"] = new SelectList(_context.Supplier, "SupplierID", "SupplierID", device.SupplierID);
            return View(device);
        }

        // GET: Device/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.DeviceCategory, "CategoryID", "CategoryID", device.CategoryID);
            ViewData["SupplierID"] = new SelectList(_context.Supplier, "SupplierID", "SupplierID", device.SupplierID);
            return View(device);
        }

        // POST: Device/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DeviceID,DeviceName,SupplierID,CategoryID")] Device device)
        {
            if (id != device.DeviceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(device);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceExists(device.DeviceID))
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
            ViewData["CategoryID"] = new SelectList(_context.DeviceCategory, "CategoryID", "CategoryID", device.CategoryID);
            ViewData["SupplierID"] = new SelectList(_context.Supplier, "SupplierID", "SupplierID", device.SupplierID);
            return View(device);
        }

        // GET: Device/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device
                .Include(d => d.DeviceCategory)
                .Include(d => d.Supplier)
                .FirstOrDefaultAsync(m => m.DeviceID == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Device/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var device = await _context.Device.FindAsync(id);
            if (device != null)
            {
                _context.Device.Remove(device);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(string id)
        {
            return _context.Device.Any(e => e.DeviceID == id);
        }
    }
}
