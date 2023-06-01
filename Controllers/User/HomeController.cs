using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;
using OnlineBookShop.Models;
using System.Diagnostics;

namespace OnlineBookShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork _unitOfWork)
        {
            _logger = logger;
            unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
            int? currentUserType = HttpContext.Session.GetInt32("CurrentUserType");
            if (currentUserType == null)
            {
                return RedirectToAction("Login", "Session");
            }
            else if (currentUserType != 2)
            {
                return RedirectToAction("Login", "StaffSession");
            }
            var entity = unitOfWork.GetRepository<Book>().GetAll();
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string searchString)
        {
            if (searchString == null)
            {
                var entity = unitOfWork.GetRepository<Book>().GetAll();
                return View(entity);
            }

            var result = unitOfWork.GetBookRepository().FindingByName(searchString);
            return View(result);
        }

        public IActionResult Detail(int id)
        {
            var entity = unitOfWork.GetRepository<Book>().GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //Add To Cart
        public IActionResult Detail(int id, int amountInput)
        {
            int currentUserID = (int)HttpContext.Session.GetInt32("CurrentUserID");
            var cart = unitOfWork.GetCartRepository().GetByUserId(currentUserID);
            var book = unitOfWork.GetBookRepository().GetById(id);
            var cartItem = new CartItem()
            {
                CartID = cart.CartID,
                BookID = id,
                Quantity = amountInput,
                Price = (book.IsSale == true) ? (book.Price) : (book.Price * (100 - book.SalePercent) / 100),
            };
            unitOfWork.GetCartRepository().AddProductToCart(cart.CartID, id, cartItem);
            unitOfWork.SaveChanges();
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}