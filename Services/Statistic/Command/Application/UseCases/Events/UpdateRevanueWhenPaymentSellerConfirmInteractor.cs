using Application.Abstractions;
using Payment = Contracts.Services.Payment;
using Contracts.Services.Statistic;
using Application.Services;
using Domain.Aggregates;

namespace Application.UseCases.Events
{
    public class UpdateRevanueWhenPaymentSellerConfirmInteractor : IInteractor<Payment.DomainEvent.PaymentSellerConnfirm>
    {
        private readonly IApplicationService _applicationService;
        public UpdateRevanueWhenPaymentSellerConfirmInteractor(IApplicationService applicationService) 
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Payment.DomainEvent.PaymentSellerConnfirm @event, CancellationToken cancellationToken)
        {
            if(@event.Confirm == true)
            {
                var statistic = await _applicationService.LoadAggregateAsync<StatisticSeller>(@event.RestaurantId, cancellationToken);
                statistic.Handle(new Command.UpdateRevanue(@event.RestaurantId, @event.Total));
                await _applicationService.AppendEventsAsync(statistic, cancellationToken);
            }
        }
    }
}
