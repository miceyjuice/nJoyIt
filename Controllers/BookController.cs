using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nJoyIt.Data;
using nJoyIt.Models;
using nJoyIt.ViewModels;

namespace nJoyIt.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Book> objList = _db.Books;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book obj)
        {
            _db.Books.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Info(int id)
        {
            BookDetailsViewModel model = new BookDetailsViewModel();
            model.Book = _db.Books.Where(b => b.Id == id).ToList()[0];
            model.Review = _db.Reviews.Where(r => r.Book.Id == model.Book.Id).ToList();
            return View(model);
        }
    }
}
