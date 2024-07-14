using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Account
{
    public static class DomainEvent
    {
        public record PaymentRequest(string AggregateId, string RestaurantId, string CustomerId, string DishId,
            Dto.Person Customer, string Name, Dto.Price Price, int Amount, long Version) : Message, IDomainEvent;
    }
}
