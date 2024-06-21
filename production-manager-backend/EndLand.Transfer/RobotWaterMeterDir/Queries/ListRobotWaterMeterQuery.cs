using EndLand.Transfer.RobotWaterMeterDir.Data;
using EndLand.Transfer.Shared.Data;
using EndLand.Transfer.Shared.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.RobotWaterMeterDir.Queries
{
    public class ListRobotWaterMeterQuery : ListQuery,IRequest<PaginatedList<RobotWaterMeterListDto>>
    {
    }
}
