using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;
using OnlineBookShop.Models;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserAddress value)
        {
            value.UserID = (int)HttpContext.Session.GetInt32("CurrentUserID");
            unitOfWork.GetRepository<UserAddress>().Insert(value);
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var entity = unitOfWork.GetUserAddressRepository().GetById(id);
            unitOfWork.SaveChanges();
            return View("Create", entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserAddress value)
        {
            unitOfWork.GetUserAddressRepository().Update(value);
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var address = unitOfWork.GetUserAddressRepository().GetById(id);
            unitOfWork.GetUserAddressRepository().Delete(address);
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
