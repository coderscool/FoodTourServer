using Application.Abstractions;
using Application.Services;
using Order = Contracts.Services.Order;
using Domain.Aggregates;
using Contracts.Services.Payment;

namespace Application.UseCases.Events
{
    public class RequestPaymentWhenOrderPlacedInteractor : IInteractor<Order.DomainEvent.OrderPlaced>
    {
        private readonly IApplicationService _applicationService;
        public RequestPaymentWhenOrderPlacedInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Order.DomainEvent.OrderPlaced @event, CancellationToken cancellationToken)
        {
            foreach(var item in @event.Items)
            {
                Payment payment = new();
                payment.Handle(new Command.RequestPayment(item.ItemId, item.Price, item.Quantity, @event.PaymentMethod));
                await _applicationService.AppendEventsAsync(payment, cancellationToken);
            }
        }
    }
}
