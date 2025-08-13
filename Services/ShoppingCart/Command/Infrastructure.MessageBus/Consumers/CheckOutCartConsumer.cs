﻿using Application.Abstractions;
using Contracts.Services.ShoppingCart;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class CheckOutCartConsumer : Consumer<Command.CheckOutCart>
    {
        public CheckOutCartConsumer(IInteractor<Command.CheckOutCart> interactor) : base(interactor)
        {
        }
    }
}
