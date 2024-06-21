using EndLand.Data.Models;
using EndLand.Repositories.Interfaces;
using EndLand.Transfer.RobotCartonsInitialDir.Data;
using EndLand.Transfer.RobotCartonsInitialDir.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Handlers
{
    public class GetRobotCartonsInitialHandler : IRequestHandler<GetRobotCartonsInitialQuery, RobotCartonsInitialDto>
    {
        private readonly IRobotCartonsInitialRepository _robotCartonsInitialRepository;
        private readonly ILogger<GetRobotCartonsInitialHandler> _logger;

        public GetRobotCartonsInitialHandler(IRobotCartonsInitialRepository robotCartonsInitialRepository, ILogger<GetRobotCartonsInitialHandler> logger)
        {
            _robotCartonsInitialRepository = robotCartonsInitialRepository;
            _logger = logger;
        }

        public async Task<RobotCartonsInitialDto> Handle(GetRobotCartonsInitialQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }

            return await _robotCartonsInitialRepository.GetAsync(request);
        }
    }
}
