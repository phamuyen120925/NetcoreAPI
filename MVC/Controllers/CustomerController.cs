using Microsoft.AspNetCore.Mvc;
using MVC.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        public async Task<IActionResult> OrderHistory(string id)
        {
             var model = await _context.OrderDetail
                .Include(x => x.Order)
                     .ThenInclude(x => x.Customer)
                .Include(x => x.Product)
                .Where(x => x.Order.CustomerID == id)
                .Select(x => new CustomerOrderVM
                {
                     CustomerName = x.Order.Customer.FullName,
                     OrderID = x.OrderID,
                     ProductName = x.Product.ProductName,
                     Quantity = x.Quantity
                })
                 .ToListAsync();

             return View(model);
        }
    }
}