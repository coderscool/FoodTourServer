﻿using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Order;

namespace Application.UseCases.Events
{
    public interface IProjectOrderItemWhenOrderChangedInteractor :
        IInteractor<DomainEvent.OrderPlaced>,
        IInteractor<DomainEvent.OrderConfirm>;
    public class ProjectOrderItemWhenOrderChangedInteractor : IProjectOrderItemWhenOrderChangedInteractor
    {
        private readonly IProjectionGateway<Projection.OrderItem> _projectionGateway;
        public ProjectOrderItemWhenOrderChangedInteractor(IProjectionGateway<Projection.OrderItem> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }

        public async Task InteractAsync(DomainEvent.OrderPlaced @event, CancellationToken cancellationToken)
        {
            foreach(var item in @event.Items)
            {
                Projection.OrderItem orderItem = new(item.ItemId, @event.Id, item.RestaurantId, @event.CustomerId, item.DishId,
                    item.Restaurant, @event.Customer, item.Dish, item.Quantity, item.Price, item.Note, item.Status, @event.Date, @event.Version);

                await _projectionGateway.ReplaceInsertAsync(orderItem, cancellationToken);
            }
        }

        public async Task InteractAsync(DomainEvent.OrderConfirm @event, CancellationToken cancellationToken)
            => await _projectionGateway.UpdateFieldAsync(
                id: @event.ItemId,
                version: @event.Version,
                field: orderItem => orderItem.Status,
                value: @event.Status,
                cancellationToken: cancellationToken);
    }
}
