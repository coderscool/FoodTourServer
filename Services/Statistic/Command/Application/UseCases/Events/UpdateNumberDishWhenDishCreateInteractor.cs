using Application.Abstractions;
using Dish = Contracts.Services.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Services.Statistic;
using Application.Services;
using Domain.Aggregates;

namespace Application.UseCases.Events
{
    public class UpdateNumberDishWhenDishCreateInteractor : IInteractor<Dish.DomainEvent.DishCreate>
    {
        private readonly IApplicationService _applicationService;
        public UpdateNumberDishWhenDishCreateInteractor(IApplicationService applicationService) 
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Dish.DomainEvent.DishCreate @event, CancellationToken cancellationToken)
        {
            var statistic = await _applicationService.LoadAggregateAsync<StatisticSeller>(@event.RestaurantId, cancellationToken);
            statistic.Handle(new Command.UpdateNumberDish(@event.RestaurantId));
            await _applicationService.AppendEventsAsync(statistic, cancellationToken);
        }
    }
}
