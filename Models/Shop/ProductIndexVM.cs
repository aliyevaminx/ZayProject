﻿using ZayProject.Entities;

namespace ZayProject.Models.Shop;

public class ProductIndexVM
{
    public List<ProductCategory> ProductCategories { get; set; }
    public List<Product> Products { get; set; }
}
