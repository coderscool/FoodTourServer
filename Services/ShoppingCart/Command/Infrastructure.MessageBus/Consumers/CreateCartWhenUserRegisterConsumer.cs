using Application.Abstractions;
using Contracts.Services.Identity;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class CreateCartWhenUserRegisterConsumer : Consumer<DomainEvent.UserRegister>
    {
        public CreateCartWhenUserRegisterConsumer(IInteractor<DomainEvent.UserRegister> interactor) : base(interactor)
        {
        }
    }
}
