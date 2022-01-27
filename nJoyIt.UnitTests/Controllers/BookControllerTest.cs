using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nJoyIt.Controllers;
using nJoyIt.Models;
using nJoyIt.Repositories;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;

namespace nJoyIt.UnitTests.Controllers
{
    class BookControllerTest
    {
        [Test]
        public void ShouldAddValidBook()
        {
            // Arrange
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

            // Act
            bookController.Save(book);

            // Assert
            bookRepository.Received().Add(Arg.Is<Book>(x => x == book));
        }
        [Test]
        public void ShouldNotSaveInvalidBook()
        {
            IBookRepository bookRepository = Substitute.For<IBookRepository>();
            IReviewRepository reviewRepository = Substitute.For<IReviewRepository>();
            BookController bookController = new BookController(bookRepository, reviewRepository);

            Book book = new Book
            {
                Id = 1,
                Title = "Something"
            };

            bookController.Save(book);
            bookRepository.DidNotReceive().Add(Arg.Is<Book>(x => x == book));
        }
    }
}
