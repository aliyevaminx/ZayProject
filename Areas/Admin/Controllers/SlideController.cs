using Microsoft.AspNetCore.Mvc;
using ZayProject.Areas.Admin.Models.Slide;
using ZayProject.Data;
using ZayProject.Entities;

namespace ZayProject.Areas.Admin.Controllers;

[Area("Admin")]
public class SlideController : Controller
{
    private readonly AppDbContext _context;

    public SlideController(AppDbContext context)
    {
        _context = context;
    }

    #region List

    public IActionResult Index()
    {
        var model = new SlideIndexVM
        {
            Slides = _context.Slides.ToList()
        };

        return View(model);
    }

    #endregion

    #region Create

    [HttpGet] 
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(SlideCreateVM model) 
    {
        if (!ModelState.IsValid) return View(model);

        var slide = new Slide
        {
            Title = model.Title,
            MiniTitle = model.MiniTitle,
            Description = model.Description,
            PhotoPath = model.PhotoPath,
            CreatedAt = DateTime.Now
        };

        _context.Slides.Add(slide);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Update

    [HttpGet]
    public IActionResult Update(int id)
    {
        var slide = _context.Slides.Find(id);
        if (slide is null) return NotFound();

        var model = new SlideUpdateVM
        {
            Title = slide.Title,
            MiniTitle = slide.MiniTitle,
            Description = slide.Description,
            PhotoPath = slide.PhotoPath
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Update(int id, SlideUpdateVM model)
    {
        if (!ModelState.IsValid) return View(model);

        var slide = _context.Slides.Find(id);
        if (slide is null) return NotFound();

        slide.Title = model.Title;
        slide.MiniTitle = model.MiniTitle;
        slide.Description = model.Description;
        slide.PhotoPath = model.PhotoPath;
        slide.ModifiedAt = DateTime.Now;

        _context.Slides.Update(slide);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Delete

    [HttpPost]
    public IActionResult Delete(int id) 
    {
        var slide = _context.Slides.Find(id);
        if (slide is null) return NotFound();

        _context.Slides.Remove(slide);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region SetActive
    [HttpPost]
    public IActionResult SetActive(int id)
    {
        var slides = _context.Slides.ToList();
        foreach (var slide in slides)
            slide.IsActive = false;

        var selectedSlide = _context.Slides.Find(id);
        if (selectedSlide is null) return NotFound();

        selectedSlide.IsActive = true;  

        _context.Slides.Update(selectedSlide);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    #endregion
}
