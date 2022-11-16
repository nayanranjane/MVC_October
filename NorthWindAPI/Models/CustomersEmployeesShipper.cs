﻿using System;
using System.Collections.Generic;

namespace NorthWindAPI.Models
{
    public partial class CustomersEmployeesShipper
    {
        public int OrderId { get; set; }
        public string? CustomerName { get; set; }
        public string EmployeeName { get; set; } = null!;
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string ShipperName { get; set; } = null!;
        public decimal? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }
    }
}
