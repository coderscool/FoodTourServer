using Application.Abstractions;
using Contracts.Services.Statistic;
using Infrastructure.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventBus.Consumers
{
    public class RevenueUpdateConsumer : Consumer<DomainEvent.RevenueUpdate>
    {
        public RevenueUpdateConsumer(IInteractor<DomainEvent.RevenueUpdate> interactor) : base(interactor)
        {
        }
    }
}
