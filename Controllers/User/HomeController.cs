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
            var entity = unitOfWork.GetRepository<Book>().GetAll();
            return View(entity);
        }

        [HttpPost]
        public IActionResult Index(string search)
        {
            var entity = unitOfWork.GetRepository<Book>().GetAll();
            return View(entity);
        }

        public IActionResult Detail(int id)
        {
            var entity = unitOfWork.GetRepository<Book>().GetById(id);
            return View(entity);
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