using Application.UseCases.Events;
using Contracts.Services.Dish;
using MassTransit;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectDishWhenDishChangedConsumer :
        IConsumer<DomainEvent.DishCreate>,
        IConsumer<DomainEvent.DishUpdate>,
        IConsumer<DomainEvent.DishHidden>,
        IConsumer<DomainEvent.DishQuantityUpdate>
    {
        private readonly IProjectDishWhenDishChangedInteractor _interactor;
        public ProjectDishWhenDishChangedConsumer(IProjectDishWhenDishChangedInteractor interactor)
        {
            _interactor = interactor;
        }
        public Task Consume(ConsumeContext<DomainEvent.DishCreate> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.DishUpdate> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.DishHidden> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.DishQuantityUpdate> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);
    }
}
