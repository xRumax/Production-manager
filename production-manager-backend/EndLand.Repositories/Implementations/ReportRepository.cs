using EndLand.Core.CustomExceptions;
using EndLand.Core.Enums;
using EndLand.Core.PolishHeaders;
using EndLand.Data.Models;
using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ReportsDir.Data;
using EndLand.Transfer.ReportsDir.Queries;
using EndLand.Transfer.Shared.Data;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace EndLand.Repositories.Implementations
{
    public class ReportRepository : IReportRepository
    {
        private readonly NetLandContext _dbContext;

        public ReportRepository(NetLandContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<PaginatedList<ReportListDto>> ListAsync(ListReportQuery listAsyncQuery)
        {
            var query = _dbContext.Reports.AsNoTracking();

            if (!string.IsNullOrEmpty(listAsyncQuery.SearchBy) && !string.IsNullOrEmpty(listAsyncQuery.SearchFor))
            {
                switch (listAsyncQuery.SearchBy.ToLower())
                {
                    case "imei":
                        query = query.Where(p => p.Imei.Contains(listAsyncQuery.SearchFor));
                        break;
                    case "projectname":
                        query = query.Where(p => p.ProjectName.Contains(listAsyncQuery.SearchFor));
                        break;
                    case "ordernumber":
                        query = query.Where(p => p.OrderNumber.Contains(listAsyncQuery.SearchFor));
                        break;
                    default:
                        throw new ArgumentException("Invalid SearchBy value.");
                }
            }

            query = query.OrderBy(p => p.Imei);

            return await PaginatedList<ReportListDto>.CreateAsync(query.Select(p => new ReportListDto
            {
                Imei = p.Imei,
                UserName = p.UserName,
                ProjectName = p.ProjectName,
                OrderNumber = p.OrderNumber,
                Model = p.Model,
                Ccid = p.Ccid,
                SerialNumber = p.SerialNumber,
                FirmwareVersion = p.FirmwareVersion,
                Volume = p.Volume,
                EsiThresholdChannel0 = p.EsiThresholdChannel0
            }).AsQueryable()
            .AsNoTracking(),
                listAsyncQuery.PageIndex,
                listAsyncQuery.PageSize
            );
        }

        public async Task<ReportDto> GetAsync(GetReportQuery query)
        {
            var report = await _dbContext.Reports.AsNoTracking().FirstOrDefaultAsync(p => p.Imei == query.Imei);

            if (report == null)
            {
                throw new CustomException(CustomErrorCode.ReportNotFound,
                    $"Unable to find Report with Imei: {query.Imei}");
            }

            return new ReportDto
            {

                Imei = report.Imei,
                UserName = report.UserName,
                ProjectName = report.ProjectName,
                OrderNumber = report.OrderNumber,
                Model = report.Model,
                Ccid = report.Ccid,
                SerialNumber = report.SerialNumber,
                FirmwareVersion = report.FirmwareVersion,
                Volume = report.Volume,
                EsiThresholdChannel0 = report.EsiThresholdChannel0,
                EsiThresholdChannel1 = report.EsiThresholdChannel1,
                EsiAfe1BaseChannel0 = report.EsiAfe1BaseChannel0,
                EsiAfe1BaseChannel1 = report.EsiAfe1BaseChannel1,
                EsiAfe2BaseChannel0 = report.EsiAfe2BaseChannel0,
                EsiAfe2BaseChannel1 = report.EsiAfe2BaseChannel1,
                WaterMeterConstFlowRate = report.WaterMeterConstFlowRate,
                WaterMeterDiameter = report.WaterMeterDiameter,
                WaterLeakAlarmCounterThreshold = report.WaterLeakAlarmCounterThreshold,
                WaterLeakAlarmLowerThreshold = report.WaterLeakAlarmLowerThreshold,
                WaterLeakAlarmInterval = report.WaterLeakAlarmInterval,
                SuddenWaterLossAlarmCounterThreshold = report.SuddenWaterLossAlarmCounterThreshold,
                SuddenWaterLossAlarmLowerThreshold = report.SuddenWaterLossAlarmLowerThreshold,
                SuddenWaterLossAlarmInterval = report.SuddenWaterLossAlarmInterval,
                StartedAt = report.StartedAt,
                FinishedAt = report.FinishedAt,
                CreatedAt = report.CreatedAt,
                EsiThresholdChannel2 = report.EsiThresholdChannel2,
                EsiAfe1BaseChannel2 = report.EsiAfe1BaseChannel2,
                EsiAfe2BaseChannel2 = report.EsiAfe2BaseChannel2
            };
        }

        public async Task<MemoryStream> GetExcelReportAsync(ExcelReportReportQuery query)
        {
            var imeisRecordsData = await _dbContext.Reports
                .Where(r => query.List.Contains(r.Imei))
                .ToListAsync();

            var imeisRecords = imeisRecordsData
                .GroupBy(r => r.Imei)
                .ToDictionary(r => r.Key, r => r.ToList());

            var headers = PolishHeaders.GetPolishHeadersOfReports();

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                foreach (var kvp in imeisRecords)
                {
                    string imei = kvp.Key;
                    List<Report> reports = kvp.Value;

                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(imei);

                    for (int i = 0; i < headers.Count; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = headers[i];
                    }

                    int row = 2;
                    foreach (var report in reports)
                    {
                        worksheet.Cells[row, 1].Value = report.Imei;
                        worksheet.Cells[row, 2].Value = report.UserName;
                        worksheet.Cells[row, 3].Value = report.ProjectName;
                        worksheet.Cells[row, 4].Value = report.OrderNumber;
                        worksheet.Cells[row, 5].Value = report.Model;
                        worksheet.Cells[row, 6].Value = report.Ccid;
                        worksheet.Cells[row, 7].Value = report.SerialNumber;
                        worksheet.Cells[row, 8].Value = report.FirmwareVersion;
                        worksheet.Cells[row, 9].Value = report.Volume;
                        worksheet.Cells[row, 10].Value = report.EsiThresholdChannel0;
                        worksheet.Cells[row, 11].Value = report.EsiThresholdChannel1;
                        worksheet.Cells[row, 12].Value = report.EsiAfe1BaseChannel0;
                        worksheet.Cells[row, 13].Value = report.EsiAfe1BaseChannel1;
                        worksheet.Cells[row, 14].Value = report.EsiAfe2BaseChannel0;
                        worksheet.Cells[row, 15].Value = report.EsiAfe2BaseChannel1;
                        worksheet.Cells[row, 16].Value = report.WaterMeterConstFlowRate;
                        worksheet.Cells[row, 17].Value = report.WaterMeterDiameter;
                        worksheet.Cells[row, 18].Value = report.WaterLeakAlarmCounterThreshold;
                        worksheet.Cells[row, 19].Value = report.WaterLeakAlarmLowerThreshold;
                        worksheet.Cells[row, 20].Value = report.WaterLeakAlarmInterval;
                        worksheet.Cells[row, 21].Value = report.SuddenWaterLossAlarmCounterThreshold;
                        worksheet.Cells[row, 22].Value = report.SuddenWaterLossAlarmLowerThreshold;
                        worksheet.Cells[row, 23].Value = report.SuddenWaterLossAlarmInterval;
                        worksheet.Cells[row, 24].Value = report.StartedAt.ToString("yyyy-MM-dd HH:mm:ss");
                        worksheet.Cells[row, 25].Value = report.FinishedAt.ToString("yyyy-MM-dd HH:mm:ss");
                        worksheet.Cells[row, 26].Value = report.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
                        worksheet.Cells[row, 27].Value = report.EsiThresholdChannel2;
                        worksheet.Cells[row, 28].Value = report.EsiAfe1BaseChannel2;
                        worksheet.Cells[row, 29].Value = report.EsiAfe2BaseChannel2;

                        row++;
                    }
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                }

                MemoryStream stream = new MemoryStream();
                excelPackage.SaveAs(stream);
                stream.Position = 0;

                return await Task.FromResult(stream);
            }
        }
    }
}
