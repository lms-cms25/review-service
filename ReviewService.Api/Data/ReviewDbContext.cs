using Microsoft.EntityFrameworkCore;
using ReviewService.Api.Models;


namespace ReviewService.Api.Data
{
    public class ReviewDbContext : DbContext
    {
        public ReviewDbContext(DbContextOptions<ReviewDbContext> options) : base(options)
        {
        }
        public DbSet<Review> Reviews { get; set; } = null!;
    
    }
}
