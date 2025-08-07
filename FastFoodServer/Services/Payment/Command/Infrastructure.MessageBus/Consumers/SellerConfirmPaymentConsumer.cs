using Application.Abstractions;
using Contracts.Services.Payment;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class SellerConfirmPaymentConsumer : Consumer<Command.SellerConfirmPayment>
    {
        public SellerConfirmPaymentConsumer(IInteractor<Command.SellerConfirmPayment> interactor) : base(interactor)
        {
        }
    }
}
