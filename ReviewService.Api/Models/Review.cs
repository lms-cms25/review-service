namespace ReviewService.Api.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
        public int CourseId { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}
