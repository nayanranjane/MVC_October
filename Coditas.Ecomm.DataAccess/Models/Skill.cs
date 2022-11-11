using System;
using System.Collections.Generic;

namespace Coditas.Ecomm.DataAccess.Models
{
    public partial class Skill
    {
        public int ProjectId { get; set; }
        public string? Experience { get; set; }
        public int? EmpNo { get; set; }

        public virtual Employee? EmpNoNavigation { get; set; }
    }
}
