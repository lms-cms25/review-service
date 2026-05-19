using Microsoft.EntityFrameworkCore;
using ReviewService.Api.Data;
using ReviewService.Api.Dtos;
using ReviewService.Api.Models;

namespace ReviewService.Api.Services;

public class ReviewService
{
    private readonly ReviewDbContext _context;

    public ReviewService(ReviewDbContext context)
    {
        _context = context;
    }
    //Hämta alla reviews
    public async Task<List<ReviewDto>> GetAllReviewsAsync()
    {
        return await _context.Reviews
            .Select(r => new ReviewDto
            {
                Id = r.Id,
                UserName = r.UserName,
                Comment = r.Comment,
                Rating = r.Rating,
                CourseId = r.CourseId,
                CreateAt = r.CreateAt
            })
            .ToListAsync();
    }

    // Hämta en review med id
    public async Task<ReviewDto?> GetReviewByIdAsync(int id)
    {
        var review = await _context.Reviews
            .FirstOrDefaultAsync(r => r.Id == id);

        if (review == null)
        {
            return null;
        }

        return new ReviewDto
        {
            Id = review.Id,
            UserName = review.UserName,
            Comment = review.Comment,
            Rating = review.Rating,
            CourseId = review.CourseId,
            CreateAt = review.CreateAt
        };
    }


    //skapa ny review
    public async Task<ReviewDto> CreateReviewAsync(CreateReviewDto dto)
    {
        var review = new Review
        {
            UserName = dto.UserName,
            Comment = dto.Comment,
            Rating = dto.Rating,
            CourseId = dto.CourseId,
            CreateAt = DateTime.UtcNow
        };
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
        return new ReviewDto
        {
            Id = review.Id,
            UserName = review.UserName,
            Comment = review.Comment,
            Rating = review.Rating,
            CourseId = review.CourseId,
            CreateAt = review.CreateAt
        };
    }
    // Ta bort en review med id
    public async Task<bool> DeleteReviewAsync(int id)
    {
        var review = await _context.Reviews.FindAsync(id);

        if (review == null)
        {
            return false;
        }

        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();

        return true;
    }
    // Uppdatera review
    public async Task<ReviewDto?> UpdateReviewAsync(int id, UpdateReviewDto dto)
    {
        var review = await _context.Reviews.FindAsync(id);

        if (review == null)
        {
            return null;
        }

        review.UserName = dto.UserName;
        review.Comment = dto.Comment;
        review.Rating = dto.Rating;
        review.CourseId = dto.CourseId;

        await _context.SaveChangesAsync();

        return new ReviewDto
        {
            Id = review.Id,
            UserName = review.UserName,
            Comment = review.Comment,
            Rating = review.Rating,
            CourseId = review.CourseId,
            CreateAt = review.CreateAt
        };
    }

}
