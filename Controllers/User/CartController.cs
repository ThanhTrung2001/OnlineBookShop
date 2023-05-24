using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
