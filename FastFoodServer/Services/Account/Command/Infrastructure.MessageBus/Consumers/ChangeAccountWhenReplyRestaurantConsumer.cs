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
    public class ChangeAccountWhenReplyRestaurantConsumer : Consumer<DomainEvent.RestaurantReply>
    {
        public ChangeAccountWhenReplyRestaurantConsumer(IInteractor<DomainEvent.RestaurantReply> interactor) : base(interactor)
        {
        }
    }
}
