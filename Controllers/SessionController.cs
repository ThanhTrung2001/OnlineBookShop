using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(int i)
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(int i)
        {
            return View();
        }

    }
}
