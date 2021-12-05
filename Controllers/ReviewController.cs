using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nJoyIt.Data;
using nJoyIt.Models;
using nJoyIt.Repositories;

namespace nJoyIt.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IBookRepository _bookRepository;
        public ReviewController(IReviewRepository reviewRepository, IBookRepository bookRepository)
        {
            _reviewRepository = reviewRepository;
            _bookRepository = bookRepository;
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
        public IActionResult Add(Review review, int bookId)
        {
            review.ReviewDate = DateTime.Now;
            review.Book = _bookRepository.GetBookById(bookId);
            _reviewRepository.AddReview(review);
            
            return RedirectToAction("Info", "Book", new { id = bookId });
        }
    }
}
