using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reviews.API.Models;
using Reviews.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reviews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewsController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        [Route("GetProductReviewDetails/{productName}")]
        public async Task<ActionResult> GetReviewDetails(string productName)
        {
            var result = await _reviewRepository.GetProductReviews(productName);
            return Ok(result);
        }
        [HttpPost]
        [Route("PostReviews")]
        public  ActionResult PostReviews(Reviewdetails review)
        {
            var result =  _reviewRepository.InsertReview(review);
            return Ok(result);
        }
    }
}
