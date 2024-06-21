using EndLand.Transfer.RobotCartonsInitialDir.Data;
using EndLand.Transfer.RobotDeviceProgDir.Data;
using EndLand.Transfer.Shared.Data;
using EndLand.Transfer.Shared.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.RobotCartonsInitialDir.Queries
{
    public class ListRobotCartonsInitialQuery : ListQuery, IRequest<PaginatedList<RobotCartonsInitialListDto>>
    {
    }
}
