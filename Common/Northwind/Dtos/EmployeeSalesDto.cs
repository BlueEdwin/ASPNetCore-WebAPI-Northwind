using Common.Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Northwind.Dtos
{
    public class EmployeeSalesDto
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;
        public string? City { get; set; }
        public virtual ICollection<Order> Orders { get; } = new List<Order>();
        public  int OrderNumber { get; set; }
    }
}
