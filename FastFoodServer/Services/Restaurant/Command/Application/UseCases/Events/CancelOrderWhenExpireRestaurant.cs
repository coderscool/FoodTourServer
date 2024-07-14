using Application.Abstractions;
using Contracts.Services.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class CancelOrderWhenExpireRestaurant : IInteractor<DomainEvent.ExpireOrderRestaurant>
    {
        public async Task InteractAsync(DomainEvent.ExpireOrderRestaurant message, CancellationToken cancellationToken)
        {
            Console.WriteLine("123");
        }
    }
}
