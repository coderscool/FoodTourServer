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
    public class CreateStatisticWhenRegisterSellerInteractor : IInteractor<Identity.DomainEvent.SellerRegister>
    {
        private readonly IApplicationService _applicationService;
        public CreateStatisticWhenRegisterSellerInteractor(IApplicationService applicationService) 
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Identity.DomainEvent.SellerRegister @event, CancellationToken cancellationToken)
        {
            StatisticSeller statistic = new();
            statistic.Handle(new Command.CreateSellerStatistic(@event.Id));
            await _applicationService.AppendEventsAsync(statistic, cancellationToken);
        }
    }
}
