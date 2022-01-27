using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using nJoyIt.Data;
using nJoyIt.Models;
using nJoyIt.Repositories;
using NUnit.Framework;

namespace nJoyIt.UnitTests.Repositories
{
    public class BookRepositoryTests
    {
        private ApplicationDbContext _ctx;
        public BookRepositoryTests()
        {
            DbContextOptionsBuilder<nJoyIt.Data.ApplicationDbContext> dbOptions =
                new DbContextOptionsBuilder<nJoyIt.Data.ApplicationDbContext>();
            dbOptions.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _ctx = new ApplicationDbContext(dbOptions.Options);
        }

        [Test]
        public void ShouldCreateBook()
        {
            // Arrange
            _ctx.Books.RemoveRange(_ctx.Books);
            IBookRepository bookRepository = new EFBookRepository(_ctx);
            var book = new Book
            {
                Title = "test"
            };

            // Act
            bookRepository.Add(book);

            // Assert
            Assert.AreEqual(_ctx.Books.ToList().Count, 1);
        }

        [Test]
        public void ShouldGetAllBooks()
        {
            // Arrange
            _ctx.Books.RemoveRange(_ctx.Books);
            IBookRepository bookRepository = new EFBookRepository(_ctx);
            var book = new Book
            {
                Title = "test"
            };

            // Act
            _ctx.Books.Add(book);
            _ctx.SaveChanges();
            var books = bookRepository.FindAll();

            // Assert
            Assert.AreEqual(1, books.ToList().Count);
        }

        [Test]
        public void ShouldGetBookById()
        {
            // Arrange
            _ctx.Books.RemoveRange(_ctx.Books);
            IBookRepository bookRepository = new EFBookRepository(_ctx);
            var book = new Book
            {
                Title = "test"
            };

            // Act
            var createdBook = _ctx.Books.Add(book);
            _ctx.SaveChanges();
            var foundBook = bookRepository.FindById(createdBook.Entity.Id);

     
            // Assert
            Assert.AreEqual(book, foundBook);
        }

        [Test]
        public void ShouldDeleteBookById()
        {
            // Arrange
            _ctx.Books.RemoveRange(_ctx.Books);
            IBookRepository bookRepository = new EFBookRepository(_ctx);
            var book = new Book
            {
                Title = "test"
            };

            // Act
            var createdBook = _ctx.Books.Add(book);
            _ctx.SaveChanges();
            bookRepository.Delete(createdBook.Entity.Id);

            // Assert
            Assert.AreEqual(0,_ctx.Books.ToList().Count);
        }
    }
}
