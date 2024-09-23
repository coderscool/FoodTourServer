using Application.Abstractions;
using Contracts.Services.ShoppingCart;
using Infrastructure.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectCartWhenCartItemRemoveConsumer : Consumer<DomainEvent.CartItemRemove>
    {
        public ProjectCartWhenCartItemRemoveConsumer(IInteractor<DomainEvent.CartItemRemove> interactor) : base(interactor)
        {
        }
    }
}
