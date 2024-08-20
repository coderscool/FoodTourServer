using Application.Abstractions;
using Restaurant = Contracts.Services.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Domain.Aggregates;
using Contracts.Services.Account;

namespace Application.UseCases.Events
{
    public class ChangeAccountWhenRestaurantReply : IInteractor<Restaurant.DomainEvent.RestaurantReply>
    {
        private readonly IApplicationService _applicationService;
        public ChangeAccountWhenRestaurantReply(IApplicationService applicationService) 
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Restaurant.DomainEvent.RestaurantReply @event, CancellationToken cancellationToken)
        {
            if(@event.Status == true)
            {
                var account = await _applicationService.LoadAggregateAsync<Account>(@event.RestaurantId, cancellationToken);
                account.Handle(new Command.RefundPayment(@event.RestaurantId, @event.AggregateId, @event.Price));
                await _applicationService.AppendEventsAsync(account, cancellationToken);
            }
            else
            {
                var account = await _applicationService.LoadAggregateAsync<Account>(@event.CustomerId, cancellationToken);
                account.Handle(new Command.RefundPayment(@event.CustomerId, @event.AggregateId, @event.Price));
                await _applicationService.AppendEventsAsync(account, cancellationToken);
            }
        }
    }
}
