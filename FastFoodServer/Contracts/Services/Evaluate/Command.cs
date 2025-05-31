using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Evaluate
{
    public static class Command
    {
        public record AddRateRestaurant(string Id, string RestaurantId, string CustomerId, int[] Rate, string type) : Message, ICommand;
        public record AddRateDish(string Id);
             
    }
}
