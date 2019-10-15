using System;
using System.Collections.Generic;
using System.Text;

namespace EllieData.Models
{
    public class Category
    {
        public Category()
        {
            ChildCategories = new HashSet<Category>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl{get;set;}

        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
