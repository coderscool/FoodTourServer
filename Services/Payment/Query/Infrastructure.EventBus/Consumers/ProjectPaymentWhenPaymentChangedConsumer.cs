using Application.UseCases.Events;
using Contracts.Services.Payment;
using MassTransit;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectPaymentWhenPaymentChangedConsumer : 
        IConsumer<DomainEvent.PaymentRequest>,
        IConsumer<DomainEvent.PaymentComplete>,
        IConsumer<DomainEvent.PaymentSellerConnfirm>
    {
        private readonly IProjectPaymentWhenPaymentChangedInteractor _interactor;
        public ProjectPaymentWhenPaymentChangedConsumer(IProjectPaymentWhenPaymentChangedInteractor interactor)
        {
            _interactor = interactor;
        }
        public Task Consume(ConsumeContext<DomainEvent.PaymentRequest> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.PaymentComplete> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.PaymentSellerConnfirm> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);
    }
}
