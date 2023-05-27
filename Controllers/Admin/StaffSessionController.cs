using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;
using OnlineBookShop.Models;
using System.Diagnostics;

namespace OnlineBookShop.Controllers
{
    public class StaffSessionController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public StaffSessionController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IActionResult Login()
        {
            int? currentUserType = HttpContext.Session.GetInt32("CurrentUserType");
            Debug.WriteLine(currentUserType);
            if (currentUserType == 1 || currentUserType == 0)
            {
                return View("Index", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Staff staff)
        {
            IEnumerable<Staff> entity = unitOfWork.GetRepository<Staff>().GetAll();
            foreach (var member in entity)
            {
                if (staff.Email == member.Email && staff.Password == member.Password)
                {
                    HttpContext.Session.SetInt32("CurrentUserID", member.StaffID);
                    HttpContext.Session.SetInt32("CurrentUserType", member.UserType);
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
