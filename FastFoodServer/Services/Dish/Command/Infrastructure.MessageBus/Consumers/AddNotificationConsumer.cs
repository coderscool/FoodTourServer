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
    public class AddNotificationConsumer : Consumer<DomainEvent.OrderAddItem>
    {
        public AddNotificationConsumer(IInteractor<DomainEvent.OrderAddItem> interactor) : base(interactor)
        {
        }
    }
}
