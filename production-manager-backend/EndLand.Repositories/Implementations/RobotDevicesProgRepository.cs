using EndLand.Core.CustomExceptions;
using EndLand.Core.Enums;
using EndLand.Data.Models;
using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ProjectsDir.Data;
using EndLand.Transfer.RobotDeviceProgDir.Data;
using EndLand.Transfer.RobotDeviceProgDir.Queries;
using EndLand.Transfer.RobotDevicesProgDir.Data;
using EndLand.Transfer.RobotDevicesProgDir.Queries;
using EndLand.Transfer.Shared.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Implementations
{
    public class RobotDeviceProgRepository : IRobotDeviceProgRepository
    {
        private readonly NetLandContext _dbContext;

        public RobotDeviceProgRepository(NetLandContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginatedList<RobotDevicesProgListDto>> ListAsync(ListRobotDevicesProgQuery listAsyncQuery)
        {
            var query = _dbContext.RobotDevicesProgs
                .AsNoTracking()
                .OrderBy(p => p.Id);

            return await PaginatedList<RobotDevicesProgListDto>.CreateAsync(query.Select(p => new RobotDevicesProgListDto
            {
                Id = p.Id,
                Imei = p.Imei,
                StartedAt = p.StartedAt,
                FinishedAt = p.FinishedAt
            }).AsQueryable()
            .AsNoTracking(),
            listAsyncQuery.PageIndex,
            listAsyncQuery.PageSize
                );
        }

        public async Task<RobotDeviceDto> GetAsync(GetRobotDeviceQuery query)
        {
            var robotDevices = await _dbContext.RobotDevicesProgs
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == query.Id);

            if (robotDevices == null)
            {
                throw new CustomException(CustomErrorCode.RobotDeviceNotFound, $"Unable to find Robot Devices with id: {query.Id}");
            }

            return new RobotDeviceDto
            {
                Id = robotDevices.Id,
                Imei = robotDevices.Imei,
                StartedAt = robotDevices.StartedAt,
                FirmwareVer = robotDevices.FirmwareVer,
                Device = robotDevices.Device,
                FinishedAt = robotDevices.FinishedAt
            };
        }
    }
}
