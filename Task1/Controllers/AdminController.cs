using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Task1.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Salary()
        {
            return View();
        }
    }
}
