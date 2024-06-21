using EndLand.Data.Models;
using EndLand.Repositories.Interfaces;
using EndLand.Transfer.RobotCartonsInitialDir.Data;
using EndLand.Transfer.RobotCartonsInitialDir.Queries;
using EndLand.Transfer.Shared.Data;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Handlers
{
    public class ListRobotCartonsInitialHandler : IRequestHandler<ListRobotCartonsInitialQuery, PaginatedList<RobotCartonsInitialListDto>>
    {
        private readonly IRobotCartonsInitialRepository _robotCartonsInitialRepository;
        private readonly ILogger<ListRobotCartonsInitialHandler> _logger;

        public ListRobotCartonsInitialHandler(IRobotCartonsInitialRepository robotCartonsInitialRepository, ILogger<ListRobotCartonsInitialHandler> logger)
        {
            _robotCartonsInitialRepository = robotCartonsInitialRepository;
            _logger = logger;
        }

        public async Task<PaginatedList<RobotCartonsInitialListDto>> Handle(ListRobotCartonsInitialQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }
            return await _robotCartonsInitialRepository.ListAsync(request);
        }
    }
}
