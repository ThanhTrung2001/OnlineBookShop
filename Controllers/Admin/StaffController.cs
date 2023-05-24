using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
