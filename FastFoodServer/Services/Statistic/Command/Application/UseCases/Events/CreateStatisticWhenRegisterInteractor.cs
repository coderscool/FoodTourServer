using Application.Abstractions;
using Contracts.Services.Statistic;
using Identity = Contracts.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Aggregates;
using Application.Services;

namespace Application.UseCases.Events
{
    public class CreateStatisticWhenRegisterInteractor : IInteractor<Identity.DomainEvent.RegisterEvent>
    {
        private readonly IApplicationService _applicationService;
        public CreateStatisticWhenRegisterInteractor(IApplicationService applicationService) 
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Identity.DomainEvent.RegisterEvent @event, CancellationToken cancellationToken)
        {
            if(@event.Role == "sale")
            {
                Statistic statistic = new();
                statistic.Handle(new Command.CreateStatistic(@event.AggregateId));
                await _applicationService.AppendEventsAsync(statistic, cancellationToken);
            }
        }
    }
}
