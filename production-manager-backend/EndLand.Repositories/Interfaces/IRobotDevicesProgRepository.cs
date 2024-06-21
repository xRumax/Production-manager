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
    public interface IRobotDeviceProgRepository
    {
        Task<PaginatedList<RobotDevicesProgListDto>> ListAsync(ListRobotDevicesProgQuery listAsyncQuery);
        Task<RobotDeviceDto> GetAsync(GetRobotDeviceQuery query);
    }
}
