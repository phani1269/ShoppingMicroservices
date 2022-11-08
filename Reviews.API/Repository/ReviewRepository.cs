using Microsoft.EntityFrameworkCore;
using Reviews.API.Context;
using Reviews.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reviews.API.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ReviewContext _reviewContext;

        public ReviewRepository(ReviewContext reviewContext)
        {
            _reviewContext = reviewContext;
        }

        public async Task<List<Reviewdetails>> GetProductReviews(string productName)
        {
            var reviewList = await _reviewContext.reviewdetails.Where(x => x.ProductName == productName).ToListAsync();
            return reviewList;
        }

        public bool InsertReview(Reviewdetails review)
        {
            review = new Reviewdetails
            {
                CreatedAt = DateTime.UtcNow.ToString("dd/MMMM/yyyy hh:mm:ss"),
                ProductName = review.ProductName,
                UserName = review.UserName,
                Value = review.Value
            };
            _reviewContext.reviewdetails.Add(review);
            _reviewContext.SaveChanges();
            return true;
        }
    }
}
