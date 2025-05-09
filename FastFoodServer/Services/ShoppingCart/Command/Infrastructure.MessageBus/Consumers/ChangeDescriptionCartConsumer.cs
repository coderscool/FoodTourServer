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
    public class ChangeDescriptionCartConsumer : Consumer<Command.ChangeDescriptionCart>
    {
        public ChangeDescriptionCartConsumer(IInteractor<Command.ChangeDescriptionCart> interactor) : base(interactor)
        {
        }
    }
}
