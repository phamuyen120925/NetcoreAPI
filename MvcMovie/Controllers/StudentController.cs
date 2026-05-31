using Microsoft.AspNetCore.Mvc;
using MvcMovie.Data;
using MvcMovie.Models;
using OfficeOpenXml;
using System.IO;

namespace MvcMovie.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Students.ToList();
            return View(data);
        }

        public IActionResult ImportExcel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImportExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("File không hợp lệ");

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);

                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        if (string.IsNullOrEmpty(worksheet.Cells[row, 1].Text))
                            continue;

                        var student = new Student
                        {
                            StudentCode = worksheet.Cells[row, 1].Text,
                            FullName = worksheet.Cells[row, 2].Text,
                            Age = int.TryParse(worksheet.Cells[row, 3].Text, out int age) ? age : 0,
                            Email = worksheet.Cells[row, 4].Text
                        };

                        if (!_context.Students.Any(s => s.StudentCode == student.StudentCode))
                        {
                            _context.Students.Add(student);
                        }
                    }

                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}