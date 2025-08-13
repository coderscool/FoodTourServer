using Application.Abstractions;
using Contracts.Services.Payment;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    internal class CompletePaymentConsumer : Consumer<Command.CompletePayment>
    {
        public CompletePaymentConsumer(IInteractor<Command.CompletePayment> interactor) : base(interactor)
        {
        }
    }
}
