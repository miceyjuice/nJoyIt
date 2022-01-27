﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using nJoyIt.Data;
using nJoyIt.Models;
using nJoyIt.Repositories;
using nJoyIt.ViewModels;

namespace nJoyIt.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IReviewRepository _reviewRepository;
        public BookController(IBookRepository bookRepository, IReviewRepository reviewRepository)
        {
            _bookRepository = bookRepository;
            _reviewRepository = reviewRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Book> objList = _bookRepository.FindAll();
            return View(objList);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Save()
        {
            return View("BookForm");
        }

        [HttpPost]
        public IActionResult Save(Book book)
        {
            if (!ModelState.IsValid) return View("BookForm", book);
            _bookRepository.Add(book);

            return RedirectToAction("Index");
        }
        public IActionResult Info(int id)
        {
            BookDetailsViewModel model = new BookDetailsViewModel();
            model.Book = _bookRepository.FindById(id);
            model.Review = _reviewRepository.GetReviewsByBookId(id).ToList();

            return View(model);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var book = _bookRepository.FindById(id);
            if (book == null) return NotFound();

            return View("BookForm", book);
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            _bookRepository.Delete(id);
            return Redirect("/");
        }
    }

}
