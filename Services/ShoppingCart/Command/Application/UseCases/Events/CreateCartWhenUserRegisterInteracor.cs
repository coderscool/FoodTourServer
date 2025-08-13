using Application.Abstractions;
using Application.Services;
using Contracts.Services.ShoppingCart;
using Domain.Aggregates;
using Identity = Contracts.Services.Identity;

namespace Application.UseCases.Events
{
    public class CreateCartWhenUserRegisterInteracor : IInteractor<Identity.DomainEvent.UserRegister>
    {
        private readonly IApplicationService _applicationService;
        public CreateCartWhenUserRegisterInteracor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Identity.DomainEvent.UserRegister @event, CancellationToken cancellationToken)
        {
            ShoppingCart shoppingCart = new();
            shoppingCart.Handle(new Command.CreateCart(@event.Id));
            await _applicationService.AppendEventsAsync(shoppingCart, cancellationToken);
        }
    }
}
