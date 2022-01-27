using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nJoyIt.Models;

namespace nJoyIt.Repositories
{
    public interface IReviewRepository: IRepository<Review>
    {
        IQueryable<Review> GetReviewsByBookId(int bookId);
    }
}
