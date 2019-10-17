using System;
using Ellie.Models;
using EllieData;
using EllieData.Models;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ellie.Models.Product;

namespace Ellie.Controllers
{
    public class ProductController : Controller
    {
       
        private IProduct _context;
        private ICategory _context2;

        public ProductController(IProduct context, ICategory context2 )
        {
            _context = context;
            _context2 = context2;
        }

        public IActionResult Index()
        {
            var models = _context.getAllProducts();
            var productmodels = models.Select(z => new ProductModel()
            {
                Id = z.Id,
                ProductName = z.ProductName,
                CategoryId = z.CategoryId
            });
            var products = new ProductsModel { Products = productmodels };
            

            return View(products);
        }



    }
}