using System;
using System.Collections.Generic;

namespace Common.Northwind.Entities;

public partial class Order_Subtotal
{
    public int OrderID { get; set; }

    public decimal? Subtotal { get; set; }
}
