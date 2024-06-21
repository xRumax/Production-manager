using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.RobotDevicesProgDir.Data
{
    public class RobotDeviceDto
    {
        public int Id { get; set; }

        public string Imei { get; set; } = null!;

        public DateTime StartedAt { get; set; }

        public int FirmwareVer { get; set; }

        public string Device { get; set; } = null!;

        public DateTime FinishedAt { get; set; }
    }
}