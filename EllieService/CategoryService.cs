using System;
using System.Collections.Generic;
using EllieData;
using EllieData.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EllieService
{
    public class CategoryService : ICategory
    {
        private EllieContext _context;

        public CategoryService(EllieContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> getCategories()
        {
            var cat = _context.Categories.Where(x => x.ParentCategoryId == null).ToList();
            for (int i = 0; i < cat.Count(); i++)
            {
                var element = cat[i];
                element.ChildCategories = _context.Categories.Where(x=>x.ParentCategoryId==element.Id).ToList();
            }
            return cat;
        }

   

        public IEnumerable<Category> getCategories(int Id)
        {
            return _context.Categories.Where(x => x.ParentCategoryId == Id).ToList();
        }



        public IEnumerable<Product> getProducts(int? CategoryId)
        {
            if (CategoryId != 0)
            {
                var products = _context.Products.Where(x => x.CategoryId == CategoryId).ToList();
                return products;
            }
            else
            {
                var products = _context.Products.ToList();
                return products;
            }
        }
    }
}
