using System;
using System.Collections.Generic;

namespace veggie_app.Models;

public partial class Person
{
    public int IdPerson { get; set; }

    public int IdUser { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
