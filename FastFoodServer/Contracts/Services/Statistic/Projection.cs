using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;

namespace Contracts.Services.Statistic
{
    public static class Projection
    {
        public record StatisticSeller(string Id, ushort NumberOrder, ushort NumberMeal, ushort NumberDish, ulong Revenue, int NumberRate, Dto.EvaluateAvg EvaluateAvg, long Version) : IProjection
        {
            
        }
    }
}
