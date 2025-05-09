using Application.Abstractions;
using Identity = Contracts.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Services.Payment;
using Domain.Aggregates;
using Application.Services;

namespace Application.UseCases.Events
{
    public class CreatePaymentWhenRegisterInteractor : IInteractor<Identity.DomainEvent.RegisterEvent>
    {
        private readonly IApplicationService _applicationService;
        public CreatePaymentWhenRegisterInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Identity.DomainEvent.RegisterEvent @event, CancellationToken cancellationToken)
        {
            Payment payment = new();
            payment.Handle(new Command.CreatePayment(@event.Id));
            await _applicationService.AppendEventsAsync(payment, cancellationToken);
        }
    }
}
