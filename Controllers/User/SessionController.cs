using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;
using OnlineBookShop.Models;
using System.Diagnostics;

namespace OnlineBookShop.Controllers
{
    public class SessionController : Controller
    {

        private readonly IUnitOfWork unitOfWork;

        public SessionController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IActionResult Login()
        {
            int? currentUserType = HttpContext.Session.GetInt32("CurrentUserType");
            Debug.WriteLine(currentUserType);
            if (currentUserType == 2)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (currentUserType == 1 || currentUserType == 0)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            IEnumerable<User> entity = unitOfWork.GetRepository<User>().GetAll();
            foreach (var member in entity)
            {
                if (user.Email == member.Email && user.Password == member.Password)
                {
                    HttpContext.Session.SetInt32("CurrentUserID", member.UserID);
                    HttpContext.Session.SetInt32("CurrentUserType", member.UserType);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult SignUp()
        {
            int? currentUserType = HttpContext.Session.GetInt32("CurrentUserType");
            Debug.WriteLine(currentUserType);
            if (currentUserType == 2)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (currentUserType == 1 || currentUserType == 0)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(User user)
        {
            var entity = unitOfWork.GetRepository<User>().GetAll();
            foreach (var member in entity)
            {
                if (user.Email == member.Email)
                {
                    return View();
                }
                else
                {
                    user.FullName = "Custom";
                    user.AddressDefaultID = 0;
                    user.UserType = 2;
                    user.CitizenID = "0000000";
                    unitOfWork.GetRepository<User>().Insert(user);
                    unitOfWork.SaveChanges();
                    Debug.WriteLine("Register Success!");
                    HttpContext.Session.SetInt32("CurrentUserID", user.UserID);
                    HttpContext.Session.SetInt32("CurrentUserType", user.UserType);
                    //Create cart
                    Cart cart = new Cart() { UserID = user.UserID, Cost = 0, TotalAmount = 0 };
                    unitOfWork.GetRepository<Cart>().Insert(cart);
                    unitOfWork.SaveChanges();
                    return RedirectToAction("Index", "Home");
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
