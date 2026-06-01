using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class ExportDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExportDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExportDetail
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ExportDetail
                .Include(e => e.Device)
                .Include(e => e.ExportReceipt);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ExportDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportDetail = await _context.ExportDetail
                .Include(e => e.Device)
                .Include(e => e.ExportReceipt)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (exportDetail == null)
            {
                return NotFound();
            }

            return View(exportDetail);
        }

        // GET: ExportDetail/Create
        public IActionResult Create()
        {
            ViewData["DeviceID"] =
                new SelectList(_context.Device,
                               "DeviceID",
                               "DeviceName");

            ViewData["ExportID"] =
                new SelectList(_context.ExportReceipt,
                               "ExportID",
                               "ExportID");

            return View();
        }

        // POST: ExportDetail/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,ExportID,DeviceID,Quantity,UnitPrice")]
            ExportDetail exportDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exportDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["DeviceID"] =
                new SelectList(_context.Device,
                               "DeviceID",
                               "DeviceName",
                               exportDetail.DeviceID);

            ViewData["ExportID"] =
                new SelectList(_context.ExportReceipt,
                               "ExportID",
                               "ExportID",
                               exportDetail.ExportID);

            return View(exportDetail);
        }

        // GET: ExportDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportDetail = await _context.ExportDetail.FindAsync(id);

            if (exportDetail == null)
            {
                return NotFound();
            }

            ViewData["DeviceID"] =
                new SelectList(_context.Device,
                               "DeviceID",
                               "DeviceName",
                               exportDetail.DeviceID);

            ViewData["ExportID"] =
                new SelectList(_context.ExportReceipt,
                               "ExportID",
                               "ExportID",
                               exportDetail.ExportID);

            return View(exportDetail);
        }

        // POST: ExportDetail/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,ExportID,DeviceID,Quantity,UnitPrice")]
            ExportDetail exportDetail)
        {
            if (id != exportDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exportDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExportDetailExists(exportDetail.Id))
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

            ViewData["DeviceID"] =
                new SelectList(_context.Device,
                               "DeviceID",
                               "DeviceName",
                               exportDetail.DeviceID);

            ViewData["ExportID"] =
                new SelectList(_context.ExportReceipt,
                               "ExportID",
                               "ExportID",
                               exportDetail.ExportID);

            return View(exportDetail);
        }

        // GET: ExportDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exportDetail = await _context.ExportDetail
                .Include(e => e.Device)
                .Include(e => e.ExportReceipt)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (exportDetail == null)
            {
                return NotFound();
            }

            return View(exportDetail);
        }

        // POST: ExportDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exportDetail = await _context.ExportDetail.FindAsync(id);

            if (exportDetail != null)
            {
                _context.ExportDetail.Remove(exportDetail);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ExportDetailExists(int id)
        {
            return _context.ExportDetail.Any(e => e.Id == id);
        }
    }
}