using Application.Abstractions;
using Application.Services;
using Contracts.Services.Identity;
using Domain.Aggregates;

namespace Application.UseCases.Commands
{
    public class RegisterShipperInteractor : IInteractor<Command.RegisterShipper>
    {
        private readonly IApplicationService _applicationService;
        public RegisterShipperInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task InteractAsync(Command.RegisterShipper command, CancellationToken cancellationToken)
        {
            Identity user = new();
            user.Handle(command);
            await _applicationService.AppendEventsAsync(user, cancellationToken);
        }
    }
}
