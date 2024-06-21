using EndLand.Transfer.UsersDir.Commands;
using EndLand.Transfer.UsersDir.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(CreateUserCommand command);
        Task UpdateAsync(UpdateUserCommand command);
        Task DeleteAsync(DeleteUserCommand command);
    }
}
