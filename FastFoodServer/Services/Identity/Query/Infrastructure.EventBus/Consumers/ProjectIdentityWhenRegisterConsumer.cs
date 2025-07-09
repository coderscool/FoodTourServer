using Application.UseCases.Events;
using Contracts.Services.Identity;
using MassTransit;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectIdentityWhenRegisterConsumer : 
        IConsumer<DomainEvent.UserRegister>,
        IConsumer<DomainEvent.SellerRegister>,
        IConsumer<DomainEvent.ShipperRegister>
    {
        private readonly IProjectIdentityWhenRegisterInteractor _interactor;
        public ProjectIdentityWhenRegisterConsumer(IProjectIdentityWhenRegisterInteractor interactor)
        {
            _interactor = interactor;
        }
        public async Task Consume(ConsumeContext<DomainEvent.UserRegister> context)
            => await _interactor.InteractAsync(context.Message, context.CancellationToken);

        public async Task Consume(ConsumeContext<DomainEvent.SellerRegister> context)
            => await _interactor.InteractAsync(context.Message, context.CancellationToken);

        public async Task Consume(ConsumeContext<DomainEvent.ShipperRegister> context)
            => await _interactor.InteractAsync(context.Message, context.CancellationToken);
    }
}
