using System;
using System.Collections.Generic;

namespace webApi.Models
{
    public partial class Product
    {
        public int ProductUniqueId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Descrition { get; set; } = null!;
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }

      //  public virtual Category? Category { get; set; }
    }
}
