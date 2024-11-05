using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class ProjectAccountWhenPaymentRefundInteractor : IInteractor<DomainEvent.PaymentRefund>
    {
        private readonly IProjectionGateway<Projection.Account> _projectionGateway;
        public ProjectAccountWhenPaymentRefundInteractor(IProjectionGateway<Projection.Account> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task InteractAsync(DomainEvent.PaymentRefund @event, CancellationToken cancellationToken)
        {
            var account = await _projectionGateway.FindAsync(x => x.Id == @event.AggregateId, cancellationToken);
            Console.WriteLine("refund");
            if (account == null)
            {
                throw new ArgumentException("Fail");
            }
            account.Budget += @event.Quantity * @event.Price;
            await _projectionGateway.UpdateFieldAsync(x => x.Id == @event.AggregateId, account, cancellationToken);
        }
    }
}
