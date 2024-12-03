using Contracts.Abstractions.Messages;
using Contracts.Services.Notification;
using Domain.Abstractions.Aggregates;
using Domain.Entities;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain.Aggregates
{
    public class Notification : AggregateRoot
    {
        [JsonProperty]
        private readonly List<NotificationItem> _items = new();

        public override void Handle(ICommand command)
            => Handle(command as dynamic);

        public void Handle(Command.NotificationMessage cmd)
            => RaiseEvent<DomainEvent.MessageNotification>((version) => new(
                ObjectId.GenerateNewId().ToString(), cmd.PersonId, cmd.Name, cmd.Message, false, DateTime.UtcNow, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.MessageNotification @event)
                => _items.Add(new(@event.AggregateId, @event.PersonId, @event.Name, @event.Message, @event.Check, @event.Date));
    }
}
