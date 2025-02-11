using Application.Abstractions;
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
    public class CreateRestaurantInteractor : IInteractor<Command.CreateRestaurant>
    {
        private readonly IApplicationService _applicationService;
        public CreateRestaurantInteractor(IApplicationService applicationService) 
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Command.CreateRestaurant command, CancellationToken cancellationToken)
        {
            Restaurant restaurant = new();
            restaurant.Handle(command);
            await _applicationService.AppendEventsAsync(restaurant, cancellationToken);
        }
    }
}
