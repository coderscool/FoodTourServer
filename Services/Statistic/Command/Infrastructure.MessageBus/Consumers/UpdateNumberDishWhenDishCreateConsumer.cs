using Application.Abstractions;
using Contracts.Services.Dish;
using Infrastructure.MessageBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MessageBus.Consumers
{
    public class UpdateNumberDishWhenDishCreateConsumer : Consumer<DomainEvent.DishCreate>
    {
        public UpdateNumberDishWhenDishCreateConsumer(IInteractor<DomainEvent.DishCreate> interactor) : base(interactor)
        {
        }
    }
}
