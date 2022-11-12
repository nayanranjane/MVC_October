using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Coditas.Ecomm.Entities;

namespace Coditas.Ecomm.Entities
{
    public partial class Product
    {
        public int? ProductUniqueId { get; set; }
        [Required(ErrorMessage = "Product Name is Required ")]
        public string ProductName { get; set; } = null!;
        [Required(ErrorMessage = "Product Description is Required ")]
        public string Descrition { get; set; } = null!;
        [Required(ErrorMessage = "Price is Required ")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Category Id is Required ")]
        public int? CategoryId { get; set; }
        [Required(ErrorMessage = "ManufacturerID is Required ")]

        public int? ManufacturerID { get; set; }

        public virtual Category? Category { get; set; } = null!;
        //public virtual Manufacturer Manufacturer { get; set; } = 1;
    }
}
