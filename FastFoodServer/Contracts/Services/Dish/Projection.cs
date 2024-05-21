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
            [BsonElement("Name")]
            public string Name { get; set; } = string.Empty;
            [BsonElement("Image")]
            public string Image { get; set; }
            [BsonElement("Location")]
            public string Location { get; set; } = string.Empty;
            [BsonElement("Category")]
            public List<string>? Category { get; set; }
            [BsonElement("Nation")]
            public List<string>? Nation { get; set; }
            [BsonElement("Cost")]
            public string Cost { get; set; } = string.Empty;
            [BsonElement("Discount")]
            public float Discount { get; set; }
            [BsonElement("Rate")]
            public float Rate { get; set; }
        }
    }
}
