using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.ProjectsDir.Data
{
    public class ProjectListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public float WaterMeterConstFlowRate { get; set; }
        public int WaterMeterDiameter { get; set; }
    }
}
