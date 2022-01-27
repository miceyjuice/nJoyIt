using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public void Add(Book book)
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

        public void Delete(int bookId)
        {
            var bookToDelete = _db.Books.SingleOrDefault(b => b.Id == bookId);
            if(bookToDelete == null) return;
            _db.Books.Remove(bookToDelete);
            _db.SaveChanges();
        }

        public IQueryable<Book> FindAll() 
            => _db.Books;

        public Book FindById(int bookId) 
            => _db.Books.Include(i => i.Reviews).ThenInclude(it => it.User).SingleOrDefault(b => b.Id == bookId);
    }
}
