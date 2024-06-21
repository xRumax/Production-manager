using MediatR;
using EndLand.Transfer.ProjectsDir.Data;
using EndLand.Transfer.Shared.Data;
using EndLand.Transfer.Shared.Queries;

namespace EndLand.Transfer.ProjectsDir.Queries
{
    public class ListProjectQuery : ListQuery, IRequest<PaginatedList<ProjectListDto>>
    {
    }
}
