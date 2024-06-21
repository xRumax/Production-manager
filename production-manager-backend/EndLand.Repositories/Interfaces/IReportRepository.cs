using EndLand.Transfer.ReportsDir.Data;
using EndLand.Transfer.ReportsDir.Queries;
using EndLand.Transfer.Shared.Data;

namespace EndLand.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Task<PaginatedList<ReportListDto>> ListAsync(ListReportQuery listAsyncQuery);
        Task<ReportDto> GetAsync(GetReportQuery query);
        Task<MemoryStream> GetExcelReportAsync(ExcelReportReportQuery query);
    }
}
