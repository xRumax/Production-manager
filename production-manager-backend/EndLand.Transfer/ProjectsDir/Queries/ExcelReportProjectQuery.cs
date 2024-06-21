using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.ProjectsDir.Queries
{
    public class ExcelReportProjectQuery : IRequest<MemoryStream>
    {
        public List<int> List { get; set; } = [];
    }
}
