using Application.Abstractions;
using Contracts.Services.Dish;
using Infrastructure.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectDishWhenCreateDishConsumer : Consumer<DomainEvent.DishCreate>
    {

        public ProjectDishWhenCreateDishConsumer(IInteractor<DomainEvent.DishCreate> interactor) : base(interactor)
        {

        }
    }
}
