using Contracts.Abstractions.Messages;
using Contracts.Services.Account;
using Domain.Abstractions.Aggregates;
using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Account : AggregateRoot
    {
        [JsonProperty]
        private readonly List<AccountItem> _items = new();

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.RequestPayment cmd)
        {
            var item = _items.Where(accountItem => accountItem.Id == cmd.Id).FirstOrDefault();  
            if (item != null)
            {
                if(item.Budget >= cmd.Price * cmd.Quantity)
                {
                    RaiseEvent<DomainEvent.PaymentRequest>((version) => new(cmd.Id, cmd.OrderId, cmd.Price, cmd.Quantity, version));
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public void Handle(Command.CreateAccount cmd)
            => RaiseEvent<DomainEvent.AccountCreate>((version) => new(cmd.Id, 0, version));

        public void Handle(Command.RefundPayment cmd)
        {
            var item = _items.Where(accountItem => accountItem.Id == cmd.Id).FirstOrDefault();
            if(item != null)
            {
                RaiseEvent<DomainEvent.PaymentRefund>((version) => new(cmd.Id, cmd.OrderId, cmd.Price, cmd.Quantity, version));
            }
        }
        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.PaymentRequest @event)
            => _items.Single(item => item.Id == @event.AggregateId).Decrease(@event.Quantity, @event.Price);

        public void When(DomainEvent.AccountCreate @event)
            => _items.Add(new(@event.AggregateId, @event.Budget));

        public void When(DomainEvent.PaymentRefund @event)
            => _items.Single(item => item.Id == @event.AggregateId).Increase(@event.Quantity, @event.Price);
    }
}
