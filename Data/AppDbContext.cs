﻿using Microsoft.EntityFrameworkCore;
using ZayProject.Entities;

namespace ZayProject.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Slide> Slides { get; set; }

}
