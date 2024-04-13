using Application.Abstractions;
using Contracts.Services.Dish;
using Infrastructure.MessageBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MessageBus.Consumers
{
    public class AddDishConsumer : Consumer<Command.CreateDish>
    {
        public AddDishConsumer(IInteractor<Command.CreateDish> interactor) : base(interactor)
        {
        }
    }
}
