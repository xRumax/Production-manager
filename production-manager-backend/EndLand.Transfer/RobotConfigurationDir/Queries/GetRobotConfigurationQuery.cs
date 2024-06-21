using EndLand.Transfer.RobotConfigurationDir.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.RobotConfigurationDir.Queries
{
    public class GetRobotConfigurationQuery : IRequest<RobotConfigurationDto>
    {
        public int Id { get; set; }
    }
}
