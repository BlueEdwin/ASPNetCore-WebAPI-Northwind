namespace WebApi.Controllers.Northwind
{
    public class OrderWithCustomerInfoViewModel
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
