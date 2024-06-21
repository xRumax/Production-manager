using EndLand.Repositories.Implementations;
using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ProjectsDir.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Handlers
{
    public class ExcelReportProjectHandler : IRequestHandler<ExcelReportProjectQuery, MemoryStream>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ILogger<ExcelReportProjectHandler> _logger;

        public ExcelReportProjectHandler(IProjectRepository projectRepository, ILogger<ExcelReportProjectHandler> logger)
        {
            _projectRepository = projectRepository;
            _logger = logger;
        }

        public async Task<MemoryStream> Handle(ExcelReportProjectQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }

            return await _projectRepository.GetExcelReportAsync(request);
        }
    }
}
