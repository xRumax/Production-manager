using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ReportsDir.Commands;
using EndLand.Transfer.ReportsDir.Data;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Handlers
{
    public class DeleteReportHandler : IRequestHandler<DeleteReportCommand>
    {
        private readonly IReportService _reportService;
        private readonly ILogger<DeleteReportHandler> _logger;

        public DeleteReportHandler(IReportService reportService, ILogger<DeleteReportHandler> logger)
        {
            _reportService = reportService;
            _logger = logger;
        }

        public async Task Handle(DeleteReportCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }

            await _reportService.DeleteAsync(request);
        }
    }
}
