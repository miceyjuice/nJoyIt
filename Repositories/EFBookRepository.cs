using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nJoyIt.Data;
using nJoyIt.Models;

namespace nJoyIt.Repositories
{
    public class EFBookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;
        public EFBookRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void AddBook(Book book)
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
        }

        public IQueryable<Book> GetAllBooks() 
            => _db.Books;

        public Book GetBookById(int bookId) 
            => _db.Books.SingleOrDefault(b => b.Id == bookId);
    }
}
