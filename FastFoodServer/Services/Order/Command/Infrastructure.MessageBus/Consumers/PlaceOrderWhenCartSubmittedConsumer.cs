using Application.Abstractions;
using Contracts.Services.ShoppingCart;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class PlaceOrderWhenCartSubmittedConsumer : Consumer<SummaryEvent.CartSubmitted>
    {
        public PlaceOrderWhenCartSubmittedConsumer(IInteractor<SummaryEvent.CartSubmitted> interactor) : base(interactor)
        {
        }
    }
}
