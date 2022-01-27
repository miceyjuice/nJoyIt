using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            return _db.Reviews.Include("User").Where(r => r.Book.Id == bookId);
        }

        public void Add(Review review)
        {
            _db.Reviews.Add(review);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var review = _db.Reviews.SingleOrDefault(review => review.Id == id);
            _db.Remove(review);
            _db.SaveChanges();
        }

        public IQueryable<Review> FindAll() => _db.Reviews;

        public Review FindById(int id) => _db.Reviews.SingleOrDefault(review => review.Id == id);
    }
}
