using EllieData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EllieData
{
    public interface IProduct
    {
        IEnumerable<Product> getProducts(int CategoryId);
        IEnumerable<Product> getAllProducts();
    }
}
