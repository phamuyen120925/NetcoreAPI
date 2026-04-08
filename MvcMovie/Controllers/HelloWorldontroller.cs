using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();
        }
       
        // GET: /HelloWorld/Welcome
        
        public string Welcome()
        {
            return "Pham Thi Uyen 2221050369";
        }
    }
}