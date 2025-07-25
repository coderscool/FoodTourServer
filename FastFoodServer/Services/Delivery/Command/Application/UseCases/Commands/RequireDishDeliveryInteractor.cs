using Application.Abstractions;
using Contracts.Services.Delivery;

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
