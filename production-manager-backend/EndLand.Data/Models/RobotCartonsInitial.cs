using System;
using System.Collections.Generic;

namespace EndLand.Data.Models;

public partial class RobotCartonsInitial
{
    public int Id { get; set; }

    public DateTime AdmissionDate { get; set; }

    public string Purpose { get; set; } = null!;

    public int Dn { get; set; }

    public int Quantity { get; set; }

    public string? Owner { get; set; }
}
