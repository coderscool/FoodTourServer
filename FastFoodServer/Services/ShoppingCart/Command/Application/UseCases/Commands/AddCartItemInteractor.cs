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
    public class AddCartItemInteractor : IInteractor<Command.AddCartItem>
    {
        private readonly IApplicationService _applicationService;
        public AddCartItemInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task InteractAsync(Command.AddCartItem command, CancellationToken cancellationToken)
        {
            ShoppingCart shoppingCart = new();
            shoppingCart.Handle(command);
            await _applicationService.AppendEventsAsync(shoppingCart, cancellationToken);
        }
    }
}
