using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nJoyIt.Data;
using nJoyIt.Models;

namespace nJoyIt.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ReviewController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Book");
        }

        public IActionResult Add(int bookId)
        {
            ViewBag.bookId = bookId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Review obj, int bookId)
        {
            obj.ReviewDate = DateTime.Now;
            obj.Book = _db.Books.Where(b => b.Id == bookId).ToList()[0];
            _db.Reviews.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Info", "Book", new { id = bookId });
        }
    }
}
