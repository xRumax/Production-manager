using EndLand.Data.Models;
using EndLand.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndLand.Core.CustomExceptions;
using EndLand.Core.Enums;
using EndLand.Transfer.RobotWaterMeterDir.Data;
using EndLand.Transfer.RobotWaterMeterDir.Queries;
using Microsoft.EntityFrameworkCore;
using EndLand.Transfer.Shared.Data;

namespace EndLand.Repositories.Implementations
{
    public class RobotWaterMeterRepository : IRobotWaterMeterRepository
    {
        private readonly NetLandContext _dbContext;

        public RobotWaterMeterRepository(NetLandContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginatedList<RobotWaterMeterListDto>> ListAsync(ListRobotWaterMeterQuery listAsyncQuery)
        {
            var query = _dbContext.RobotWaterMeters
                .AsNoTracking()
                .OrderBy(p => p.Id);

            return await PaginatedList<RobotWaterMeterListDto>.CreateAsync(query.Select(p => new RobotWaterMeterListDto
            {
                Id = p.Id,
                SerialNumber = p.SerialNumber,
                Purpose = p.Purpose,
                Owner = p.Owner
            }).AsQueryable()
            .AsNoTracking(),
            listAsyncQuery.PageIndex,
            listAsyncQuery.PageSize
                );
        }

        public async Task<RobotWaterMeterDto> GetAsync(GetRobotWaterMeterQuery query)
        {
            var robotWaterMeter = await _dbContext.RobotWaterMeters
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == query.Id);

            if (robotWaterMeter == null)
            {
                throw new CustomException(CustomErrorCode.RobotWaterMeterNotFound, $"Unable to find Robot Water Meter with id: {query.Id}");
            }

            return new RobotWaterMeterDto()
            {
                Id = robotWaterMeter.Id,
                IdCartonInitial = robotWaterMeter.IdCartonInitial,
                IdCartonFinish = robotWaterMeter.IdCartonFinish,
                SerialNumber = robotWaterMeter.SerialNumber,
                Purpose = robotWaterMeter.Purpose,
                Dn = robotWaterMeter.Dn,
                Q3 = robotWaterMeter.Q3,
                YearLegalization = robotWaterMeter.YearLegalization,
                YearSecondaryLegalization = robotWaterMeter.YearSecondaryLegalization,
                PixelCount = robotWaterMeter.PixelCount,
                TestResult = robotWaterMeter.TestResult,
                PixelCount2 = robotWaterMeter.PixelCount2,
                Owner = robotWaterMeter.Owner
            };   
        }

    }
}