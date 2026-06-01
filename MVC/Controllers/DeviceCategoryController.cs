using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class DeviceCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeviceCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ + SEARCH
        public async Task<IActionResult> Index(string searchString)
        {
            var categories = from c in _context.DeviceCategory
                             select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(x =>
                    x.CategoryName.Contains(searchString));
            }

            return View(await categories.ToListAsync());
        }

        // DETAILS
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.DeviceCategory
                .FirstOrDefaultAsync(m => m.CategoryID == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeviceCategory category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // EDIT GET
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.DeviceCategory.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, DeviceCategory category)
        {
            if (id != category.CategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(category);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // DELETE GET
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.DeviceCategory
                .FirstOrDefaultAsync(m => m.CategoryID == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var category = await _context.DeviceCategory.FindAsync(id);

            if (category != null)
            {
                _context.DeviceCategory.Remove(category);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}