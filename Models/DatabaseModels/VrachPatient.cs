using System;
using System.Collections.Generic;

namespace Klinika.Models.DatabaseModels;

public partial class VrachPatient
{
    public int? IdPat { get; set; }

    public int? TabbN { get; set; }

    public virtual Patient? IdPatNavigation { get; set; }

    public virtual Vrach? TabbNNavigation { get; set; }
}
