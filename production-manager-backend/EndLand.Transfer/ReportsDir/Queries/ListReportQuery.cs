using EndLand.Transfer.ReportsDir.Data;
using EndLand.Transfer.Shared.Data;
using EndLand.Transfer.Shared.Queries;
using MediatR;


namespace EndLand.Transfer.ReportsDir.Queries
{
    public class ListReportQuery : ListQuery, IRequest<PaginatedList<ReportListDto>>
    {
        
    }
}