using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ReportsDir.Data;
using EndLand.Transfer.ReportsDir.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EndLand.Repositories.Handlers
{
    public class GetReportHandler : IRequestHandler<GetReportQuery, ReportDto>
    {
        private readonly IReportRepository _reportRepository;
        private readonly ILogger<GetReportHandler> _logger;
        
        public GetReportHandler(IReportRepository reportRepository, ILogger<GetReportHandler> logger)
        {
            _reportRepository = reportRepository;
            _logger = logger;
        }
        
        public async Task<ReportDto> Handle(GetReportQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }
            
            return await _reportRepository.GetAsync(request);
        }
    }
}

