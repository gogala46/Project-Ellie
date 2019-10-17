using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ellie.Models.Product
{
    public class ProductsModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
        public CategoriesModel Categories { get; set; }
    }
}
