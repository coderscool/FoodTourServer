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
    public class CreateRestaurantConsumer : Consumer<Command.CreateRestaurant>
    {
        public CreateRestaurantConsumer(IInteractor<Command.CreateRestaurant> interactor) : base(interactor)
        {
        }
    }
}
