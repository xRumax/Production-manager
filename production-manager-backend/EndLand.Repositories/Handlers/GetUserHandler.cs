using EndLand.Repositories.Interfaces;
using EndLand.Transfer.UsersDir.Data;
using EndLand.Transfer.UsersDir.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndLand.Repositories.Handlers
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<GetUserHandler> _logger;

        public GetUserHandler(IUserRepository userRepository, ILogger<GetUserHandler> logger) 
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }
            return await _userRepository.GetAsync(request);
        }
    }
}
