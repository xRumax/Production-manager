using System;
using System.Collections.Generic;

namespace EndLand.Data.Models;

public partial class RobotCartonsFinish
{
    public int Id { get; set; }

    public DateTime AdmissionDate { get; set; }

    public string Purpose { get; set; } = null!;

    public int Dn { get; set; }

    public int Quantity { get; set; }

    public double MinPixelCount { get; set; }

    public double MaxPixelCount { get; set; }

    public double Q3 { get; set; }

    public bool TestResult { get; set; }

    public string? Owner { get; set; }

    public bool? FullCarton { get; set; }
}
