using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Task1.Models;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult LoginAd()
        {
            //ViewData["Roles"] = "admin";
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> LoginAd(string username, string password)
        {
            var user = "Muskan@123";
            var pass = "1234M";
            var e = "M@123";
            var p = "123";

            if (username == user && password == pass)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "admin") // Set admin role claim
                };

                var userIdentity = new ClaimsIdentity(claims, "login");
                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);

                return RedirectToAction("Index");
            }
            else if (username == e && password == p)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "employee") // Set employee role claim
                };

                var userIdentity = new ClaimsIdentity(claims, "login");
                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View();
            }
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Task()
        {
            return View();
        }
        public IActionResult AddEmployee()
            
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
