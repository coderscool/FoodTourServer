using Application.Abstractions;
using Contracts.Services.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class RevenueUpdateInteractor : IInteractor<DomainEvent.RevenueUpdate>
    {
        public Task InteractAsync(DomainEvent.RevenueUpdate @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
