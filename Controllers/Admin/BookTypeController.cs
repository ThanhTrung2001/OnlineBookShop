using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;
using OnlineBookShop.Models;

namespace OnlineBookShop.Controllers
{
    public class BookTypeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public BookTypeController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
            var bookTypes = unitOfWork.GetRepository<BookType>().GetAll();
            return View(bookTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookType bookType)
        {
            if (bookType.TypeName == "")
            {
                ModelState.AddModelError("Custom Error", "You must fill all the blank!!!");
            }
            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<BookType>().Insert(bookType);
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bookType = unitOfWork.GetRepository<BookType>().GetById(id);
            if (bookType == null)
            {
                return NotFound();
            }
            return View("Create", bookType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookType bookType)
        {
            if (bookType.TypeName == "")
            {
                ModelState.AddModelError("Custom Error", "You must fill all the blank!!!");
            }
            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<BookType>().Update(bookType);
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var entity = unitOfWork.GetRepository<BookType>().GetById(id);
            unitOfWork.GetRepository<BookType>().Delete(entity);
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
