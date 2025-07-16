using Application.Abstractions;
using Application.Services;
using Contracts.Services.Order;
using Domain.Aggregates;

namespace Application.UseCases.Commands
{
    public class CompleteDishOrderInteractor : IInteractor<Command.CompleteDishOrder>
    {
        private readonly IApplicationService _applicationService;
        public CompleteDishOrderInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Command.CompleteDishOrder command, CancellationToken cancellationToken)
        {
            var order = await _applicationService.LoadAggregateAsync<Order>(command.OrderId, cancellationToken);
            order.Handle(command);
            await _applicationService.AppendEventsAsync(order, cancellationToken);
        }
    }
}
