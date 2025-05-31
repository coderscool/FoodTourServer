using Application.Abstractions;
using Application.Services;
using Contracts.Services.Dish;
using Domain.Aggregates;

namespace Application.UseCases.Commands
{
    public class UpdatePriceDishInteractor : IInteractor<Command.UpdatePriceDish>
    {
        private readonly IApplicationService _applicationService;
        public UpdatePriceDishInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Command.UpdatePriceDish cmd, CancellationToken cancellationToken)
        {
            var dish = await _applicationService.LoadAggregateAsync<Dish>(cmd.Id, cancellationToken);
            dish.Handle(cmd);
            await _applicationService.AppendEventsAsync(dish, cancellationToken);
        }
    }
}
