using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ProjectsDir.Data;
using EndLand.Transfer.ProjectsDir.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Handlers
{
    public class GetProjectHandler : IRequestHandler<GetProjectQuery, ProjectDto>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ILogger<GetProjectHandler> _logger;

        public GetProjectHandler(IProjectRepository projectRepository, ILogger<GetProjectHandler> logger)
        {
            _projectRepository = projectRepository;
            _logger = logger;
        }

        public async Task<ProjectDto> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }

            return await _projectRepository.GetAsync(request);
        }
    }
}
