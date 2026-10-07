using System;
using System.Collections.Generic;

namespace Klinika.Models.DatabaseModels;

public partial class Klinika
{
    public string? Address { get; set; }

    public int NumberKlinik { get; set; }

    public string? NameKlinik { get; set; }

    public virtual ICollection<Vrach> Vraches { get; set; } = new List<Vrach>();
}
