using System;
using System.Collections.Generic;

namespace veggie_app.Models;

public partial class Session
{
    public int IdSession { get; set; }

    public int IdUser { get; set; }

    public string Token { get; set; } = null!;

    public DateTime ExpiresAt { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
