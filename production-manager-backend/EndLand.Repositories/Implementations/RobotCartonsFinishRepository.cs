using EndLand.Core.CustomExceptions;
using EndLand.Data.Models;
using EndLand.Repositories.Interfaces;
using EndLand.Transfer.RobotCartonsFinishDir.Data;
using EndLand.Transfer.RobotCartonsFinishDir.Queries;
using EndLand.Transfer.Shared.Data;
using Microsoft.EntityFrameworkCore;
using System;
using EndLand.Core.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Implementations
{
    public class RobotCartonsFinishRepository : IRobotCartonsFinishRepository
    {
        private readonly NetLandContext _dbContext;

        public RobotCartonsFinishRepository(NetLandContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PaginatedList<RobotCartonsFinishListDto>> ListAsync(ListRobotCartonsFinishQuery listAsyncQuery)
        {
            var query = _dbContext.RobotCartonsFinishes
                .AsNoTracking()
                .OrderBy(p => p.Id);

            return await PaginatedList<RobotCartonsFinishListDto>.CreateAsync(query.Select(p => new RobotCartonsFinishListDto
            {
                Id = p.Id,
                AdmissionDate = p.AdmissionDate,
                Purpose = p.Purpose,
                Quantity = p.Quantity,
                TestResult = p.TestResult,
                Owner = p.Owner,
                FullCarton = p.FullCarton,
            }).AsQueryable()
            .AsNoTracking(),
            listAsyncQuery.PageIndex,
            listAsyncQuery.PageSize);
        }

        public async Task<RobotCartonsFinishDto> GetAsync(GetRobotCartonsFinishQuery query)
        {
            var robotCartonsFinish = await _dbContext.RobotCartonsFinishes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == query.Id);

            if(robotCartonsFinish == null)
            {
                throw new CustomException(CustomErrorCode.RobotCartonsFinishNotFound, $"Unable to find Robot Cartons Finish with id: {query.Id}");
            }
            return new RobotCartonsFinishDto
            {
                Id = robotCartonsFinish.Id,
                AdmissionDate = robotCartonsFinish.AdmissionDate,
                Purpose = robotCartonsFinish.Purpose,
                Dn = robotCartonsFinish.Dn,
                Quantity = robotCartonsFinish.Quantity,
                MinPixelCount = robotCartonsFinish.MinPixelCount,
                MaxPixelCount = robotCartonsFinish.MaxPixelCount,
                Q3 = robotCartonsFinish.Q3,
                TestResult = robotCartonsFinish.TestResult,
                Owner = robotCartonsFinish.Owner,
                FullCarton = robotCartonsFinish.FullCarton,
            };
        }
    }
}
