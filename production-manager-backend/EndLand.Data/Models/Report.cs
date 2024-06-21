using System;
using System.Collections.Generic;

namespace EndLand.Data.Models;

public partial class Report
{
    public string Imei { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string ProjectName { get; set; } = null!;

    public string OrderNumber { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string? Ccid { get; set; }

    public string SerialNumber { get; set; } = null!;

    public int FirmwareVersion { get; set; }

    public int Volume { get; set; }

    public int EsiThresholdChannel0 { get; set; }

    public int EsiThresholdChannel1 { get; set; }

    public int EsiAfe1BaseChannel0 { get; set; }

    public int EsiAfe1BaseChannel1 { get; set; }

    public int EsiAfe2BaseChannel0 { get; set; }

    public int EsiAfe2BaseChannel1 { get; set; }

    public double WaterMeterConstFlowRate { get; set; }

    public int WaterMeterDiameter { get; set; }

    public int WaterLeakAlarmCounterThreshold { get; set; }

    public int WaterLeakAlarmLowerThreshold { get; set; }

    public int WaterLeakAlarmInterval { get; set; }

    public int SuddenWaterLossAlarmCounterThreshold { get; set; }

    public int SuddenWaterLossAlarmLowerThreshold { get; set; }

    public int SuddenWaterLossAlarmInterval { get; set; }

    public DateTime StartedAt { get; set; }

    public DateTime FinishedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public int EsiThresholdChannel2 { get; set; }

    public int EsiAfe1BaseChannel2 { get; set; }

    public int EsiAfe2BaseChannel2 { get; set; }
}
