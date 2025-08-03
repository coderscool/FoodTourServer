using Application.Abstractions;
using Application.Services;
using Contracts.Services.Dish;
using Domain.Aggregates;

namespace Application.UseCases.Commands
{
    public class HiddenDishInteractor : IInteractor<Command.HiddenDish>
    {
        private readonly IApplicationService _applicationService;
        public HiddenDishInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Command.HiddenDish command, CancellationToken cancellationToken)
        {
            var dish = await _applicationService.LoadAggregateAsync<Dish>(command.Id, cancellationToken);
            dish.Handle(command);
            await _applicationService.AppendEventsAsync(dish, cancellationToken);
        }
    }
}
