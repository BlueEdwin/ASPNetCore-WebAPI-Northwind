using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Northwind.Dtos
{
    public class OrderWithCustomerInfoDto
    {
        public string? Country { get; set; }
        public string? City { get; set; }
        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CompanyName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string? ContactName { get; set; }
    }
}
