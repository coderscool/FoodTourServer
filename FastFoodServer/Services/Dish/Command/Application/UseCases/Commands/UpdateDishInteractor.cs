using Application.Abstractions;
using Application.Services;
using Contracts.Services.Dish;
using Domain.Aggregates;

namespace Application.UseCases.Commands
{
    public class UpdateDishInteractor : IInteractor<Command.UpdateDish>
    {
        private readonly IApplicationService _applicationService;
        public UpdateDishInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Command.UpdateDish cmd, CancellationToken cancellationToken)
        {
            var dish = await _applicationService.LoadAggregateAsync<Dish>(cmd.Id, cancellationToken);
            dish.Handle(cmd);
            await _applicationService.AppendEventsAsync(dish, cancellationToken);
        }
    }
}
