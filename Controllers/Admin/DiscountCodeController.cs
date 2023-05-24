using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop.Controllers
{
    public class DiscountCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
