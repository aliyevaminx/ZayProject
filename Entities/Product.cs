﻿namespace ZayProject.Entities;

public class Product : BaseEntity
{
    public string Photo { get; set; }
    public string Title { get; set; }
    public string Size { get; set; }
    public decimal Price { get; set; }
    public ProductCategory ProductCategory { get; set; }
    public int ProductCategoryId { get; set; }
}
