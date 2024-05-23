using Application.Abstractions;
using Application.Services;
using Contracts.Services.Order;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands
{
    public class AddItemOrderInteractor : IInteractor<Command.AddItemOrder>
    {
        private readonly IApplicationService _applicationService;
        public AddItemOrderInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task InteractAsync(Command.AddItemOrder command, CancellationToken cancellationToken)
        {
            var account = await _applicationService.LoadAggregateAsync<Order>(command.Id, cancellationToken);
            account.Handle(command);
            Console.WriteLine(command);
            await _applicationService.AppendEventsAsync(account, cancellationToken);
            account.MarkChangesAsCommitted();
        }
    }
}
