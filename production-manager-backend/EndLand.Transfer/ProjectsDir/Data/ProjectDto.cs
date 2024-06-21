using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.ProjectsDir.Data
{
    public class ProjectDto
    {
        public int? Id { get; set; }

        public string Name { get; set; } = null!;

        public float WaterMeterConstFlowRate { get; set; }

        public int WaterMeterDiameter { get; set; }

        public int WaterLeakAlarmCounterThreshold { get; set; }

        public int WaterLeakAlarmLowerThreshold { get; set; }

        public int WaterLeakAlarmInterval { get; set; }

        public int SuddenWaterLossAlarmCounterThreshold { get; set; }

        public int SuddenWaterLossAlarmLowerThreshold { get; set; }

        public int SuddenWaterLossAlarmInterval { get; set; }

        public int WaterMeterMeasuringRange { get; set; }
    }
}
