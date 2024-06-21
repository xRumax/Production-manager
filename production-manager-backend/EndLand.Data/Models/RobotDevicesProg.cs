using System;
using System.Collections.Generic;

namespace EndLand.Data.Models;

public partial class RobotDevicesProg
{
    public int Id { get; set; }

    public string Imei { get; set; } = null!;

    public DateTime StartedAt { get; set; }

    public int FirmwareVer { get; set; }

    public string Device { get; set; } = null!;

    public DateTime FinishedAt { get; set; }
}
