using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;

namespace OnlineBookShop.Controllers
{
    public class CartController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CartController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
