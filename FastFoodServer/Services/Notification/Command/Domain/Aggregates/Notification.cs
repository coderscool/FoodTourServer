using Contracts.Abstractions.Messages;
using Domain.Abstractions.Aggregates;
using OrderEvent = Contracts.Services.Order.DomainEvent;
using NotificationEvent = Contracts.Services.Notification.DomainEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Notification : AggregateRoot
    {
        public bool IsActive { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }

        public override void Handle(ICommand command)
            => Handle(command as dynamic);

        public override void When(IEvent @event)
            => When(@event as dynamic);

        public void When(OrderEvent.OrderAddItem cmd)
            => RaiseEvent<NotificationEvent.MessageNotification>((version, AggregateId) => new(
                AggregateId, cmd.PersonId, Message(cmd.Person.Name, cmd.Dish.Name, cmd.Amount), string.Empty, cmd.Time, version));

        protected override void Apply(IDomainEvent @event)
        {
            throw new NotImplementedException();
        }

        private string Message(string Name, string Dish, int Amount)
        {
            var sb = new StringBuilder();
            sb.Append(Amount);
            sb.Append(" phần");
            sb.Append(Dish);
            sb.Append(" từ");
            sb.Append(Name);
            return sb.ToString();
        }
    }
}
