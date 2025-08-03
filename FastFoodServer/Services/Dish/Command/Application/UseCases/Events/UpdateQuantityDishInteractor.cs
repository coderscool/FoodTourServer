using Application.Abstractions;
using Application.Services;
using Contracts.Services.Dish;
using Domain.Aggregates;
using Order = Contracts.Services.Order;

namespace Application.UseCases.Events
{
    public class UpdateQuantityDishInteractor : IInteractor<Order.SummaryEvent.OrderTransport>
    {
        private readonly IApplicationService _applicationService;
        public UpdateQuantityDishInteractor(IApplicationService applicationService) 
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Order.SummaryEvent.OrderTransport @event, CancellationToken cancellationToken)
        {
            foreach(var item in @event.Order.Group.OrderItem)
            {
                var dish = await _applicationService.LoadAggregateAsync<Dish>(item.DishId, cancellationToken);
                dish.Handle(new Command.UpdateQuantityDish(item.DishId, item.Quantity));
                await _applicationService.AppendEventsAsync(dish, cancellationToken);
            }
        }
    }
}
