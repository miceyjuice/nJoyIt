using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
        public string Get(int id)
        {
            var book = _bookRepository.FindById(id);
            if (book == null)
            {
                return "";
            }
            return JsonConvert.SerializeObject(book);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            _bookRepository.Delete(id);
            return Ok();
        }
    }
}
