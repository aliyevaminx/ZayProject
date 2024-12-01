using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZayProject.Data;

namespace ZayProject.Controllers;

public class AboutController : Controller
{
    private readonly AppDbContext _context;

    public AboutController(AppDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
