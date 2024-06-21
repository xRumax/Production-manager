using EndLand.Transfer.ProjectsDir.Data;
using EndLand.Transfer.ProjectsDir.Queries;
using EndLand.Transfer.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndLand.Data.Models;
using EndLand.Transfer.RobotWaterMeterDir.Data;
using EndLand.Transfer.RobotWaterMeterDir.Queries;
using EndLand.Transfer.RobotDeviceProgDir.Data;
using EndLand.Transfer.RobotDeviceProgDir.Queries;

namespace EndLand.Repositories.Interfaces
{
    public interface IRobotWaterMeterRepository
    {
        Task<PaginatedList<RobotWaterMeterListDto>> ListAsync(ListRobotWaterMeterQuery listAsyncQuery);
        Task<RobotWaterMeterDto> GetAsync(GetRobotWaterMeterQuery query);
    }
}
