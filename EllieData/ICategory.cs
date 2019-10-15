using EllieData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EllieData
{
    public interface ICategory
    {
        IEnumerable<Category> getCategories();

        IEnumerable<Category> getCategories(int Id);

        IEnumerable<Product> getProducts(int? CategoryId);
    }
}
