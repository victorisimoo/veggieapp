using System;
using System.Collections.Generic;

namespace veggie_app.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int IdCategory { get; set; }

    public int? IdUser { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; } = new List<OrderProduct>();
}
