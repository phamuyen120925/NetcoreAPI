using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using MVC.Models.ViewModels;
using OfficeOpenXml;

namespace MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách Student + Faculty
        public async Task<IActionResult> Index()
        {
            var model = await _context.Student
                .Include(s => s.Faculty)
                .Select(s => new StudentFacultyVM
                {
                    StudentID = s.StudentID,
                    FullName = s.FullName,
                    FacultyName = s.Faculty.FacultyName
                })
                .ToListAsync();

            return View(model);
        }

        // GET: Student/Import
        public IActionResult Import()
        {
            return View();
        }

        // POST: Student/Import
        [HttpPost]
        public async Task<IActionResult> Import(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Message = "Vui lòng chọn file Excel";
                return View();
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);

                ExcelPackage.License.SetNonCommercialPersonal("Student");

                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        Student st = new Student();

                        st.StudentID =
                            worksheet.Cells[row, 1].Text;

                        st.FullName =
                            worksheet.Cells[row, 2].Text;

                        st.FacultyID =
                            worksheet.Cells[row, 3].Text;

                        _context.Student.Add(st);
                    }

                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}