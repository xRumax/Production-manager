using EndLand.Core.CustomExceptions;
using EndLand.Core.Enums;
using EndLand.Data.Models;
using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ReportsDir.Commands;
using EndLand.Transfer.ReportsDir.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Implementations
{
    public class ReportService : IReportService
    {
        private readonly NetLandContext _dbContext;

        public ReportService(NetLandContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(DeleteReportCommand query)
        {
            var report = await _dbContext.Reports.FirstOrDefaultAsync(p => p.Imei == query.Imei && p.CreatedAt == query.CreatedAt);

            if (report == null)
            {
                throw new CustomException(CustomErrorCode.DatabaseError, $"Unable to find report with Imei: {query.Imei} and created at {query.CreatedAt}");
            }

            _dbContext.Reports.Remove(report);
            await _dbContext.SaveOrHandleExceptionAsync();
        }
    }
}
