using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nJoyIt.Models;

namespace nJoyIt.Repositories
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        IQueryable<Book> GetAllBooks();
        Book GetBookById(int bookId);
    }
}
