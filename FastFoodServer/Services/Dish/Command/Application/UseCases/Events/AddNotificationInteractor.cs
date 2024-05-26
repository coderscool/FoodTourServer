using Application.Abstractions;
using Contracts.Services.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class AddNotificationInteractor : IInteractor<DomainEvent.OrderAddItem>
    {
        public AddNotificationInteractor()
        {
        }

        public async Task InteractAsync(DomainEvent.OrderAddItem command, CancellationToken cancellationToken)
        {
            Console.WriteLine("--account--");
        }
    }
}
