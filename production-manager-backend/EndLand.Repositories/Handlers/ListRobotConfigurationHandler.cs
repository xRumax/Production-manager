using EndLand.Repositories.Interfaces;
using EndLand.Transfer.RobotConfigurationDir.Data;
using EndLand.Transfer.RobotConfigurationDir.Queries;
using EndLand.Transfer.RobotWaterMeterDir.Data;
using EndLand.Transfer.RobotWaterMeterDir.Queries;
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
    public class ListRobotConfigurationHandler : IRequestHandler<ListRobotConfigurationQuery, PaginatedList<RobotConfigurationDto>>
    {
        private readonly IRobotConfigurationRepository _robotConfigurationRepository;
        private readonly ILogger<ListRobotConfigurationHandler> _logger;

        public ListRobotConfigurationHandler(IRobotConfigurationRepository robotConfigurationRepository, ILogger<ListRobotConfigurationHandler> logger)
        {
            _robotConfigurationRepository = robotConfigurationRepository;
            _logger = logger;
        }

        public async Task<PaginatedList<RobotConfigurationDto>> Handle(ListRobotConfigurationQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }
            return await _robotConfigurationRepository.ListAsync(request);
        }
    }
}
