using Application.Abstractions;
using Order = Contracts.Services.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Services.Delivery;
using Application.Services;
using Domain.Aggregates;

namespace Application.UseCases.Events
{
    public class UpdateOrderDeliveryWhenOrderCompleteDishInteractor : IInteractor<Order.DomainEvent.OrderCompleteDish>
    {
        private readonly IApplicationService _applicationService;
        public UpdateOrderDeliveryWhenOrderCompleteDishInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Order.DomainEvent.OrderCompleteDish @event, CancellationToken cancellationToken)
        {
            var order = await _applicationService.LoadAggregateAsync<Delivery>(@event.ItemId, cancellationToken);
            order.Handle(new Command.UpdateOrderDelivery(@event.ItemId));
            await _applicationService.AppendEventsAsync(order, cancellationToken);
        }
    }
}
