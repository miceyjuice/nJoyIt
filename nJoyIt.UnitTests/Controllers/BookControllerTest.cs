using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nJoyIt.Controllers;
using nJoyIt.Models;
using nJoyIt.Repositories;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;

namespace nJoyIt.UnitTests.Controllers
{
    class BookControllerTest
    {
        [Test]
        public void Save_SaveBook_ShouldSaveBook()
        {
            IBookRepository bookRepository = Substitute.For<IBookRepository>();
            IReviewRepository reviewRepository = Substitute.For<IReviewRepository>();
            BookController bookController = new BookController(bookRepository, reviewRepository);

            Book book = new Book
            {
                Id = 1,
                Title = "Something",
                Author = "Jeremy",
                BookImageUrl = "https://e.wsei.edu.pl/",
                Description = "Creepy book",
                Genre = "thriller",
                PublicationYear = 1998,
            };

            bookController.Save(book);
            bookRepository.Received().AddBook(Arg.Is<Book>(x => x == book));
        }
    }
}
