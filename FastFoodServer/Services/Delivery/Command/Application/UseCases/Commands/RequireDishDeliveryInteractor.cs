using Application.Abstractions;
using Contracts.Services.Delivery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Commands
{
    public class RequireDishDeliveryInteractor : IInteractor<Command.RequireDishDelivery>
    {
        public Task InteractAsync(Command.RequireDishDelivery message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
