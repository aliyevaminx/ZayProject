using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZayProject.Areas.Admin.Models.Product;
using ZayProject.Data;
using ZayProject.Entities;

namespace ZayProject.Areas.Admin.Controllers;


[Area("Admin")]
public class ProductController : Controller
{
    private readonly AppDbContext _context;

   
    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    #region List

    public IActionResult Index() 
    {
        var model = new ProductIndexVM
        {
            Products = _context.Products.Include(p => p.ProductCategory).ToList()
        };

        return View(model);
    }

    #endregion

    #region Create

    [HttpGet]
    public IActionResult Create()
    {
        var model = new ProductCreateVM
        {
            ProductCategories = _context.ProductCategories.Select(pc => new SelectListItem
            {
                Text = pc.Name,
                Value = pc.Id.ToString()
            }).ToList()
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Create(ProductCreateVM model)
    {

        model.ProductCategories = _context.ProductCategories.Select(pc => new SelectListItem
        {
            Text = pc.Name,
            Value = pc.Id.ToString()
        }).ToList();

        if (!ModelState.IsValid) return View(model);

        var product = _context.Products.FirstOrDefault(p => p.Title == model.Title);
        if (product is not null)
        {
            ModelState.AddModelError("Product", "This product has already exists");
			return View(model);
		}

		var productCategory = _context.ProductCategories.Find(model.ProductCategoryId);
        if (productCategory is null)
        {
            ModelState.AddModelError("Category", "This category is not available");
            return View(model);            
        }

        product = new Product
        {
            Title = model.Title,
            PhotoPath = model.PhotoPath,
            Size = model.Size,
            Price = model.Price,
            ProductCategoryId = productCategory.Id
        };

        _context.Products.Add(product);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Update

    [HttpGet]
    public IActionResult Update(int id)
    {
        var product = _context.Products.Find(id);
        if (product is null) return NotFound();

        var model = new ProductUpdateVM
        {
            Title = product.Title,
            PhotoPath = product.PhotoPath,
            Size = product.Size,
            Price = product.Price,
            ProductCategoryId = product.ProductCategoryId,
            ProductCategories = _context.ProductCategories.Select(pc => new SelectListItem
            {
                Text = pc.Name,
                Value = pc.Id.ToString()
            }).ToList()
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Update(int id, ProductUpdateVM model)
    {
        model.ProductCategories = _context.ProductCategories.Select(pc => new SelectListItem
        {
            Text = pc.Name,
            Value = pc.Id.ToString()
        }).ToList();

        var product = _context.Products.Find(id);
        if (product is null) return NotFound();

        var isExist = _context.Products.Any(p => p.Title.ToLower() == model.Title.ToLower() && p.Id != product.Id);
        if (isExist)
        {
            ModelState.AddModelError("Title", "Product has already exists");
            return View(model);
        }

        var productCategory = _context.ProductCategories.Find(model.ProductCategoryId);
        if (productCategory is null) return NotFound();

        product.Title = model.Title;
        product.PhotoPath = model.PhotoPath;
        product.Size = model.Size;
        product.Price = model.Price;
        product.ProductCategoryId = productCategory.Id;
        product.ModifiedAt = DateTime.Now;

        _context.Products.Update(product);
        _context.SaveChanges(); 

        return RedirectToAction(nameof(Index));

    }

    #endregion

    #region Delete
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var product = _context.Products.Find(id);
        if (product is null) return NotFound();

        _context.Products.Remove(product);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    #endregion
}
