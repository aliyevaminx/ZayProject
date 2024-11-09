using Microsoft.AspNetCore.Mvc;
using ZayProject.Data;
using ZayProject.Models.Home;

namespace ZayProject.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var model = new SlideIndexVM
        {
            Slides = _context.Slides.ToList()
        };

        return View(model);
    }
}
