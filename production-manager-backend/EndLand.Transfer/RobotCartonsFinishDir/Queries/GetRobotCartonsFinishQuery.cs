using EndLand.Transfer.RobotCartonsFinishDir.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.RobotCartonsFinishDir.Queries
{
    public class GetRobotCartonsFinishQuery :IRequest<RobotCartonsFinishDto>
    {
        public int Id { get; set; }
    }
}
