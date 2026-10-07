using System;
using System.Collections.Generic;

namespace Klinika.Models.DatabaseModels;

public partial class Patient
{
    public int IdPatient { get; set; }

    public string? Password { get; set; }

    public string? PassportDannye { get; set; }
}
