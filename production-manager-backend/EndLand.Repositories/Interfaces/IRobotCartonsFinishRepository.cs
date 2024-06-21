using EndLand.Transfer.RobotCartonsFinishDir.Data;
using EndLand.Transfer.RobotCartonsFinishDir.Queries;
using EndLand.Transfer.Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Interfaces
{
    public interface IRobotCartonsFinishRepository
    {
        Task<PaginatedList<RobotCartonsFinishListDto>> ListAsync(ListRobotCartonsFinishQuery listAsyncQuery);
        Task<RobotCartonsFinishDto> GetAsync(GetRobotCartonsFinishQuery query);
    }
}
