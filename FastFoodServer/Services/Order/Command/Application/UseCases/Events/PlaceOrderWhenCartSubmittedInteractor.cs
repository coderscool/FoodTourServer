﻿using Application.Abstractions;
using Application.Services;
using Contracts.Services.Order;
using Domain.Aggregates;
using ShoppingCart = Contracts.Services.ShoppingCart;


namespace Application.UseCases.Events
{
    public class PlaceOrderWhenCartSubmittedInteractor : IInteractor<ShoppingCart.SummaryEvent.CartSubmitted>
    {
        private readonly IApplicationService _applicationService;
        public PlaceOrderWhenCartSubmittedInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(ShoppingCart.SummaryEvent.CartSubmitted @event, CancellationToken cancellationToken)
        {
            Order order = new();

            var command = new Command.PlaceOrder(
                @event.Cart.CustomerId,
                @event.Customer,
                @event.Total,
                @event.PaymentMethod,
                @event.Cart.Items);

            order.Handle(command);

            await _applicationService.AppendEventsAsync(order, cancellationToken);
        }
    }
}
