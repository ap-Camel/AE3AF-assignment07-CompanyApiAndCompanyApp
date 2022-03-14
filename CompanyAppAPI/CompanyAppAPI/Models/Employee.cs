using System;
using System.Collections.Generic;

#nullable disable

namespace CompanyAppAPI.Models
{
    public partial class Employee
    {
        public int EmId { get; set; }
        public string Name { get; set; }
        public decimal? Salary { get; set; }
        public int? DpId { get; set; }

        public virtual Department Dp { get; set; }
    }
}
