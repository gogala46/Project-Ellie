using EllieData;
using EllieData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EllieService
{
    public class ProductService : IProduct
    {
        private EllieContext _context;

        public ProductService(EllieContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> getAllProducts()
        {
            var products = _context.Products.ToList();
            return products;
        }

        public IEnumerable<Product> getProducts(int? CategoryId)
        {
            var products = _context.Products.Where(x => x.CategoryId == CategoryId).ToList();
            return products;
            
        }

        public IEnumerable<Category> getCategories(int Id)
        {
            return _context.Categories.Where(x => x.ParentCategoryId == Id).ToList();
        }

       
        public bool GetParent(int? Id)
        {
            var parent = _context.Categories.Where(x => x.Id == Id).Select(z => z.ParentCategoryId).FirstOrDefault();
            if (parent != null)
                return true;
            return false;
        }

        public Product GetProduct(int Id)
        {
            return _context.Products.Where(x => x.Id == Id).FirstOrDefault();
        }

        
    }
}
