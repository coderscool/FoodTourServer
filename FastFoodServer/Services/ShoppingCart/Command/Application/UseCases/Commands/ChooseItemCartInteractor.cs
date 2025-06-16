using Application.Abstractions;
using Contracts.Services.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands
{
    public class ChooseItemCartInteractor : IInteractor<Command.ChooseItemCart>
    {
        public Task InteractAsync(Command.ChooseItemCart message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
