using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Dish;
using Nest;
using System.Linq.Expressions;

namespace Application.UseCases.Events
{
    public interface IProjectDishWhenDishChangedInteractor : 
        IInteractor<DomainEvent.DishCreate>,
        IInteractor<DomainEvent.DishUpdate>,
        IInteractor<DomainEvent.DishHidden>,
        IInteractor<DomainEvent.DishQuantityUpdate>;
 
    public class ProjectDishWhenDishChangedInteractor : IProjectDishWhenDishChangedInteractor
    {
        private readonly IProjectionGateway<Projection.Dishs> _projectionGateway;
        private readonly IElasticSearchGateway<Projection.Dishs> _elasticSearchGateway;

        public ProjectDishWhenDishChangedInteractor(IProjectionGateway<Projection.Dishs> projectionGateway,
            IElasticSearchGateway<Projection.Dishs> elasticSearchGateway)
        {
            _projectionGateway = projectionGateway;
            _elasticSearchGateway = elasticSearchGateway;
        }

        public async Task InteractAsync(DomainEvent.DishCreate @event, CancellationToken cancellationToken)
        {
            Projection.Dishs dish = new (
                @event.Id, 
                @event.RestaurantId, 
                @event.Dish, 
                @event.Extra,
                @event.Price, 
                @event.Quantity, 
                @event.Search, 
                false,
                @event.Version);
            await _projectionGateway.ReplaceInsertAsync(dish, cancellationToken);
            await _elasticSearchGateway.InsertDocumentAsync(dish);
        }

        public async Task InteractAsync(DomainEvent.DishUpdate @event, CancellationToken cancellationToken)
        {
            await _projectionGateway.UpdateFieldsAsync(
                id: @event.Id,
                version: @event.Version,
                updates: new (Expression<Func<Projection.Dishs, object>>, object)[]
                {
                    (x => x.Dish, @event.Dish),
                    (x => x.Price, @event.Price),
                    (x => x.Extra, @event.Extra)
                },
                cancellationToken);

            await _elasticSearchGateway.UpdateFieldsAsync
            (
                @event.Id,
                updates: new Dictionary<string, object>
                {
                    { nameof(Projection.Dishs.Dish), @event.Dish },
                    { nameof(Projection.Dishs.Price), @event.Price }
                },
                cancellationToken: cancellationToken
            );
        }

        public async Task InteractAsync(DomainEvent.DishHidden @event, CancellationToken cancellationToken)
        {
            await _projectionGateway.UpdateFieldAsync(
                id: @event.Id,
                version: @event.Version,
                field: dish => dish.Hidden,
                value: @event.Hidden,
                cancellationToken: cancellationToken);

            await _elasticSearchGateway.UpdateFieldsAsync
            (
                @event.Id,
                updates: new Dictionary<string, object>
                {
                    { nameof(Projection.Dishs.Hidden), @event.Hidden }
                },
                cancellationToken: cancellationToken
            );
        }

        public async Task InteractAsync(DomainEvent.DishQuantityUpdate @event, CancellationToken cancellationToken)
            => await _projectionGateway.UpdateFieldAsync(
                id: @event.Id,
                version: @event.Version,
                field: dish => dish.Quantity,
                value: @event.Quantity,
                cancellationToken: cancellationToken);
    }
}
