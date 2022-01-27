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
    public class ReviewRepositoryTests
    {
        private ApplicationDbContext _ctx;
        public ReviewRepositoryTests()
        {
            DbContextOptionsBuilder<nJoyIt.Data.ApplicationDbContext> dbOptions =
                new DbContextOptionsBuilder<nJoyIt.Data.ApplicationDbContext>();
            dbOptions.UseInMemoryDatabase(Guid.NewGuid().ToString());
            _ctx = new ApplicationDbContext(dbOptions.Options);
        }

        [Test]
        public void ShouldCreateReview()
        {
            // Arrange
            _ctx.Reviews.RemoveRange(_ctx.Reviews);
            IReviewRepository reviewRepository = new EFReviewRepository(_ctx);
            Review review = new Review
            {
                ReviewContent = "test"
            };

            // Act
            reviewRepository.Add(review);

            // Assert
            Assert.AreEqual(_ctx.Reviews.ToList().Count, 1);
        }

        [Test]
        public void ShouldGetAllReviews()
        {
            // Arrange
            _ctx.Reviews.RemoveRange(_ctx.Reviews);
            IReviewRepository reviewRepository = new EFReviewRepository(_ctx);
            Review review = new Review
            {
                ReviewContent = "test"
            };

            // Act
            _ctx.Reviews.Add(review);
            _ctx.SaveChanges();
            var reviews = reviewRepository.FindAll();

            // Assert
            Assert.AreEqual(1,reviews.ToList().Count);
        }
        [Test]
        public void ShouldDeleteReviewById()
        {
            // Arrange
            _ctx.Reviews.RemoveRange(_ctx.Reviews);
            IReviewRepository reviewRepository = new EFReviewRepository(_ctx);
            Review review = new Review
            {
                ReviewContent = "test"
            };

            // Act
            var createdReview = _ctx.Reviews.Add(review);
            _ctx.SaveChanges();
            reviewRepository.Delete(createdReview.Entity.Id);

            // Assert
            Assert.AreEqual(0,_ctx.Reviews.ToList().Count);
        }
    }
}
