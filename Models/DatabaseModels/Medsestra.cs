using System;
using System.Collections.Generic;

namespace Klinika.Models.DatabaseModels;

public partial class Medsestra
{
    public string Fio { get; set; } = null!;

    public long? NumberTelephone { get; set; }

    public string? Password { get; set; }

    public int? TabNum { get; set; }

    public virtual Vrach? TabNumNavigation { get; set; }
}
