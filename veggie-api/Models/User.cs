using System;
using System.Collections.Generic;

namespace veggie_app.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? TypeUser { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual ICollection<Person> People { get; } = new List<Person>();

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual ICollection<Session> Sessions { get; } = new List<Session>();
}
