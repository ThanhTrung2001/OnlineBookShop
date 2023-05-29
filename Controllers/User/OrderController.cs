using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;
using OnlineBookShop.Models;

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
            int currentUserID = (int)HttpContext.Session.GetInt32("CurrentUserID");
            var entity = unitOfWork.GetOrderRepository().Finding(currentUserID);
            return View(entity);
        }

        public IActionResult Detail(int id)
        {
            var entity = unitOfWork.GetOrderRepository().GetById(id);
            ViewBag.BookList = unitOfWork.GetBookRepository().GetAll();
            ViewBag.ItemList = unitOfWork.GetOrderRepository().GetItemListByOrderId(id);
            return View(entity);
        }

        public IActionResult Create()
        {
            int currentUserID = (int)HttpContext.Session.GetInt32("CurrentUserID");
            var entity = unitOfWork.GetCartRepository().GetByUserId(currentUserID);
            ViewBag.Cart = entity;
            ViewBag.ItemList = unitOfWork.GetCartRepository().GetItemListByCartId(entity.CartID);
            ViewBag.BookList = unitOfWork.GetBookRepository().GetAll();
            ViewBag.AddressSelection = unitOfWork.GetUserAddressRepository().Finding(currentUserID);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            int currentUserID = (int)HttpContext.Session.GetInt32("CurrentUserID");
            var entity = unitOfWork.GetCartRepository().GetByUserId(currentUserID);
            order.UserID = currentUserID;
            order.CartID = entity.CartID;
            order.OrderDate = DateTime.Now;
            order.Status = "Waiting";
            order.DeliveryStatus = "Waiting";
            order.TotalAmount = entity.Cost;
            unitOfWork.GetOrderRepository().Insert(order);
            unitOfWork.SaveChanges();
            var cartItems = unitOfWork.GetCartRepository().GetItemListByCartId(entity.CartID);
            foreach (var item in cartItems)
            {
                OrderItem newItem = new OrderItem()
                {
                    OrderID = order.OrderID,
                    BookID = item.BookID,
                    Quantity = item.Quantity,
                    Price = item.Price,
                };
                var book = unitOfWork.GetBookRepository().GetById(item.BookID);
                book.Stock -= item.Quantity;
                unitOfWork.GetBookRepository().Update(book);
                unitOfWork.GetOrderRepository().AddOrderItems(newItem);
                unitOfWork.GetRepository<CartItem>().Delete(item);
            }
            unitOfWork.SaveChanges();
            return View("Index", "Order");
        }



    }

}
