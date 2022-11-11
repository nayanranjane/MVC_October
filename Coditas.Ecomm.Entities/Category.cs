using System;
using System.Collections.Generic;
using Coditas.Ecomm.Entities;
using System.ComponentModel.DataAnnotations;

namespace Coditas.Ecomm.Entities
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            //SubCategories = new HashSet<SubCategory>();
        }
        [Required(ErrorMessage ="Category Id is Required ")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name is Required ")]
        public string CategoryName { get; set; } = null!;
        [Required(ErrorMessage = "BasePrice is Required ")]
        public decimal BasePrice { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
        //public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
