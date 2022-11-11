using System;
using System.Collections.Generic;

namespace Coditas.Ecomm.DataAccess.Models
{
    public partial class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; } = null!;
        public int CategoryId { get; set; }

       // public virtual Category Category { get; set; } = null!;
    }
}
