using EndLand.Core.CustomExceptions;
using EndLand.Core.Enums;
using EndLand.Data.Models;
using EndLand.Repositories.Interfaces;
using EndLand.Transfer.ProjectsDir.Data;
using EndLand.Transfer.UsersDir.Commands;
using EndLand.Transfer.UsersDir.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EndLand.Repositories.Implementations
{
    public class UserService : IUserService
    {
        private readonly NetLandContext _dbContext;
        public UserService(NetLandContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserDto> CreateAsync(CreateUserCommand command)
        {
            var user = new User
            {
                Name = command.Name,
                PinCode = command.PinCode
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveOrHandleExceptionAsync();

            var userFromDb = await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == user.Id);

            if (userFromDb == null)
            {
                throw new CustomException(CustomErrorCode.UserNotFound, $"Unable to find user with id: {user.Id}");
            }

            return new UserDto
            {
                Id = userFromDb.Id,
                Name = command.Name,
                PinCode = command.PinCode
            };
        }

        public async Task DeleteAsync(DeleteUserCommand command)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == command.Id);

            if (user == null)
            {
                throw new CustomException(CustomErrorCode.UserNotFound, $"Unable to find user with id: {command.Id}");
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveOrHandleExceptionAsync();
        }

        public async Task UpdateAsync(UpdateUserCommand command)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == command.Id);

            if (user == null)
            {
                throw new CustomException(CustomErrorCode.UserNotFound, $"Unable to find user with id: {command.Id}");
            }

            user.Name = command.Name;
            user.PinCode = command.PinCode;

            await _dbContext.SaveOrHandleExceptionAsync();
        }
    }
}
