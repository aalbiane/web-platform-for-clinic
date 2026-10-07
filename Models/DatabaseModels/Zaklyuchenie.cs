using System;
using System.Collections.Generic;

namespace Klinika.Models.DatabaseModels;

public partial class Zaklyuchenie
{
    public int IdZaklyuchenie { get; set; }

    public string? SposobLechenie { get; set; }

    public string? Diagnoz { get; set; }

    public string? FioPatient { get; set; }
}
