using Application.Abstractions;
using Contracts.Services.Identity;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers.Events
{
    public class CreateAccountUserWhenUserRegisterConsumer : Consumer<DomainEvent.UserRegister>
    {
        public CreateAccountUserWhenUserRegisterConsumer(IInteractor<DomainEvent.UserRegister> interactor) : base(interactor)
        {
        }
    }
}
