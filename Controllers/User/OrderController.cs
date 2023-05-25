using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;

namespace OnlineBookShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }



    }

}
