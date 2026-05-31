using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models.ViewModels;

namespace MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}