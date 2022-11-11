using System;
using System.Collections.Generic;

namespace Coditas.Ecomm.DataAccess.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
          //  Products = new HashSet<Product>();
        }

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string ManufacturerAddress { get; set; } = null!;
        public string ManufacturerCity { get; set; } = null!;
        public string ManufacturerState { get; set; } = null!;

      //  public virtual ICollection<Product> Products { get; set; }
    }
}
