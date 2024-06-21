using EndLand.Core.CustomExceptions;
using EndLand.Core.Enums;
using EndLand.Data.Models;
using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ProjectsDir.Data;
using EndLand.Transfer.RobotCartonsInitialDir.Data;
using EndLand.Transfer.Shared.Data;
using EndLand.Transfer.UsersDir.Data;
using EndLand.Transfer.UsersDir.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly NetLandContext _dbContext;
        public UserRepository(NetLandContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDto> GetAsync(GetUserQuery query)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == query.Id);

            if (user == null)
            {
                throw new CustomException(CustomErrorCode.UserNotFound, $"Unable to find user with id: {query.Id}");
            }

            return new UserDto()
            {
                Id = user.Id,
                Name = user.Name,
                PinCode = user.PinCode
            };
        }

        public async Task<PaginatedList<UserListDto>> ListAsync(ListUsersQuery queryListUsers)
        {
            var query = _dbContext.Users
                .AsNoTracking()
                .OrderBy(u => u.Id);

            return await PaginatedList<UserListDto>.CreateAsync(query.Select(u => new UserListDto
            {
                Id = u.Id,
                Name = u.Name,
                PinCode = u.PinCode,
            }).AsQueryable()
            .AsNoTracking(),
            queryListUsers.PageIndex,
            queryListUsers.PageSize
            );
        }
    }
}
