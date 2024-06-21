using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.RobotWaterMeterDir.Data
{
    public class RobotWaterMeterListDto
    {
        public int Id { get; set; }

        public string SerialNumber { get; set; } = null!;

        public string Purpose { get; set; } = null!;

        public string? Owner { get; set; }
    }
}
