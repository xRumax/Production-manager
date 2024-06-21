using EndLand.Repositories.Interfaces;
using EndLand.Transfer.RobotDevicesProgDir.Data;
using EndLand.Transfer.RobotDevicesProgDir.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Handlers
{
    public class GetRobotDeviceHandler : IRequestHandler<GetRobotDeviceQuery, RobotDeviceDto>
    {
        private readonly IRobotDeviceProgRepository _robotDevicesRepository;
        private readonly ILogger<GetRobotDeviceHandler> _logger;

        public GetRobotDeviceHandler(IRobotDeviceProgRepository IrobotDevicesProgRepository, ILogger<GetRobotDeviceHandler> logger)
        {
            _robotDevicesRepository = IrobotDevicesProgRepository;
            _logger = logger;
        }

        public async Task<RobotDeviceDto> Handle(GetRobotDeviceQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }

            return await _robotDevicesRepository.GetAsync(request);
        }
    }
}
