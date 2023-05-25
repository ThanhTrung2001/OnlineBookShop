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
            return View();
        }

        [HttpPost] //Update UserProfile
        [ValidateAntiForgeryToken]
        public IActionResult Profile(User user)
        {

            return View();
        }












    }
}
