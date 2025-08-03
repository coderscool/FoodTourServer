using Application.Abstractions;
using Application.Services;
using Contracts.Services.Delivery;
using Domain.Aggregates;

namespace Application.UseCases.Commands
{
    public class RequireDishDeliveryInteractor : IInteractor<Command.RequireDishDelivery>
    {
        private readonly IApplicationService _applicationService;
        public RequireDishDeliveryInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Command.RequireDishDelivery command, CancellationToken cancellationToken)
        {
            var delivery = await _applicationService.LoadAggregateAsync<Delivery>(command.ItemId, cancellationToken);
            delivery.Handle(command);
            await _applicationService.AppendEventsAsync(delivery, cancellationToken);
        }
    }
}
