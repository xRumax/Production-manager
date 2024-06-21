using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.RobotDeviceProgDir.Data
{
    public class RobotDevicesProgListDto
    {
        public int Id { get; set; }
        public string? Imei { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }   
    }
}
