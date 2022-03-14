using System;
using System.Collections.Generic;

#nullable disable

namespace CompanyAppAPI.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DpId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
