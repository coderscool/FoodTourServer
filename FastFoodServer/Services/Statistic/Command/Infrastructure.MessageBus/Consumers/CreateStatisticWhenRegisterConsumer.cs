using Application.Abstractions;
using Contracts.Services.Identity;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class CreateStatisticWhenRegisterConsumer : Consumer<DomainEvent.SellerRegister>
    {
        public CreateStatisticWhenRegisterConsumer(IInteractor<DomainEvent.SellerRegister> interactor) : base(interactor)
        {
        }
    }
}
