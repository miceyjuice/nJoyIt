using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using nJoyIt.Data;
using nJoyIt.Models;

namespace nJoyIt.Repositories
{
    public class EFReviewRepository : IRepository<Review>
    {
        private readonly ApplicationDbContext _db;

        public EFReviewRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<Review> GetReviewsByBookId(int bookId)
        {
            return _db.Reviews.Include("User").Where(r => r.Book.Id == bookId);
        }

        public void Add(Review review)
        {
            _db.Reviews.Add(review);
            _db.SaveChanges();
        }
    }
}
