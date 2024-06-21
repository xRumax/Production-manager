using EndLand.Repositories.Handlers;
using EndLand.Transfer.ProjectsDir.Data;
using EndLand.Transfer.ProjectsDir.Queries;
using EndLand.Transfer.RobotConfigurationDir.Data;
using EndLand.Transfer.RobotConfigurationDir.Queries;
using EndLand.Transfer.RobotDeviceProgDir.Data;
using EndLand.Transfer.RobotDeviceProgDir.Queries;
using EndLand.Transfer.RobotDevicesProgDir.Data;
using EndLand.Transfer.RobotDevicesProgDir.Queries;
using EndLand.Transfer.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Interfaces
{
    public interface IRobotConfigurationRepository
    {
        Task<PaginatedList<RobotConfigurationDto>> ListAsync(ListRobotConfigurationQuery query);
        Task<RobotConfigurationDto> GetAsync(GetRobotConfigurationQuery query);
    }
}
