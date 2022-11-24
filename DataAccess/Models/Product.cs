using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Manufacturer { get; set; }
        public long? Price { get; set; }
        public string? Seller { get; set; }
        public string? Description { get; set; }
    }
}
