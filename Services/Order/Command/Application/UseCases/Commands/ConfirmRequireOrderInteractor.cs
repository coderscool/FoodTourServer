using Application.Abstractions;
using Application.Services;
using Contracts.Services.Order;
using Domain.Aggregates;

namespace Application.UseCases.Commands
{
    public class ConfirmRequireOrderInteractor : IInteractor<Command.ConfirmRequireOrder>
    {
        private readonly IApplicationService _applicationService;
        public ConfirmRequireOrderInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Command.ConfirmRequireOrder command, CancellationToken cancellationToken)
        {
            var order = await _applicationService.LoadAggregateAsync<Order>(command.OrderId, cancellationToken);
            order.Handle(command);
            await _applicationService.AppendEventsAsync(order, cancellationToken);
        }
    }
}
