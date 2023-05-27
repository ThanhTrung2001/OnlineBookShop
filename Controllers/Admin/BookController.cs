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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string searchString, int bookType, int bookAuthor)
        {
            ViewBag.BookType = unitOfWork.GetRepository<BookType>().GetAll();
            ViewBag.BookAuthor = unitOfWork.GetRepository<Author>().GetAll();
            var resultName = unitOfWork.GetRepository<Book>().GetAll();
            var resultAuthor = unitOfWork.GetRepository<Book>().GetAll();
            var resultType = unitOfWork.GetRepository<Book>().GetAll();
            if (bookType != 0)
            {
                resultType = unitOfWork.GetBookRepository().FindingByBookType(bookType);
            }
            if (bookAuthor != 0)
            {
                resultAuthor = unitOfWork.GetBookRepository().FindingByAuthor(bookAuthor);
            }
            if (searchString != null)
            {
                resultName = unitOfWork.GetBookRepository().FindingByName(searchString);
            }
            List<Book> books = new List<Book>();
            foreach (var itemName in resultName)
            {
                foreach (var itemType in resultType)
                {
                    foreach (var itemAuthor in resultAuthor)
                    {
                        if (itemName.BookID == itemType.BookID && itemType.BookID == itemAuthor.BookID)
                        {
                            books.Add(itemName);
                        }
                    }
                }
            }
            return View(books);
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
