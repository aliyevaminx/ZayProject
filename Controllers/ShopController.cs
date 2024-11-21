using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZayProject.Data;
using ZayProject.Models.Shop;

namespace ZayProject.Controllers;

public class ShopController : Controller
{
    private readonly AppDbContext _context;

    public ShopController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var model = new ProductIndexVM
        {
            ProductCategories = _context.ProductCategories.Include(p => p.Products).ToList(),
            Products = _context.Products.ToList()
        };

        return View(model); 
    }

    public IActionResult Details(int id)
    {
        return View();
    }
}
