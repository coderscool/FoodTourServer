using Application.Abstractions;
using Contracts.Services.Account;
using Infrastructure.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectAccountWhenPaymentRequestConsumer : Consumer<DomainEvent.PaymentRequest>
    {
        public ProjectAccountWhenPaymentRequestConsumer(IInteractor<DomainEvent.PaymentRequest> interactor) : base(interactor)
        {
        }
    }
}
