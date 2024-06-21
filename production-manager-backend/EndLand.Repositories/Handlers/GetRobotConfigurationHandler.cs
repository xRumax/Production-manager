using EndLand.Data.Models;
using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ProjectsDir.Data;
using EndLand.Transfer.ProjectsDir.Queries;
using EndLand.Transfer.RobotConfigurationDir.Data;
using EndLand.Transfer.RobotConfigurationDir.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Handlers
{
    public class GetRobotConfigurationHandler : IRequestHandler<GetRobotConfigurationQuery, RobotConfigurationDto>
    {
        private readonly IRobotConfigurationRepository _robotConfigurationRepository;
        private readonly ILogger<GetRobotConfigurationHandler> _logger;

        public GetRobotConfigurationHandler(IRobotConfigurationRepository robotConfigurationRepository, ILogger<GetRobotConfigurationHandler> logger)
        {
            _robotConfigurationRepository = robotConfigurationRepository;
            _logger = logger;
        }

        public async Task<RobotConfigurationDto> Handle(GetRobotConfigurationQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }

            return await _robotConfigurationRepository.GetAsync(request);
        }
    }
}
