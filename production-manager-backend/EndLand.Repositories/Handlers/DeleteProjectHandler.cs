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
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IProjectService _projectService;
        private readonly ILogger<DeleteProjectHandler> _logger;

        public DeleteProjectHandler(IProjectService projectService, ILogger<DeleteProjectHandler> logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }

            await _projectService.DeleteAsync(request);
        }
    }
}
