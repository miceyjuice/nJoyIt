using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nJoyIt.Data;
using nJoyIt.Models;

namespace nJoyIt.Repositories
{
    public class EFReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _db;

        public EFReviewRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<Review> GetReviewsByBookId(int bookId)
        {
            return _db.Reviews.Where(r => r.Book.Id == bookId);
        }

        public void AddReview(Review review)
        {
            _db.Reviews.Add(review);
            _db.SaveChanges();
        }
    }
}
