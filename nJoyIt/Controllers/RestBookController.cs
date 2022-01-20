using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nJoyIt.Models;
using nJoyIt.Repositories;

namespace nJoyIt.Controllers
{
    [Route("api/v1/books")]
    public class RestBookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public readonly IReviewRepository _reviewRepository;
        public RestBookController(IBookRepository bookRepository, IReviewRepository reviewRepository)
        {
            _bookRepository = bookRepository;
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return BadRequest();
            }
            return book;
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            _bookRepository.DeleteBook(id);
            return Ok();
        }
    }
}
