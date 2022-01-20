using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using nJoyIt.Data;
using nJoyIt.Models;
using nJoyIt.Repositories;

namespace nJoyIt.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public ReviewController(IReviewRepository reviewRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _reviewRepository = reviewRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
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
            if (User.Identity == null) return RedirectToAction("Add");

            review.ReviewDate = DateTime.Now;
            review.User = _userRepository.GetUserByUserName(User.Identity.Name);
            review.Book = _bookRepository.GetBookById(bookId);

            _reviewRepository.AddReview(review);
            
            return RedirectToAction("Info", "Book", new { id = bookId });
        }
    }
}
