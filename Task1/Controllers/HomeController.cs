using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Task1.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EDbContext _context;
        public HomeController(ILogger<HomeController> logger,EDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User model)
        {

            //var newUser = new User
            //{
            //    Name = model.Name,

            //    Address = model.Address,
            //    Dob = model.Dob,
            //    City = model.City,
            //    State = model.State,
            //    Gender = model.Gender,
            //    Subscribe = model.Subscribe
            //};

            _context.Users.Add(model);
            _context.SaveChanges();

            return RedirectToAction("LoginAd");




        }
        [HttpGet]
        public IActionResult LoginAd()
        {
            //ViewData["Roles"] = "admin";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAd(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim(ClaimTypes.Role, user.Role) 
                };

                var userIdentity = new ClaimsIdentity(claims, "login");
                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View();
            }
        }
        //[HttpPost]
        //public IActionResult AddItem(string newItem)
        //{


        //    var newItemObject = new State
        //    {
        //        Name = newItem
        //    };


        //    _context.States.Add(newItemObject);
        //    _context.SaveChanges();


        //    return Json(newItemObject);


        //}
        //public IActionResult AddCity(int stateId, string newCityName)
        //{

        //    var newCity = new City
        //    {
        //        Name = newCityName,
        //        StateId = stateId
        //    };


        //    _context.Cities.Add(newCity);
        //    _context.SaveChanges();


        //    return Json(newCity);


        //}
        public IActionResult cities(int stId)
        {
            //TempData["stId"] = stId;

            var cities = _context.Cities.Where(citi => citi.StateId == stId).ToList();
            //var menus = _context.Cities.ToList();

            return Json(cities);
        }

        public IActionResult state()
        {

            var states = _context.States.ToList();
            return Json(states);
        }
        public IActionResult ReadView()
        {
            var r = (from User in _context.Users
                     join city in _context.Cities on User.City equals city.Name
                     join state in _context.States on User.State equals state.Name
                     orderby city.Name
                     select new
                     {
                         id = User.Id,
                         name = User.Name,
                         phone = User.Phone,
                         email = User.Email,
                         address = User.Address,
                         dob = User.Dob,
                         city = city.Name,
                         state = state.Name,
                     }
                     ).ToList();
            return Json(r);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
           
            await HttpContext.SignOutAsync();

           
            return RedirectToAction("LoginAd");
        }
        public IActionResult Index()
        {
            var userEmailOrUsername = User.Identity.Name;
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmailOrUsername);
            var registeredName = user != null ? user.Name : "Unknown";

            ViewData["RegisteredName"] = registeredName;

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
