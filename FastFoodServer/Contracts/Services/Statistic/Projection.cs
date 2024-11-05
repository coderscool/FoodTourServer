using Contracts.Abstractions.DataTransferObject;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Abstractions.Messages;

namespace Contracts.Services.Statistic
{
    public static class Projection
    {
        public class Statistic : IProjection
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            [BsonElement("NumberOder")]
            public int NumberOrder { get; set; }
            [BsonElement("NumberMeal")]
            public int NumberMeal { get; set; }
            [BsonElement("NumberDish")]
            public int NumberDish { get; set; }
            [BsonElement("Revenue")]
            public long Revenue { get; set; }
            [BsonElement("NumberRate")]
            public int NumberRate { get; set; }
            [BsonElement("EvaluateAvg")]
            public Dto.EvaluateAvg EvaluateAvg { get; set; }
        }
    }
}
