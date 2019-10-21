using Ellie.Models;
using EllieData;
using EllieData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ellie.Controllers
{
    public class CategoryController : Controller
    {
        private ICategory _context;
        public CategoryController(ICategory context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var models = _context.getCategories();

            var CategoryModels = models.Select(x => new CategoryModel()
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                ParentCategoryId = x.ParentCategoryId,
                ChildCategories = x.ChildCategories.Select(p => new CategoryModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    ParentCategoryId = p.ParentCategoryId,
                })

            });
            var newmodel = new CategoriesModel { categories = CategoryModels };
            ViewBag.list = newmodel;
            return PartialView("Index");
        }

        public IActionResult PartialCat(int Id)
        {
            var models = _context.getCategories(Id);

            var CategoryModels = models.Select(x => new CategoryModel()
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                ParentCategoryId = x.ParentCategoryId
            });
            var newmodel = new CategoriesModel { categories = CategoryModels };
            ViewBag.list = newmodel;
            return PartialView("PartialCat");
        }





        //    public IActionResult PartialProduct(int CategoryId)
        //    {
        //        var subcats = _context.getCategories(CategoryId);


        //        var models = new List<Product>();
        //        for (int i = 0; i < subcats.Count(); i++)
        //        {
        //            var element = subcats.ToList()[i];
        //            var ola = _context.getProducts(element.Id);
        //            models.Add(ola.ToList()[0]);
        //        }

        //        //var models = _context.getProducts(CategoryId);

        //        var ProductModels = models.Select(x => new ProductModel()
        //        {
        //            Id = x.Id,
        //            ProductName = x.ProductName,
        //            CategoryId=x.CategoryId
        //        });
        //        var newmodel = new ProductsModel { Products = ProductModels };
        //        ViewBag.list = newmodel;
        //        return PartialView("PartialProduct");
        //    }
        //}
    }
}
