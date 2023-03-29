using System;
using System.Collections.Generic;

namespace veggie_app.Models;

public partial class OrderProduct
{
    public int IdOrderProducts { get; set; }

    public int IdOrder { get; set; }

    public int IdProduct { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
