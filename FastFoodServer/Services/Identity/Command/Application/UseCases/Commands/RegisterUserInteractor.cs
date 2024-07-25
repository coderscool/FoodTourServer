using Application.Abstractions;
using Application.Services;
using Contracts.Services.Identity;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands
{
    public class RegisterUserInteractor : IInteractor<Command.Register>
    {
        private readonly IApplicationService _applicationService;
        public RegisterUserInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task InteractAsync(Command.Register command, CancellationToken cancellationToken)
        {
            User user = new();
            user.Handle(command);
            await _applicationService.AppendEventsAsync(user, cancellationToken);
        }
    }
}
