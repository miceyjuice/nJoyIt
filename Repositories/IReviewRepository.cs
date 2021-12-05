using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nJoyIt.Models;

namespace nJoyIt.Repositories
{
    public interface IReviewRepository
    {
        IQueryable<Review> GetReviewsByBookId(int bookId);
        void AddReview(Review review);
    }
}
