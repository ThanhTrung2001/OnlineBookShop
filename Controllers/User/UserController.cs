using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
