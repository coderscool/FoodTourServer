﻿using Application.Abstractions;
using Contracts.Services.Order;
using Infrastructure.MessageBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MessageBus.Consumers
{
    public class ConfirmOrderConsumer : Consumer<Command.ConfirmOrder?>
    {
        public ConfirmOrderConsumer(IInteractor<Command.ConfirmOrder?> interactor) : base(interactor)
        {
        }
    }
}
