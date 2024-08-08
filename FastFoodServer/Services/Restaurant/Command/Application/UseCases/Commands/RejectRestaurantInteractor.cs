using Application.Abstractions;
using Application.BackgroundJobs;
using Application.Services;
using Contracts.Services.Restaurant;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands
{
    public class RejectRestaurantInteractor : IInteractor<Command.RejectRestaurant>
    {
        private readonly IApplicationService _applicationService;
        private readonly IScheduleNotification _scheduleNotification;
        public RejectRestaurantInteractor(IApplicationService applicationService,
            IScheduleNotification scheduleNotification)
        {
            _applicationService = applicationService;
            _scheduleNotification = scheduleNotification;
        }
        public async Task InteractAsync(Command.RejectRestaurant command, CancellationToken cancellationToken)
        {
            var restaurant = await _applicationService.LoadAggregateAsync<Restaurant>(command.Id, cancellationToken);
            restaurant.Handle(command);
            await _scheduleNotification.RemoveSchedule(command.Id);
            await _applicationService.AppendEventsAsync(restaurant, cancellationToken);
        }
    }
}
