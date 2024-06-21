using EndLand.Transfer.UsersDir.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Transfer.UsersDir.Commands
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string Name { get; set; } = null!;
        public string PinCode { get; set; } = null!;
    }
}
