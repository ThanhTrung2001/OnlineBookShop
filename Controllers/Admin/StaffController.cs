using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;
using OnlineBookShop.Models;

namespace OnlineBookShop.Controllers
{
    public class StaffController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public StaffController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
            int? currentUserType = HttpContext.Session.GetInt32("CurrentUserType");
            if (currentUserType != 0)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            var entity = unitOfWork.GetRepository<Staff>().GetAll();
            return View(entity);
        }

        public IActionResult Create()
        {
            int? currentUserType = HttpContext.Session.GetInt32("CurrentUserType");
            if (currentUserType != 0)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<Staff>().Insert(staff);
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            int? currentUserType = HttpContext.Session.GetInt32("CurrentUserType");
            if (currentUserType != 0)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            var staff = unitOfWork.GetRepository<Staff>().GetById(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View("Create", staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Staff staff)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<Staff>().Update(staff);
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var entity = unitOfWork.GetRepository<Staff>().GetById(id);
            unitOfWork.GetRepository<Staff>().Delete(entity);
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
