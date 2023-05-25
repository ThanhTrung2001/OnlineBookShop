using Microsoft.AspNetCore.Mvc;
using OnlineBookShop.Models;

namespace OnlineBookShop.Controllers
{
    public class ImportBillController : Controller
    {
        //Add Book to importbill
        public IActionResult Index()
        {
            return View();
        }

        //create importbill
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ImportBill importBill)
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

    }
}
