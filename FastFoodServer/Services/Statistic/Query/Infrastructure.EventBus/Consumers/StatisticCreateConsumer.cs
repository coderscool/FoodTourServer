using Application.Abstractions;
using Contracts.Services.Statistic;
using Infrastructure.EventBus.Abstractions;

namespace Infrastructure.EventBus.Consumers
{
    public class StatisticCreateConsumer : Consumer<DomainEvent.StatisticSellerCreate>
    {
        public StatisticCreateConsumer(IInteractor<DomainEvent.StatisticSellerCreate> interactor) : base(interactor)
        {
        }
    }
}
