using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ProjectsDir.Queries;
using EndLand.Transfer.RobotDeviceProgDir.Data;
using EndLand.Transfer.RobotDeviceProgDir.Queries;
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
    public class ListRobotDevicesProgHandler : IRequestHandler<ListRobotDevicesProgQuery, PaginatedList<RobotDevicesProgListDto>>
    {
        private readonly IRobotDeviceProgRepository _robotDevicesProgRepository;
        private readonly ILogger<ListRobotDevicesProgHandler> _logger;

        public ListRobotDevicesProgHandler(IRobotDeviceProgRepository robotDeviceProgRepository, ILogger<ListRobotDevicesProgHandler> logger)
        {
            _robotDevicesProgRepository = robotDeviceProgRepository;
            _logger = logger;
        }

        public async Task<PaginatedList<RobotDevicesProgListDto>> Handle(ListRobotDevicesProgQuery request, CancellationToken cancellationToken)
        {
            if(cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }
            return await _robotDevicesProgRepository.ListAsync(request);
        }
    }
}
