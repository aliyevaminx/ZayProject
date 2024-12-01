using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZayProject.Data;
using ZayProject.Entities;

namespace ZayProject.ViewComponents;

public class OurPurposeViewComponent : ViewComponent
{
    private readonly AppDbContext _context;

    public OurPurposeViewComponent(AppDbContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var ourPurpose = _context.OurPurposes.Include(op => op.Brands).FirstOrDefault();
       return View(ourPurpose);
    }
}
