using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ReportsDir.Data;
using EndLand.Transfer.ReportsDir.Queries;
using EndLand.Transfer.Shared.Data;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EndLand.Repositories.Handlers
{
    public class ListReportHandler : IRequestHandler<ListReportQuery, PaginatedList<ReportListDto>>
    {

        private readonly IReportRepository _reportRepository;
        private readonly ILogger<ListReportHandler> _logger;

        public ListReportHandler(IReportRepository reportRepository, ILogger<ListReportHandler> logger)
        {
            _reportRepository = reportRepository;
            _logger = logger;
        }
        
        public async Task<PaginatedList<ReportListDto>> Handle(ListReportQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }
            
            return await _reportRepository.ListAsync(request);

        }
    }
}
