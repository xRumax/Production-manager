using EndLand.Transfer.Shared.Data;
using EndLand.Transfer.UsersDir.Data;
using EndLand.Transfer.UsersDir.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<PaginatedList<UserListDto>> ListAsync(ListUsersQuery query);
        Task<UserDto> GetAsync(GetUserQuery query);
    }
}
