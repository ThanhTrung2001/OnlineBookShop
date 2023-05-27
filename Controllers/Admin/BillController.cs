using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;
using OnlineBookShop.Models;
using System.Diagnostics;

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
            ViewBag.User = unitOfWork.GetAccountRepository().GetAll();
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(DateTime datepicker)
        {
            Debug.WriteLine(datepicker);
            ViewBag.User = unitOfWork.GetAccountRepository().GetAll();
            if (datepicker.Day == 1 && datepicker.Month == 1 && datepicker.Year == 0001)
            {
                var entity = unitOfWork.GetRepository<Order>().GetAll();
                return View(entity);
            }
            var result = unitOfWork.GetOrderRepository().Finding(datepicker);
            return View(result);
        }

        public IActionResult Detail(int id)
        {
            var entity = unitOfWork.GetOrderRepository().GetById(id);
            ViewBag.BookList = unitOfWork.GetBookRepository().GetAll();
            ViewBag.ItemList = unitOfWork.GetOrderRepository().GetItemListByOrderId(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var entity = unitOfWork.GetRepository<Order>().GetById(id);
            if (entity != null)
            {
                unitOfWork.GetRepository<Order>().Delete(entity);
                unitOfWork.SaveChanges();
                return View("Index");
            }
            return View("Index");
        }
    }
}
