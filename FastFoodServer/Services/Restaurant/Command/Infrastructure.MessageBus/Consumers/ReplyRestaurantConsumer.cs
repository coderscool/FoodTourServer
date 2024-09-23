using Application.Abstractions;
using Contracts.Services.Restaurant;
using Infrastructure.MessageBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MessageBus.Consumers
{
    public class ReplyRestaurantConsumer : Consumer<Command.ReplyRestaurant>
    {
        public ReplyRestaurantConsumer(IInteractor<Command.ReplyRestaurant> interactor) : base(interactor)
        {
        }
    }
}
