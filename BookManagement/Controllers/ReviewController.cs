using DTO.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public IActionResult addReview([FromBody] CreateReviewDTO createReviewDto)
        {
            if(createReviewDto.rating<1 || createReviewDto.rating > 5)
            {
                return BadRequest("Give valid rating");
            }
            try
            {
                _reviewService.CreateReview(createReviewDto);
            }
            catch(ArgumentException ex) 
            {
                BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
