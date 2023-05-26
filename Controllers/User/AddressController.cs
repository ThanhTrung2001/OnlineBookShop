using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;

namespace OnlineBookShop.Controllers
{
    public class AddressController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public AddressController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
            int currentUserType = (int)HttpContext.Session.GetInt32("CurrentUserID");
            var entity = unitOfWork.GetUserAddressRepository().Finding(currentUserType);
            return View(entity);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
