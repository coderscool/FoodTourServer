using Application.Abstractions;
using Application.Services;
using Contracts.Services.Dish;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands
{
    public class AddDishInteractor : IInteractor<Command.CreateDish>
    {
        private readonly IApplicationService _applicationService;
        public AddDishInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task InteractAsync(Command.CreateDish command, CancellationToken cancellationToken)
        {
            var account = await _applicationService.LoadAggregateAsync<Dish>(command.Id, cancellationToken);
            account.Handle(command);
            Console.WriteLine("--account--");
            Console.WriteLine(command);
            await _applicationService.AppendEventsAsync(account, cancellationToken);
            account.MarkChangesAsCommitted();
        }
    }
}
