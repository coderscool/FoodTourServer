using Application.Abstractions;
using Application.Services;
using Contracts.Services.Statistic;
using Domain.Aggregates;
using Order = Contracts.Services.Order;

namespace Application.UseCases.Events
{
    public class UpdateNumberOrderWhenOrderTransportInteractor : IInteractor<Order.SummaryEvent.OrderTransport>
    {
        private readonly IApplicationService _applicationService;
        public UpdateNumberOrderWhenOrderTransportInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Order.SummaryEvent.OrderTransport @event, CancellationToken cancellationToken)
        {
            var statistic = await _applicationService.LoadAggregateAsync<StatisticSeller>(@event.Order.Group.RestaurantId, cancellationToken);
            statistic.Handle(new Command.UpdateNumberOrder(@event.Order.Group.RestaurantId, 1));
            await _applicationService.AppendEventsAsync(statistic, cancellationToken);
        }
    }
}
