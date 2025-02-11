using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Statistic
{
    public static class DomainEvent
    {
        public record StatisticCreate(string AggregateId, int NumberOrder, int NumberMeal, int NumberDish, long Revenue, int NumberRate, Dto.EvaluateAvg EvaluateAvg, long Version) : Message, IDomainEvent;
        public record NumberDishUpdate(string AggregateId, int Quantity, long Version) : Message, IDomainEvent;
        public record RevenueUpdate(string AggregateId, int Quantity, long Price, long Version) : Message, IDomainEvent;
    }
}
