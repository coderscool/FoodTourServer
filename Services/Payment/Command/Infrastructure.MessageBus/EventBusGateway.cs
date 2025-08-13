using Application.Abstractions.Gateways;
using Contracts.Abstractions.Messages;
using MassTransit;

namespace Infrastructure.MessageBus
{
    public class EventBusGateway : IEventBusGateway
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public EventBusGateway(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public Task PublishAsync(IEnumerable<IEvent> events, CancellationToken cancellationToken)
        {
            Task.WhenAll(events.Select(@event => _publishEndpoint.Publish(@event, @event.GetType(), cancellationToken)));
            Console.WriteLine("publish success");
            return Task.CompletedTask;
        }

        public Task PublishAsync(IDomainEvent @event, CancellationToken cancellationToken)
            => _publishEndpoint.Publish(@event, @event.GetType(), cancellationToken);
    }
}
