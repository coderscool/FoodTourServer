using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Payment;

namespace Application.UseCases.Events
{
    public interface IProjectPaymentWhenPaymentChangedInteractor : 
        IInteractor<DomainEvent.PaymentRequest>,
        IInteractor<DomainEvent.PaymentComplete>,
        IInteractor<DomainEvent.PaymentSellerConnfirm>;
    public class ProjectPaymentWhenPaymentChangedInteractor : IProjectPaymentWhenPaymentChangedInteractor
    {
        private readonly IProjectionGateway<Projection.Payment> _projectionGateway;
        public ProjectPaymentWhenPaymentChangedInteractor(IProjectionGateway<Projection.Payment> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task InteractAsync(DomainEvent.PaymentRequest @event, CancellationToken cancellationToken)
        {
            Projection.Payment payment = new(
                @event.Id,
                @event.OrderId,
                @event.Total,
                @event.PaymentMenthod,
                @event.TransactionId,
                @event.PaymentStatus,
                @event.SellerConfirm,
                @event.PaidAt,
                @event.Version
            );

            await _projectionGateway.ReplaceInsertAsync(payment, cancellationToken);
        }

        public async Task InteractAsync(DomainEvent.PaymentComplete @event, CancellationToken cancellationToken)
            => await _projectionGateway.UpdateFieldAsync(
                id: @event.Id,
                version: @event.Version,
                field: paymentItem => paymentItem.PaymentStatus,
                value: @event.Status,
                cancellationToken: cancellationToken);

        public async Task InteractAsync(DomainEvent.PaymentSellerConnfirm @event, CancellationToken cancellationToken)
            => await _projectionGateway.UpdateFieldAsync(
                id: @event.Id,
                version: @event.Version,
                field: orderItem => orderItem.SellerConfirm,
                value: @event.Confirm,
                cancellationToken: cancellationToken);
    }
}
