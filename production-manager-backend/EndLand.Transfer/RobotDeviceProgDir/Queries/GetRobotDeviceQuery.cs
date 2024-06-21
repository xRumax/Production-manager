using EndLand.Transfer.RobotDevicesProgDir.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.RobotDevicesProgDir.Queries
{
    public class GetRobotDeviceQuery : IRequest<RobotDeviceDto>
    {
        public int Id { get; set; }
    }
}
