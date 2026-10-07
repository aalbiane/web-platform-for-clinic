using System;
using System.Collections.Generic;

namespace Klinika.Models.DatabaseModels;

public partial class Vrach
{
    public int TabN { get; set; }

    public string? Speciality { get; set; }

    public string? Fio { get; set; }

    public long? NumberTelephone { get; set; }

    public string? Password { get; set; }

    public int? NLklinik { get; set; }

    public virtual ICollection<Medsestra> Medsestras { get; set; } = new List<Medsestra>();

    public virtual Klinika? NLklinikNavigation { get; set; }
}
