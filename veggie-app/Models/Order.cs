using System;
using System.Collections.Generic;

namespace veggie_app.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdUser { get; set; }

    public DateTime Date { get; set; }

    public decimal Total { get; set; }

    public string ShippingAddress { get; set; } = null!;

    public string ShippingCity { get; set; } = null!;

    public string ShippingState { get; set; } = null!;

    public string ShippingCountry { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<OrderProduct> OrderProducts { get; } = new List<OrderProduct>();
}
