using Application.Abstractions;
using Contracts.Services.ShoppingCart;
using Infrastructure.MessageBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MessageBus.Consumers
{
    public class RemoveDishCartConsumer : Consumer<Command.CheckAndRemoveDishCart>
    {
        public RemoveDishCartConsumer(IInteractor<Command.CheckAndRemoveDishCart> interactor) : base(interactor)
        {
        }
    }
}
