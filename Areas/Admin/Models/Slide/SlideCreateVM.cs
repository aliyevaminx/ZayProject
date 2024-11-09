using System.ComponentModel.DataAnnotations;

namespace ZayProject.Areas.Admin.Models.Slide;

public class SlideCreateVM
{
    [Required(ErrorMessage = "Title is required")]
    [MinLength(5, ErrorMessage = "Must be at least 5 characters")]
    public string Title { get; set; }
    public string MiniTitle { get; set; }
    public string Description { get; set; }
    public string PhotoPath { get; set; }
}
