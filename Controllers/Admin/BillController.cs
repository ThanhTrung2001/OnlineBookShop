using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;
using OnlineBookShop.Models;

namespace OnlineBookShop.Controllers
{
    public class BillController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public BillController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public IActionResult Index()
        {
            var entity = unitOfWork.GetRepository<Order>().GetAll();
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string datepicker)
        {
            var entity = unitOfWork.GetRepository<Order>().GetAll();
            return View(entity);
        }
    }
}
