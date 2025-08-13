using Application.Abstractions;
using Application.Services;
using Contracts.Services.Identity;
using Domain.Aggregates;

namespace Application.UseCases.Commands
{
    public class RegisterSellerInteractor : IInteractor<Command.RegisterSeller>
    {
        private readonly IApplicationService _applicationService;
        public RegisterSellerInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task InteractAsync(Command.RegisterSeller command, CancellationToken cancellationToken)
        {
            Identity user = new();
            user.Handle(command);
            await _applicationService.AppendEventsAsync(user, cancellationToken);
        }
    }
}
