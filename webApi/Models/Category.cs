using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using webApi.CustomOps.CustomValidator;

namespace webApi.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Required(ErrorMessage = "Category Id is Raquired")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name is Raquired")]
        public string CategoryName { get; set; } = null!;
        [Required(ErrorMessage = "Base Price is Raquired")]
        [NumericNoNegtive(ErrorMessage ="Negative Price is not allowed")]
        public decimal BasePrice { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
