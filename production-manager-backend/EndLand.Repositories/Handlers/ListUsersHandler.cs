using EndLand.Repositories.Interfaces;
using EndLand.Transfer.Shared.Data;
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
    public class ListUsersHandler : IRequestHandler<ListUsersQuery, PaginatedList<UserListDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ListUsersHandler> _logger;

        public ListUsersHandler(IUserRepository userRepository, ILogger<ListUsersHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<PaginatedList<UserListDto>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }
            return await _userRepository.ListAsync(request);
        }
    }
}
