using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using Contracts.Services.Dish;
using Domain.Abstractions.Aggregates;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Dish : AggregateRoot
    {
        public bool IsActive { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.CreateDish cmd)
            => RaiseEvent<DomainEvent.DishCreate>((version, AggregateId) => new(
                AggregateId, cmd.PersonId, cmd.Person, cmd.Name, cmd.Image, cmd.Price, cmd.Rate, cmd.Search, version));

        protected override void Apply(IDomainEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
