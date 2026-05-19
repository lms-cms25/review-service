using System.ComponentModel.DataAnnotations;

namespace ReviewService.Api.Dtos;

public class UpdateReviewDto
{
    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [MinLength(3)]
    public string Comment { get; set; } = string.Empty;

    [Range(1, 5)]
    public int Rating { get; set; }

    [Range(1, int.MaxValue)]
    public int CourseId { get; set; }
}