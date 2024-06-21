using EndLand.Transfer.ReportsDir.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EndLand.Transfer.ReportsDir.Commands
{
    public class DeleteReportCommand : IRequest
    {
        public string Imei { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
    }
}
