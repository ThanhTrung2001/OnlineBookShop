using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;
using OnlineBookShop.Models;

namespace OnlineBookShop.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public AuthorController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public IActionResult Index()
        {
            var entity = unitOfWork.GetRepository<Author>().GetAll();
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string searchString)
        {
            if (searchString == null)
            {
                var bookTypes = unitOfWork.GetRepository<Author>().GetAll();
                return View(bookTypes);
            }
            var result = unitOfWork.GetAuthorRepository().Finding(searchString);
            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            if (author.AuthorName == "")
            {
                ModelState.AddModelError("Custom Error", "You must fill all the blank!!!");
            }
            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<Author>().Insert(author);
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = unitOfWork.GetRepository<Author>().GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View("Create", author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author author)
        {
            if (author.AuthorName == "")
            {
                ModelState.AddModelError("Custom Error", "You must fill all the blank!!!");
            }
            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<Author>().Update(author);
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var entity = unitOfWork.GetRepository<Author>().GetById(id);
            unitOfWork.GetRepository<Author>().Delete(entity);
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
