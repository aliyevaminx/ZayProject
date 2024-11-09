using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using ZayProject.Entities;

namespace ZayProject.Areas.Admin.Models.Product;

public class ProductCreateVM
{

    [Required(ErrorMessage = "Title is required")]
	[MinLength(2, ErrorMessage = "Must be at least 2 characters")]
	public string Title { get; set; }

	[Required(ErrorMessage = "Price is required")]
	public decimal Price { get; set; }

    [Required(ErrorMessage = "Size is required")]
    public string Size { get; set; }

    [Required(ErrorMessage = "Image is required")]
	public string PhotoPath { get; set; }

	[Required]
	[Display(Name = "Product Category")]
	public int ProductCategoryId { get; set; }
	public List<SelectListItem>? ProductCategories { get; set; }
}
