using Application.UseCases.Events;
using Contracts.Services.Statistic;
using MassTransit;

namespace Infrastructure.EventBus.Consumers
{
    public class UpdateStatisticWhenStatisticChangedConsumerConsumer : 
        IConsumer<DomainEvent.NumberDishUpdate>,
        IConsumer<DomainEvent.RevenueUpdate>,
        IConsumer<DomainEvent.NumberOrderUpdate>,
        IConsumer<DomainEvent.StatisticSellerCreate>
    {
        private readonly IUpdateStatisticWhenStatisticChangedInteractor _interactor;
        public UpdateStatisticWhenStatisticChangedConsumerConsumer(IUpdateStatisticWhenStatisticChangedInteractor interactor)
        {
            _interactor = interactor;
        }

        public Task Consume(ConsumeContext<DomainEvent.NumberDishUpdate> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.RevenueUpdate> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.NumberOrderUpdate> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.StatisticSellerCreate> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);
    }
}
