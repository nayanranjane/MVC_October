﻿using System;
using System.Collections.Generic;

namespace Coditas.Ecomm.DataAccess.Models
{
    public partial class MyTable
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int? Gender { get; set; }
    }
}
