using Application.Abstractions;
using Contracts.Services.Identity;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers.Events
{
    public class CreateAccountSellerWhenSellerRegisterConsumer : Consumer<DomainEvent.SellerRegister>
    {
        public CreateAccountSellerWhenSellerRegisterConsumer(IInteractor<DomainEvent.SellerRegister> interactor) : base(interactor)
        {
        }
    }
}
