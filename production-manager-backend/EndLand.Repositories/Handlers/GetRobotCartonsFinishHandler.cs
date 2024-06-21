using EndLand.Repositories.Implementations;
using EndLand.Repositories.Interfaces;
using EndLand.Transfer.RobotCartonsFinishDir.Data;
using EndLand.Transfer.RobotCartonsFinishDir.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Handlers
{
    public class GetRobotCartonsFinishHandler : IRequestHandler<GetRobotCartonsFinishQuery, RobotCartonsFinishDto>
    {
        private readonly IRobotCartonsFinishRepository _robotCartonsFinishRepository;
        private readonly ILogger<GetRobotCartonsFinishHandler> _logger;

        public GetRobotCartonsFinishHandler(IRobotCartonsFinishRepository robotCartonsFinishRepository, ILogger<GetRobotCartonsFinishHandler> logger)
        {
            _robotCartonsFinishRepository = robotCartonsFinishRepository;
            _logger = logger;
        }

        public async Task<RobotCartonsFinishDto> Handle(GetRobotCartonsFinishQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }

            return await _robotCartonsFinishRepository.GetAsync(request);
        }
    }
}
