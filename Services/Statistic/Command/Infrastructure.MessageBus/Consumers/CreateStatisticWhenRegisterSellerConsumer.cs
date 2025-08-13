using Application.Abstractions;
using Contracts.Services.Identity;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class CreateStatisticWhenRegisterSellerConsumer : Consumer<DomainEvent.SellerRegister>
    {
        public CreateStatisticWhenRegisterSellerConsumer(IInteractor<DomainEvent.SellerRegister> interactor) : base(interactor)
        {
        }
    }
}
