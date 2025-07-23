using Application.Abstractions;
using Contracts.Services.ShoppingCart;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class PublishCartSubmittedWhenCartCheckedOutConsumer : Consumer<DomainEvent.CartCheckedOut>
    {
        public PublishCartSubmittedWhenCartCheckedOutConsumer(IInteractor<DomainEvent.CartCheckedOut> interactor) : base(interactor)
        {
        }
    }
}
