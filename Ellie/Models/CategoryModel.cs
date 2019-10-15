using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ellie.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public int? ParentCategoryId { get; set; }
    }
}
