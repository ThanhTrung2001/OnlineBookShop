using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;
using System.Diagnostics;

namespace OnlineBookShop.Controllers
{
    public class DashboardController : Controller
    {

        private readonly IUnitOfWork unitOfWork;

        public DashboardController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
            int? currentUserType = HttpContext.Session.GetInt32("CurrentUserType");
            Debug.WriteLine(currentUserType);
            if (currentUserType == null)
            {
                return RedirectToAction("Login", "StaffSession");
            }
            return View();
        }
    }
}
