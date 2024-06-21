using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ProjectsDir.Commands;
using EndLand.Transfer.ProjectsDir.Data;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Handlers
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, ProjectDto>
    {
        private readonly IProjectService _projectService;
        private readonly ILogger<CreateProjectHandler> _logger;

        public CreateProjectHandler(IProjectService projectService, ILogger<CreateProjectHandler> logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        public async Task<ProjectDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }

            return await _projectService.CreateAsync(request);
        }
    }
}
