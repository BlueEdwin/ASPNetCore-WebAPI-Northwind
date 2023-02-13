using System;
using System.Collections.Generic;

namespace Common.Northwind.Entities;

public partial class Product_Sales_for_1997
{
    public string CategoryName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal? ProductSales { get; set; }
}
