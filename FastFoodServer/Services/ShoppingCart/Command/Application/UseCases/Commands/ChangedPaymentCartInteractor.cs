using Application.Abstractions;
using Contracts.Services.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands
{
    public class ChangedPaymentCartInteractor : IInteractor<Command.ChangedPaymentCart>
    {
        public Task InteractAsync(Command.ChangedPaymentCart message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
