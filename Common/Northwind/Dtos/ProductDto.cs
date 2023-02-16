using Common.Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Northwind.Dtos
{
    public class ProductDto
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; } = null!;

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        public string? QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        public virtual Category? Category { get; set; }

        public virtual ICollection<Order_Detail> Order_Details { get; } = new List<Order_Detail>();

        public virtual Supplier? Supplier { get; set; }
    }
}
