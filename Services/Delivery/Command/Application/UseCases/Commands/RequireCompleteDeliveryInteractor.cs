using Application.Abstractions;
using Application.Services;
using Contracts.Services.Delivery;
using Domain.Aggregates;

namespace Application.UseCases.Commands
{
    public class RequireCompleteDeliveryInteractor : IInteractor<Command.RequireCompleteDelivery>
    {
        private readonly IApplicationService _applicationService;
        public RequireCompleteDeliveryInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Command.RequireCompleteDelivery command, CancellationToken cancellationToken)
        {
            var delivery = await _applicationService.LoadAggregateAsync<Delivery>(command.ItemId, cancellationToken);
            delivery.Handle(command);
            await _applicationService.AppendEventsAsync(delivery, cancellationToken);
        }
    }
}
