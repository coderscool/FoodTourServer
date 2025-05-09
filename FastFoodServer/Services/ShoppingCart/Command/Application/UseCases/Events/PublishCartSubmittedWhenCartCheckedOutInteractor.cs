﻿using Application.Abstractions;
using Application.Services;
using Contracts.Services.ShoppingCart;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class PublishCartSubmittedWhenCartCheckedOutInteractor : IInteractor<DomainEvent.CartCheckedOut>
    {
        private readonly IApplicationService _applicationService;
        public PublishCartSubmittedWhenCartCheckedOutInteractor(IApplicationService applicationService) 
        { 
            _applicationService = applicationService;
        }
        public async Task InteractAsync(DomainEvent.CartCheckedOut @event, CancellationToken cancellationToken)
        {
            var shoppingCart = await _applicationService.LoadAggregateAsync<ShoppingCart>(@event.CartId, cancellationToken);
            SummaryEvent.CartSubmitted cartSubmitted = new(shoppingCart, shoppingCart.Version);
            await _applicationService.PublishEventAsync(cartSubmitted, cancellationToken);
        }
    }
}
