using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Models;

namespace Task1.Controllers
{
    public class HRController : Controller
    {
        private readonly EDbContext _context;

        public HRController(EDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LeaveRequests()
        {
            var leaveRequests = _context.LeaveRequests.Include(lr => lr.Employee).ToList();
            return View(leaveRequests);
        }

        [HttpPost]
        public IActionResult Approve(int id)
        {
            var leaveRequest = _context.LeaveRequests.Find(id);
            if (leaveRequest != null)
            {
                leaveRequest.Approved = true;
                _context.SaveChanges();
            }
            return RedirectToAction("LeaveRequests");
        }

        [HttpPost]
        public IActionResult Reject(int id)
        {
            var leaveRequest = _context.LeaveRequests.Find(id);
            if (leaveRequest != null)
            {
                leaveRequest.Approved = false;
                _context.SaveChanges();
            }
            return RedirectToAction("LeaveRequests");
        }
    }
}
