using Application.Abstractions;
using Contracts.Services.Delivery;
using Infrastructure.MessageBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MessageBus.Consumers
{
    public class CreateDeliveryWhenOrderTransportConsumer : Consumer<Command.CreateDelivery>
    {
        public CreateDeliveryWhenOrderTransportConsumer(IInteractor<Command.CreateDelivery> interactor) : base(interactor)
        {
        }
    }
}
