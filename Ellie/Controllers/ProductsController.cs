using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EllieData;
using EllieData.Models;
using Ellie.Models.Product;

namespace Ellie.Controllers
{
    public class ProductsController : Controller
    {
        private IProduct _context;
        public ProductsController(IProduct context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(int? category)
        {
            var products = default(IEnumerable<Product>);
            var productmodel = default(IEnumerable<ProductModel>);
            var productsmodel = new ProductsModel();
            productsmodel.Products = productmodel;
            if (category != null)
            {
                if (_context.GetParent(category))
                {
                    products = _context.getProducts(category);
                    if (products.Count() > 0)
                    {
                        productmodel = products.Select(x => new ProductModel()
                        {
                            Id = x.Id,
                            ProductName = x.ProductName,
                            CategoryId = x.CategoryId
                        });
                        productsmodel.Products = productmodel;
                    }
                  
                    return View(productsmodel);

                }
                else
                {
                    var subcats = _context.getCategories(category ?? 0);
                    if (subcats.Count() > 0)
                    {
                        var models = new List<Product>();
                        for (int i = 0; i < subcats.Count(); i++)
                        {
                            var element = subcats.ToList()[i];
                            var ola = _context.getProducts(element.Id);
                            if (ola.Count() > 0)
                            {
                                models.Add(ola.ToList()[0]);
                            }
                           
                        }
                        if (models.Count() > 0)
                        {
                            productmodel = models.Select(x => new ProductModel()
                            {
                                Id = x.Id,
                                ProductName = x.ProductName,
                                CategoryId = x.CategoryId
                            });

                            productsmodel.Products = productmodel;
                        }
                       
                        return View(productsmodel);
                    }
                    else
                    {
                        return View(productsmodel);
                    }
                }
            }
            else
            {
                products = _context.getAllProducts();
                if (products.Count() > 0)
                {
                    productmodel = products.Select(x => new ProductModel()
                    {
                        Id = x.Id,
                        ProductName = x.ProductName,
                        CategoryId = x.CategoryId
                    });
                    productsmodel = new ProductsModel { Products = productmodel };
                }
           
                return View(productsmodel);
            }

        }





        public async Task<IActionResult> Product(int id)
        {

            var product = _context.GetProduct(id);
            var productmodel = new ProductModel { Id = product.Id, ProductName = product.ProductName };
            return View(productmodel);
        }

    }
}

   
 

