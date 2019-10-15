using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ellie.Models
{


    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }


        public int CategoryId { get; set; }
    }

    public class ProductsModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
    }
}
