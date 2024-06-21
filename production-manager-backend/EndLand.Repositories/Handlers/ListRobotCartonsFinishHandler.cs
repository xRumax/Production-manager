using EndLand.Repositories.Interfaces;
using EndLand.Transfer.RobotCartonsFinishDir.Data;
using EndLand.Transfer.RobotCartonsFinishDir.Queries;
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
    public class ListRobotCartonsFinishHandler : IRequestHandler<ListRobotCartonsFinishQuery, PaginatedList<RobotCartonsFinishListDto>>
    {
        private readonly IRobotCartonsFinishRepository _robotCartonsFinishRepository;
        private readonly ILogger<ListRobotCartonsFinishHandler> _logger;

        public ListRobotCartonsFinishHandler(IRobotCartonsFinishRepository robotCartonsFinishRepository, ILogger<ListRobotCartonsFinishHandler> logger)
        {
            _robotCartonsFinishRepository = robotCartonsFinishRepository;
            _logger = logger;
        }

        public async Task<PaginatedList<RobotCartonsFinishListDto>> Handle(ListRobotCartonsFinishQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }
            return await _robotCartonsFinishRepository.ListAsync(request);
        }
    }
    
    }

