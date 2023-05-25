using Microsoft.AspNetCore.Mvc;

namespace OnlineBookShop.Controllers
{
    public class AddressController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
