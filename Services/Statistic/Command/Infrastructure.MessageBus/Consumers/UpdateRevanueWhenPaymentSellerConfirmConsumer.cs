using Application.Abstractions;
using Contracts.Services.Payment;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class UpdateRevanueWhenPaymentSellerConfirmConsumer : Consumer<DomainEvent.PaymentSellerConnfirm>
    {
        public UpdateRevanueWhenPaymentSellerConfirmConsumer(IInteractor<DomainEvent.PaymentSellerConnfirm> interactor) : base(interactor)
        {
        }
    }
}
