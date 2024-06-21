using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ProjectsDir.Data;
using EndLand.Transfer.ProjectsDir.Queries;
using EndLand.Transfer.Shared.Data;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EndLand.Repositories.Handlers
{
    public class ListProjectHandler : IRequestHandler<ListProjectQuery, PaginatedList<ProjectListDto>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ILogger<ListProjectHandler> _logger;

        public ListProjectHandler(IProjectRepository projectRepository, ILogger<ListProjectHandler> logger)
        {
            _projectRepository = projectRepository;
            _logger = logger;
        }

        public async Task<PaginatedList<ProjectListDto>> Handle(ListProjectQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }

            return await _projectRepository.ListAsync(request);
        }
    }
}
