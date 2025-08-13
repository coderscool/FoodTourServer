using Application.Abstractions;
using Application.Services;
using Contracts.Services.Delivery;
using Domain.Aggregates;

namespace Application.UseCases.Commands
{
    public class AddShipperDeliveryInteractor : IInteractor<Command.AddShipperDelivery>
    {
        private readonly IApplicationService _applicationService;
        public AddShipperDeliveryInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Command.AddShipperDelivery command, CancellationToken cancellationToken)
        {
            var delivery = await _applicationService.LoadAggregateAsync<Delivery>(command.DeliveryId, cancellationToken);
            delivery.Handle(command);
            await _applicationService.AppendEventsAsync(delivery, cancellationToken);
        }
    }
}
