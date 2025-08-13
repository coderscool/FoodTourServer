using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Statistic;

namespace Application.UseCases.Events
{
    public interface IUpdateStatisticWhenStatisticChangedInteractor : 
        IInteractor<DomainEvent.StatisticSellerCreate>,
        IInteractor<DomainEvent.NumberDishUpdate>,
        IInteractor<DomainEvent.RevenueUpdate>,
        IInteractor<DomainEvent.NumberOrderUpdate>;
    public class UpdateStatisticWhenStatisticChangedInteractor : IUpdateStatisticWhenStatisticChangedInteractor
    {
        private readonly IProjectionGateway<Projection.StatisticSeller> _projectionGateway;
        public UpdateStatisticWhenStatisticChangedInteractor(IProjectionGateway<Projection.StatisticSeller> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task InteractAsync(DomainEvent.StatisticSellerCreate @event, CancellationToken cancellationToken)
        {
            Projection.StatisticSeller statictic = new (
                @event.Id,
                @event.NumberOrder,
                @event.NumberMeal,
                @event.NumberDish,
                @event.Revenue,
                @event.Version
            );

            await _projectionGateway.ReplaceInsertAsync(statictic, cancellationToken);
        }

        public async Task InteractAsync(DomainEvent.NumberDishUpdate @event, CancellationToken cancellationToken)
            => await _projectionGateway.UpdateFieldAsync(
                id: @event.Id,
                version: @event.Version,
                field: statisticItem => statisticItem.NumberDish,
                value: @event.Quantity,
                cancellationToken: cancellationToken);

        public async Task InteractAsync(DomainEvent.RevenueUpdate @event, CancellationToken cancellationToken)
            => await _projectionGateway.UpdateFieldAsync(
                id: @event.Id,
                version: @event.Version,
                field: paymentItem => paymentItem.Revenue,
                value: @event.Revanue,
                cancellationToken: cancellationToken);

        public async Task InteractAsync(DomainEvent.NumberOrderUpdate @event, CancellationToken cancellationToken)
            => await _projectionGateway.UpdateFieldAsync(
                id: @event.Id,
                version: @event.Version,
                field: paymentItem => paymentItem.NumberOrder,
                value: @event.NumberOrder,
                cancellationToken: cancellationToken);
    }
}
