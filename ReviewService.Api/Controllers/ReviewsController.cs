using Microsoft.AspNetCore.Mvc;
using ReviewService.Api.Dtos;

namespace ReviewService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly Services.ReviewService _reviewService;

    public ReviewsController(Services.ReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllReviews()
    {
        var reviews = await _reviewService.GetAllReviewsAsync();
        return Ok(reviews);
    }

    [HttpPost]
    public async Task<IActionResult> CreateReview(CreateReviewDto dto)
    {
        var review = await _reviewService.CreateReviewAsync(dto);
        return CreatedAtAction(nameof(GetAllReviews), new { id = review.Id }, review);
    }

    // Hämta review med id
    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewDto>> GetReviewById(int id)
    {
        var review = await _reviewService.GetReviewByIdAsync(id);

        if (review == null)
        {
            return NotFound();
        }

        return Ok(review);
    }

    // Ta bort review med id
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
        var deleted = await _reviewService.DeleteReviewAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
    // Uppdatera review
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReview(int id, UpdateReviewDto dto)
    {
        var updatedReview = await _reviewService.UpdateReviewAsync(id, dto);

        if (updatedReview == null)
        {
            return NotFound();
        }

        return Ok(updatedReview);
    }
}