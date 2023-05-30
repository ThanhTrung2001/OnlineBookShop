using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;
using OnlineBookShop.Models;

namespace OnlineBookShop.Controllers.Admin
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public AccountController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
            var entity = unitOfWork.GetRepository<User>().GetAll();
            return View(entity);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string searchString)
        {
            if (searchString == null)
            {
                var account = unitOfWork.GetRepository<User>().GetAll();
                return View(account);
            }
            var entity = unitOfWork.GetAccountRepository().Finding(searchString);
            return View(entity);
        }

        public IActionResult Edit(int id)
        {
            var user = unitOfWork.GetRepository<User>().GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<User>().Update(user);
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var entity = unitOfWork.GetRepository<User>().GetById(id);
            unitOfWork.GetRepository<User>().Delete(entity);
            unitOfWork.SaveChanges();
            return View("Index");
        }

        public IActionResult AddressIndex()
        {
            return View();
        }

        public IActionResult AddressCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddressCreate(UserAddress userAddress)
        {
            return View();
        }

        public IActionResult AddressEdit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddressEdit(UserAddress userAddress)
        {
            return View();
        }

        public IActionResult AddressDelete(UserAddress userAddress)
        {
            return View();
        }
    }
}
