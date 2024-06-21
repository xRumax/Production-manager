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
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProjectService _projectService;
        private readonly ILogger<UpdateProjectHandler> _logger;

        public UpdateProjectHandler(IProjectService projectService, ILogger<UpdateProjectHandler> logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        public async Task Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }

            await _projectService.UpdateAsync(request);
        }
    }
}
