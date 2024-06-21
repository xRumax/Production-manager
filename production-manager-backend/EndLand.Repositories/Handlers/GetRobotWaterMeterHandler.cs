using EndLand.Repositories.Interfaces;
using EndLand.Transfer.RobotWaterMeterDir.Data;
using EndLand.Transfer.RobotWaterMeterDir.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EndLand.Repositories.Handlers;

public class GetRobotWaterMeterHandler : IRequestHandler<GetRobotWaterMeterQuery, RobotWaterMeterDto>
{
    
    private readonly IRobotWaterMeterRepository _robotWaterMeterRepository;
    private readonly ILogger<GetRobotWaterMeterHandler> _logger;
    
    public GetRobotWaterMeterHandler(IRobotWaterMeterRepository robotWaterMeterRepository, ILogger<GetRobotWaterMeterHandler> logger)
    {
        _robotWaterMeterRepository = robotWaterMeterRepository;
        _logger = logger;
    }
    
    public async Task<RobotWaterMeterDto> Handle(GetRobotWaterMeterQuery request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            _logger.LogError("Operation was cancelled.");
            throw new OperationCanceledException("Operation was cancelled.");
        }
        
        return await _robotWaterMeterRepository.GetAsync(request);
    }
}