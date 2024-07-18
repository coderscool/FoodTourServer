using Contracts.Abstractions.Messages;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Abstractions.Aggregates
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        private readonly List<IDomainEvent> _events = new();

        public long Version { get; private set; }

        public string AggregateId { get; private set; }

        [JsonIgnore]
        public IEnumerable<IDomainEvent> UncommittedEvents
            => _events.AsReadOnly();

        public void MarkChangesAsCommitted()
        {
            _events.Clear();
        }

        public void LoadFromHistory(IEnumerable<IDomainEvent> events)
        {
            foreach (var @event in events)
            {
                Apply(@event);
                Version = @event.Version;
            }
        }

        public abstract void Handle(ICommand command);

        protected void RaiseEvent<TEvent>(Func<long, string, TEvent> func) where TEvent : IDomainEvent
            => RaiseEvent((func as Func<long, string, IDomainEvent>)!);

        protected void RaiseEvent(Func<long, string, IDomainEvent> onRaise)
        {
            Version++;
            AggregateId = ObjectId.GenerateNewId().ToString();
            var @event = onRaise(Version, AggregateId);
            _events.Add(@event);
        }

        protected abstract void Apply(IDomainEvent @event);
    }
}
