using Reviews.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reviews.API.Repository
{
    public interface IReviewRepository
    {
        bool InsertReview(Reviewdetails review);
        Task<List<Reviewdetails>> GetProductReviews(string productName);
    }
}
