using EndLand.Transfer.ReportsDir.Data;
using MediatR;

namespace EndLand.Transfer.ReportsDir.Queries
{
    public class GetReportQuery : IRequest<ReportDto>
    {
        public string Imei { get; set; } = null!;

    }
}
