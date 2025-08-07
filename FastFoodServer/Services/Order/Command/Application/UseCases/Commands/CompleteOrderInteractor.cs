using Application.Abstractions;
using Application.Services;
using Contracts.Services.Order;
using Domain.Aggregates;

namespace Application.UseCases.Commands
{
    public class CompleteOrderInteractor : IInteractor<Command.CompleteOrder>
    {
        private readonly IApplicationService _applicationService;
        public CompleteOrderInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Command.CompleteOrder command, CancellationToken cancellationToken)
        {
            var order = await _applicationService.LoadAggregateAsync<Order>(command.OrderId, cancellationToken);
            order.Handle(command);
            await _applicationService.AppendEventsAsync(order, cancellationToken);
        }
    }
}
