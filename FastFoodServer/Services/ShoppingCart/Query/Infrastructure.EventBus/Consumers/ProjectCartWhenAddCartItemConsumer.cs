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
    public class ProjectCartWhenAddCartItemConsumer : Consumer<DomainEvent.CartItemAdd>
    {

        public ProjectCartWhenAddCartItemConsumer(IQueryInteractor<DomainEvent.CartItemAdd> interactor) : base(interactor)
        {

        }
    }
}
