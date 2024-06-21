using EndLand.Core.CustomExceptions;
using EndLand.Core.Enums;
using EndLand.Core.PolishHeaders;
using EndLand.Data.Models;
using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ProjectsDir.Commands;
using EndLand.Transfer.ProjectsDir.Data;
using EndLand.Transfer.ProjectsDir.Queries;
using EndLand.Transfer.Shared.Data;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Xml.Linq;

namespace EndLand.Repositories.Implementations
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly NetLandContext _dbContext;

        public ProjectRepository(NetLandContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginatedList<ProjectListDto>> ListAsync(ListProjectQuery listyAsyncQuery)
        {
            var query = _dbContext.Projects
                .AsNoTracking()
                .OrderBy(p => p.Id);

            return await PaginatedList<ProjectListDto>.CreateAsync(query.Select(p => new ProjectListDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    WaterMeterConstFlowRate = p.WaterMeterConstFlowRate,
                    WaterMeterDiameter = p.WaterMeterDiameter
                }).AsQueryable()
                .AsNoTracking(),
                listyAsyncQuery.PageIndex,
                listyAsyncQuery.PageSize
            );
        }

        public async Task<ProjectDto> GetAsync(GetProjectQuery query)
        {
            var project = await _dbContext.Projects
                .FirstOrDefaultAsync(p => p.Id == query.Id);

            if(project == null)
            {
                throw new CustomException(CustomErrorCode.ProjectNotFound, $"Unable to find project with id: {query.Id}");
            }

            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                WaterMeterConstFlowRate = project.WaterMeterConstFlowRate,
                WaterMeterDiameter = project.WaterMeterDiameter,
                WaterLeakAlarmCounterThreshold = project.WaterLeakAlarmCounterThreshold,
                WaterLeakAlarmLowerThreshold = project.WaterLeakAlarmLowerThreshold,
                WaterLeakAlarmInterval = project.WaterLeakAlarmInterval,
                SuddenWaterLossAlarmLowerThreshold = project.SuddenWaterLossAlarmLowerThreshold,
                SuddenWaterLossAlarmInterval = project.SuddenWaterLossAlarmInterval,
                SuddenWaterLossAlarmCounterThreshold = project.SuddenWaterLossAlarmCounterThreshold,
                WaterMeterMeasuringRange = project.WaterMeterMeasuringRange
            };
        }

        public async Task<MemoryStream> GetExcelReportAsync(ExcelReportProjectQuery query)
        {
            var projects = await _dbContext.Projects
                .Where(p => query.List.Contains(p.Id))
                .ToListAsync();

            var projectsRecordsData = await _dbContext.Reports
                .Where(r => projects.Select(x => x.Name).Contains(r.ProjectName))
                .ToListAsync();

            var projectsRecords = projectsRecordsData
                .GroupBy(p => p.ProjectName)
                .ToDictionary(p => p.Key, p => p.ToList());

            var headers = PolishHeaders.GetPolishHeadersOfReports();

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                foreach (var kvp in projectsRecords)
                {
                    string projectName = kvp.Key;
                    List<Report> reports = kvp.Value;

                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(projectName);

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
