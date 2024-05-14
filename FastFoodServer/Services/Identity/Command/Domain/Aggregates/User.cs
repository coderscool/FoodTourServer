using Contracts.Abstractions.Messages;
using Contracts.Services.Dish;
using Domain.Abstractions.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class User : AggregateRoot
    {
        public bool IsActive { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.CreateDish cmd)
            => RaiseEvent<DomainEvent.DishCreate>((version, AggregateId) => new(
                AggregateId, cmd.Dish, ChangeFile(cmd.Image), cmd.Price, cmd.Rate, cmd.Search, version));

        protected override void Apply(IDomainEvent @event)
        {
            throw new NotImplementedException();
        }

        private static byte[] ChangeFile(string file)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(file);
            return bytes;
        }
    }
}
