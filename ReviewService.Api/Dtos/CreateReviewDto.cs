namespace ReviewService.Api.Dtos
{
    public class CreateReviewDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
        public int CourseId { get; set; }
    }
}
