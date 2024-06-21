﻿using EndLand.Transfer.RobotConfigurationDir.Data;
using EndLand.Transfer.RobotDeviceProgDir.Data;
using EndLand.Transfer.Shared.Data;
using EndLand.Transfer.Shared.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.RobotConfigurationDir.Queries
{
    public class ListRobotConfigurationQuery : ListQuery, IRequest<PaginatedList<RobotConfigurationDto>>
    {
    }
}