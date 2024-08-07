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
    public class RequestRestaurantWhenPaymentRequestConsumer : Consumer<DomainEvent.OrderConfirm>
    {
        public RequestRestaurantWhenPaymentRequestConsumer(IInteractor<DomainEvent.OrderConfirm> interactor) : base(interactor)
        {
        }
    }
}
