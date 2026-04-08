using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class StudentController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Index(Student st)
        {
            string msg = "Xin chào " + st.StudentCode + " - " + st.FullName;
            ViewBag.message = msg;
            return View();
        }
    }
}