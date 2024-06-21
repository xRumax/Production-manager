using EndLand.Core.CustomExceptions;
using EndLand.Core.Enums;
using EndLand.Data.Models;
using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ProjectsDir.Commands;
using EndLand.Transfer.ProjectsDir.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly NetLandContext _dbContext;

        public ProjectService(NetLandContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProjectDto> CreateAsync(CreateProjectCommand query)
        {
            var project = new Project
            {
                Name = query.Name,
                WaterMeterConstFlowRate = query.WaterMeterConstFlowRate,
                WaterMeterDiameter = query.WaterMeterDiameter,
                WaterLeakAlarmCounterThreshold = query.WaterLeakAlarmCounterThreshold,
                WaterLeakAlarmLowerThreshold = query.WaterLeakAlarmLowerThreshold,
                WaterLeakAlarmInterval = query.WaterLeakAlarmInterval,
                SuddenWaterLossAlarmLowerThreshold = query.SuddenWaterLossAlarmLowerThreshold,
                SuddenWaterLossAlarmInterval = query.SuddenWaterLossAlarmInterval,
                SuddenWaterLossAlarmCounterThreshold = query.SuddenWaterLossAlarmCounterThreshold,
                WaterMeterMeasuringRange = query.WaterMeterMeasuringRange
            };

            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveOrHandleExceptionAsync();

            var projectFromDb = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == project.Id);

            if (projectFromDb == null)
            {
                throw new CustomException(CustomErrorCode.ProjectNotFound, $"Unable to find project with id: {project.Id}");
            }

            return new ProjectDto
            {
                Id = projectFromDb.Id,
                Name = projectFromDb.Name,
                WaterMeterConstFlowRate = projectFromDb.WaterMeterConstFlowRate,
                WaterMeterDiameter = projectFromDb.WaterMeterDiameter,
                WaterLeakAlarmCounterThreshold = projectFromDb.WaterLeakAlarmCounterThreshold,
                WaterLeakAlarmLowerThreshold = projectFromDb.WaterLeakAlarmLowerThreshold,
                WaterLeakAlarmInterval = projectFromDb.WaterLeakAlarmInterval,
                SuddenWaterLossAlarmLowerThreshold = projectFromDb.SuddenWaterLossAlarmLowerThreshold,
                SuddenWaterLossAlarmInterval = projectFromDb.SuddenWaterLossAlarmInterval,
                SuddenWaterLossAlarmCounterThreshold = projectFromDb.SuddenWaterLossAlarmCounterThreshold,
                WaterMeterMeasuringRange = projectFromDb.WaterMeterMeasuringRange
            };
        }

        public async Task UpdateAsync(UpdateProjectCommand query)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == query.Id);

            if (project == null)
            {
                throw new CustomException(CustomErrorCode.ProjectNotFound, $"Unable to find project with id: {query.Id}");
            }

            bool anyIncidentsExist = await _dbContext.Incidents
                .AnyAsync(i => i.ProjectName == project.Name);

            bool anyDevicesProduced = await _dbContext.RobotDevicesProgs
                .AnyAsync(d => _dbContext.Incidents.Any(i => i.Imei == d.Imei && i.ProjectName == project.Name));

            if (anyIncidentsExist || anyDevicesProduced)
            {
                throw new CustomException(CustomErrorCode.ProjectWithIncidentsOrProducedDevices, $"Unable to edit project with id: {query.Id}");
            }

            project.Name = query.Name;
            project.WaterMeterConstFlowRate = query.WaterMeterConstFlowRate;
            project.WaterMeterDiameter = query.WaterMeterDiameter;
            project.WaterLeakAlarmCounterThreshold = query.WaterLeakAlarmCounterThreshold;
            project.WaterLeakAlarmLowerThreshold = query.WaterLeakAlarmLowerThreshold;
            project.WaterLeakAlarmInterval = query.WaterLeakAlarmInterval;
            project.SuddenWaterLossAlarmLowerThreshold = query.SuddenWaterLossAlarmLowerThreshold;
            project.SuddenWaterLossAlarmInterval = query.SuddenWaterLossAlarmInterval;
            project.SuddenWaterLossAlarmCounterThreshold = query.SuddenWaterLossAlarmCounterThreshold;
            project.WaterMeterMeasuringRange = query.WaterMeterMeasuringRange;

            await _dbContext.SaveOrHandleExceptionAsync();
        }

        public async Task DeleteAsync(DeleteProjectCommand query)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == query.Id);

            if (project == null)
            {
                throw new CustomException(CustomErrorCode.DatabaseError, $"Unable to find project with id: {query.Id}");
            }

            bool anyIncidentsExist = await _dbContext.Incidents
                .AnyAsync(i => i.ProjectName == project.Name);

            bool anyDevicesProduced = await _dbContext.RobotDevicesProgs
                .AnyAsync(d => _dbContext.Incidents.Any(i => i.Imei == d.Imei && i.ProjectName == project.Name));

            if (anyIncidentsExist || anyDevicesProduced)
            {
                throw new CustomException(CustomErrorCode.DatabaseError, $"Unable to delete project with id: {query.Id}");
            }

            _dbContext.Projects.Remove(project);
            await _dbContext.SaveOrHandleExceptionAsync();
        }
    }
}
