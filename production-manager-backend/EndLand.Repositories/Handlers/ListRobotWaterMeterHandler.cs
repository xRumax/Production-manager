using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ProjectsDir.Queries;
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
    public class ListRobotWaterMeterHandler : IRequestHandler<ListRobotWaterMeterQuery, PaginatedList<RobotWaterMeterListDto>>
    {
        private readonly IRobotWaterMeterRepository _robotWaterMeterRepository;
        private readonly ILogger<ListRobotWaterMeterHandler> _logger;

        public ListRobotWaterMeterHandler(IRobotWaterMeterRepository robotWaterMeterRepository, ILogger<ListRobotWaterMeterHandler> logger)
        {
            _robotWaterMeterRepository = robotWaterMeterRepository;
            _logger = logger;
        }

        public async Task<PaginatedList<RobotWaterMeterListDto>> Handle(ListRobotWaterMeterQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }
            return await _robotWaterMeterRepository.ListAsync(request);
        }
    }
}
