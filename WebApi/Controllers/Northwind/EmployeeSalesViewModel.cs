using Common.Northwind.Entities;

namespace WebApi.Controllers.Northwind
{
    public class EmployeeSalesViewModel
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;
        public string? City { get; set; }
        public virtual ICollection<Order> Orders { get; } = new List<Order>();
        public int OrderNumber { get; set; }
    }
}
