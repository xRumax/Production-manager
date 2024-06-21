using EndLand.Transfer.RobotCartonsInitialDir.Data;
using EndLand.Transfer.RobotCartonsInitialDir.Queries;
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
    public interface IRobotCartonsInitialRepository
    {
        Task<PaginatedList<RobotCartonsInitialListDto>> ListAsync(ListRobotCartonsInitialQuery listAsyncQuery);
        Task<RobotCartonsInitialDto> GetAsync(GetRobotCartonsInitialQuery query);
    }
}
