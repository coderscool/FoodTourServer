using Application.Abstractions;
using Contracts.Services.Order;
using Infrastructure.MessageBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MessageBus.Consumers
{
    public class AddItemOderConsumer : Consumer<Command.AddItemOrder>
    {
        public AddItemOderConsumer(IInteractor<Command.AddItemOrder> interactor) : base(interactor)
        {
        }
    }
}
