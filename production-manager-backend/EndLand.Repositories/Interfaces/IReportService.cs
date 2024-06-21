using EndLand.Transfer.ReportsDir.Commands;
using EndLand.Transfer.ReportsDir.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Interfaces
{
    public interface IReportService
    {
        Task DeleteAsync(DeleteReportCommand query);
    }
}
