using System;
using System.Collections.Generic;

namespace Klinika.Models.DatabaseModels;

public partial class PatientZaklyuchenie
{
    public int? IdPatt { get; set; }

    public int? IdZakl { get; set; }

    public virtual Patient? IdPattNavigation { get; set; }

    public virtual Zaklyuchenie? IdZaklNavigation { get; set; }
}
