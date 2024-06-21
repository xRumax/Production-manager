using EndLand.Transfer.ProjectsDir.Commands;
using EndLand.Transfer.ProjectsDir.Data;
using EndLand.Transfer.ProjectsDir.Queries;
using EndLand.Transfer.Shared.Data;

namespace EndLand.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<PaginatedList<ProjectListDto>> ListAsync(ListProjectQuery listyAsyncQuery);
        Task<ProjectDto> GetAsync(GetProjectQuery query);
        Task<MemoryStream> GetExcelReportAsync(ExcelReportProjectQuery query);
    }
}
