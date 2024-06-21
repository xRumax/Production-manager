using EndLand.Repositories.Implementations;
using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ReportsDir.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Handlers
{
    public class ExcelReportReportHandler : IRequestHandler<ExcelReportReportQuery, MemoryStream>
    {
        private readonly IReportRepository _reportRepository;
        private readonly ILogger<ExcelReportReportHandler> _logger;

        public ExcelReportReportHandler(IReportRepository reportRepository, ILogger<ExcelReportReportHandler> logger)
        {
            _reportRepository = reportRepository;
            _logger = logger;
        }

        public async Task<MemoryStream> Handle(ExcelReportReportQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }

            return await _reportRepository.GetExcelReportAsync(request);
        }
    }
}
