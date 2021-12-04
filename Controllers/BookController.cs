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
        public IActionResult Save()
        {
            return View("BookForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Book book)
        {
            if(book.Id == 0) _db.Books.Add(book);
            else
            {
                var bookInDb = _db.Books.Single(b => b.Id == book.Id);

                bookInDb.Author = book.Author;
                bookInDb.BookImageUrl = book.BookImageUrl;
                bookInDb.Description = book.Description;
                bookInDb.Genre = book.Genre;
                bookInDb.Reviews = book.Reviews;
                bookInDb.PublicationYear = book.PublicationYear;
                bookInDb.Title = book.Title;
            }
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

        public IActionResult Edit(int id)
        {
            var book = _db.Books.SingleOrDefault(b => b.Id == id);
            if (book == null) return NotFound();

            return View("BookForm", book);
        }
    }

}
