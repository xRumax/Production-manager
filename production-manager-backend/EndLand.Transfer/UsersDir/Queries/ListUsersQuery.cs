using EndLand.Transfer.Shared.Data;
using EndLand.Transfer.Shared.Queries;
using EndLand.Transfer.UsersDir.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.UsersDir.Queries
{
    public class ListUsersQuery : ListQuery, IRequest<PaginatedList<UserListDto>>
    {
    }
}
