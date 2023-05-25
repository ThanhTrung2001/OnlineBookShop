using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Data.UnitOfWork;
using OnlineBookShop.Models;

namespace OnlineBookShop.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public BookController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
            var entity = unitOfWork.GetRepository<Book>().GetAll();
            ViewBag.BookType = unitOfWork.GetRepository<BookType>().GetAll();
            ViewBag.BookAuthor = unitOfWork.GetRepository<Author>().GetAll();
            return View(entity);
        }

        [HttpGet]
        public IActionResult Detail()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.BookType = unitOfWork.GetRepository<BookType>().GetAll();
            ViewBag.BookAuthor = unitOfWork.GetRepository<Author>().GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<Book>().Insert(book);
                unitOfWork.SaveChanges();
                ViewBag.BookType = unitOfWork.GetRepository<BookType>().GetAll();
                ViewBag.BookAuthor = unitOfWork.GetRepository<Author>().GetAll();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = unitOfWork.GetRepository<Book>().GetById(id);
            ViewBag.BookType = unitOfWork.GetRepository<BookType>().GetAll();
            ViewBag.BookAuthor = unitOfWork.GetRepository<Author>().GetAll();
            if (book == null)
            {
                return NotFound();
            }
            return View("Create", book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.GetRepository<Book>().Update(book);
                unitOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var entity = unitOfWork.GetRepository<Book>().GetById(id);
            unitOfWork.GetRepository<Book>().Delete(entity);
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
