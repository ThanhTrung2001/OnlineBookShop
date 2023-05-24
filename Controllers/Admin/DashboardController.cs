using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
