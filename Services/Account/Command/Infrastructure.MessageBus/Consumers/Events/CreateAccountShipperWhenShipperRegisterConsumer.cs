using Application.Abstractions;
using Contracts.Services.Identity;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers.Events
{
    public class CreateAccountShipperWhenShipperRegisterConsumer : Consumer<DomainEvent.ShipperRegister>
    {
        public CreateAccountShipperWhenShipperRegisterConsumer(IInteractor<DomainEvent.ShipperRegister> interactor) : base(interactor)
        {
        }
    }
}
