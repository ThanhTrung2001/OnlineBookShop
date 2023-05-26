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

        public IActionResult Detail(int id)
        {
            var entity = unitOfWork.GetRepository<Order>().GetById(id);
            //if (entity == null)
            //{
            //    return NotFound(); 
            //}
            return View();
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
