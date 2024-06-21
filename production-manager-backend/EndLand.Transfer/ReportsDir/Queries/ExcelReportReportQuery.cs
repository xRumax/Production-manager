using EndLand.Transfer.ReportsDir.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.ReportsDir.Queries
{
    public class ExcelReportReportQuery : IRequest<MemoryStream>
    {
        public List<string> List { get; set; } = [];
    }
}
