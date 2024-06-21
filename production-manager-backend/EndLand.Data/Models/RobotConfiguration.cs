using System;
using System.Collections.Generic;

namespace EndLand.Data.Models;

public partial class RobotConfiguration
{
    public int PixelTreshold { get; set; }

    public int Id { get; set; }

    public int QuantityWaterMetersInCarton { get; set; }
}
