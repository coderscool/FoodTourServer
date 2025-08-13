using Application.Abstractions;
using Contracts.Services.Restaurant;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class UpdateRevanueWhenPaymentSellerConfirmConsumer : Consumer<DomainEvent.RestaurantReply>
    {
        public UpdateRevanueWhenPaymentSellerConfirmConsumer(IInteractor<DomainEvent.RestaurantReply> interactor) : base(interactor)
        {
        }
    }
}
