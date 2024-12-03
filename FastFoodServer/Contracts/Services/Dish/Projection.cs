using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Dish
{
    public static class Projection
    {
        public class Dish : IProjection 
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            [BsonElement("PersonId")]
            public string PersonId { get; set; } = string.Empty;
            [BsonElement("Name")]
            public string Name { get; set; } = string.Empty;
            [BsonElement("Image")]
            public string Image { get; set; }
            [BsonElement("Category")]
            public List<string>? Category { get; set; }
            [BsonElement("Nation")]
            public List<string>? Nation { get; set; }
            [BsonElement("Cost")]
            public long Cost { get; set; } 
            [BsonElement("Discount")]
            public float Discount { get; set; }
            [BsonElement("Quantity")]
            public int Quantity { get; set; }
        }
    }
}
