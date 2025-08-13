using Application.Abstractions;
using Application.Services;
using Contracts.Services.ShoppingCart;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands
{
    public class CheckOutCartInteractor : IInteractor<Command.CheckOutCart>
    {
        private readonly IApplicationService _applicationService;
        public CheckOutCartInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Command.CheckOutCart command, CancellationToken cancellationToken)
        {
            var cart = await _applicationService.LoadAggregateAsync<ShoppingCart>(command.CartId, cancellationToken);
            cart.Handle(command);
            await _applicationService.AppendEventsAsync(cart, cancellationToken);
        }
    }
}
