using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;
using OnlineBookShop.Models;

namespace OnlineBookShop.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IActionResult Profile()
        {
            int? currentUserID = HttpContext.Session.GetInt32("CurrentUserID");
            var user = unitOfWork.GetRepository<User>().GetById(currentUserID);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost] //Update UserProfile
        [ValidateAntiForgeryToken]
        public IActionResult Profile(User user)
        {
            unitOfWork.GetRepository<User>().Update(user);
            unitOfWork.SaveChanges();
            return View();
        }

    }
}
