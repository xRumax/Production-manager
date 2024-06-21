using EndLand.Core.CustomExceptions;
using EndLand.Core.Enums;
using EndLand.Data.Models;
using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ProjectsDir.Data;
using EndLand.Transfer.ProjectsDir.Queries;
using EndLand.Transfer.RobotConfigurationDir.Data;
using EndLand.Transfer.RobotConfigurationDir.Queries;
using EndLand.Transfer.RobotWaterMeterDir.Data;
using EndLand.Transfer.RobotWaterMeterDir.Queries;
using EndLand.Transfer.Shared.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Implementations
{
    public class RobotConfigurationRepository : IRobotConfigurationRepository
    {
        private readonly NetLandContext _dbContext;

        public RobotConfigurationRepository(NetLandContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginatedList<RobotConfigurationDto>> ListAsync(ListRobotConfigurationQuery listyAsyncQuery)
        {
            var query = _dbContext.RobotConfigurations
                .AsNoTracking()
                .OrderBy(x => x.Id);

            return await PaginatedList<RobotConfigurationDto>.CreateAsync(query.Select(p => new RobotConfigurationDto
            {
                PixelTreshold = p.PixelTreshold,
                Id = p.Id,
                QuantityWaterMetersInCartonu = p.QuantityWaterMetersInCarton,
            }).AsQueryable()
                .AsNoTracking(),
                listyAsyncQuery.PageIndex,
                listyAsyncQuery.PageSize
            );
        }
        
        public async Task<RobotConfigurationDto> GetAsync(GetRobotConfigurationQuery query)
        {
            var robotConfiguration = await _dbContext.RobotConfigurations
                .FirstOrDefaultAsync(p => p.Id == query.Id);

            if (robotConfiguration == null)
            {
                throw new CustomException(CustomErrorCode.RobotConfigurationNotFound, $"Unable to find RobotConfiguration with id: {query.Id}");
            }

            return new RobotConfigurationDto
            {
                PixelTreshold = robotConfiguration.PixelTreshold,
                Id = robotConfiguration.Id,
                QuantityWaterMetersInCartonu = robotConfiguration.QuantityWaterMetersInCarton,
            };
        }
    }
}

