using EllieData.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EllieData
{
    public class EllieContext:DbContext
    {
        public EllieContext(DbContextOptions options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void  OnModelCreating(ModelBuilder buider)
        {
            buider.Entity<Category>().HasMany(p => p.ChildCategories).WithOne(p => p.ParentCategory).HasForeignKey(p => p.ParentCategoryId);
        }
    }
}
