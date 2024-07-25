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
    public class IncreaseQuantityCartInteractor : IInteractor<Command.IncreaseQuantityCart>
    {
        private readonly IApplicationService _applicationService;
        public IncreaseQuantityCartInteractor(IApplicationService applicationService) 
        { 
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Command.IncreaseQuantityCart command, CancellationToken cancellationToken)
        {
            var cart = await _applicationService.LoadAggregateAsync<ShoppingCart>(command.Id, cancellationToken);
            cart.Handle(command);
            await _applicationService.AppendEventsAsync(cart, cancellationToken);
        }
    }
}
