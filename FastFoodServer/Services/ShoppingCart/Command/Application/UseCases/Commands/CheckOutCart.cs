using Application.Abstractions;
using Application.Services;
using Contracts.Services.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands
{
    public class CheckOutCart : IInteractor<Command.CheckOutCart>
    {
        private readonly IApplicationService _applicationService;
        public Task InteractAsync(Command.CheckOutCart message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
