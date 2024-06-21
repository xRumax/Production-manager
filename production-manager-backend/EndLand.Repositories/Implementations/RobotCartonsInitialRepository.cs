using EndLand.Core.CustomExceptions;
using EndLand.Core.Enums;
using EndLand.Data.Models;
using EndLand.Repositories.Interfaces;
using EndLand.Transfer.RobotCartonsInitialDir.Data;
using EndLand.Transfer.RobotCartonsInitialDir.Queries;
using EndLand.Transfer.RobotWaterMeterDir.Data;
using EndLand.Transfer.RobotWaterMeterDir.Queries;
using EndLand.Transfer.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Implementations
{
    public class RobotCartonsInitialRepository : IRobotCartonsInitialRepository
    {
        private readonly NetLandContext _dbContext;

        public RobotCartonsInitialRepository(NetLandContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginatedList<RobotCartonsInitialListDto>> ListAsync(ListRobotCartonsInitialQuery listAsyncQuery)
        {
            var query = _dbContext.RobotCartonsInitials
                .AsNoTracking()
                .OrderBy(p => p.Id);

            return await PaginatedList<RobotCartonsInitialListDto>.CreateAsync(query.Select(p => new RobotCartonsInitialListDto
            {
                Id = p.Id,
                AdmissionDate = p.AdmissionDate,
                Purpose = p.Purpose,
                Dn = p.Dn,
                Quantity = p.Quantity,
                Owner = p.Owner
            }).AsQueryable()
            .AsNoTracking(),
            listAsyncQuery.PageIndex,
            listAsyncQuery.PageSize
                );
        }

        public async Task<RobotCartonsInitialDto> GetAsync(GetRobotCartonsInitialQuery query)
        {
            var RobotCartonsInitial = await _dbContext.RobotCartonsInitials
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == query.Id);

            if (RobotCartonsInitial == null)
            {
                throw new CustomException(CustomErrorCode.RobotCartonsInitialNotFound, $"Unable to find Robot Water Meter with id: {query.Id}");
            }

            return new RobotCartonsInitialDto()
            {
                Id = RobotCartonsInitial.Id,
                AdmissionDate = RobotCartonsInitial.AdmissionDate,
                Purpose = RobotCartonsInitial.Purpose,
                Dn = RobotCartonsInitial.Dn,
                Quantity = RobotCartonsInitial.Quantity,
                Owner = RobotCartonsInitial.Owner
            };
        }

    }
}
