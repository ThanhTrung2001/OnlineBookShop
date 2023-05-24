using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
