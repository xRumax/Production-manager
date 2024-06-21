using EndLand.Repositories.Interfaces;
using EndLand.Transfer.UsersDir.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EndLand.Repositories.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserService _userService;
        private readonly ILogger<UpdateUserHandler> _logger;

        public UpdateUserHandler(IUserService userService, ILogger<UpdateUserHandler> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogError("Operation was cancelled.");
                throw new OperationCanceledException("Operation was cancelled.");
            }

            await _userService.UpdateAsync(request);
        }
    }
}
