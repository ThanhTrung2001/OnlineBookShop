using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;
using OnlineBookShop.Models;

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
            int currentUserID = (int)HttpContext.Session.GetInt32("CurrentUserID");
            var entity = unitOfWork.GetCartRepository().GetByUserId(currentUserID);
            ViewBag.ItemList = unitOfWork.GetCartRepository().GetItemListByCartId(entity.CartID);
            ViewBag.BookList = unitOfWork.GetBookRepository().GetAll();
            entity.Cost = 0;
            foreach (var item in unitOfWork.GetCartRepository().GetItemListByCartId(entity.CartID))
            {
                entity.Cost += item.Price * item.Quantity;
                unitOfWork.GetCartRepository().Update(entity);

            }
            unitOfWork.SaveChanges();
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Cart cart)
        {
            var order = new Order(
                );
            return RedirectToAction("Create", "Order");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            return View();
        }


    }
}
