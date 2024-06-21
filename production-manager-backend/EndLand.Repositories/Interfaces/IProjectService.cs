using EndLand.Transfer.ProjectsDir.Commands;
using EndLand.Transfer.ProjectsDir.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDto> CreateAsync(CreateProjectCommand query);
        Task UpdateAsync(UpdateProjectCommand query);
        Task DeleteAsync(DeleteProjectCommand query);
    }
}
