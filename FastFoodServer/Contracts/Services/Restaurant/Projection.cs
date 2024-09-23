using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Restaurant
{
    public static class Projection
    {
        public class Restaurant : IProjection
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            [BsonElement("RestaurantId")]
            public string RestaurantId { get; set; }
            [BsonElement("CustomerId")]
            public string CustomerId { get; set; }
            [BsonElement("DishId")]
            public string DishId { get; set; }
            [BsonElement("Customer")]
            public Dto.Person Customer { get; set; }
            [BsonElement("Name")]
            public string Name { get; set; }
            [BsonElement("Price")]
            public long Price { get; set; }
            [BsonElement("Status")]
            public bool Status { get; set; }
            [BsonElement("Active")]
            public bool Active { get; set; }
            [BsonElement("Quantity")]
            public int Quantity { get; set; }
            [BsonElement("Time")]
            public int Time { get; set; }
            [BsonElement("Date")]
            public DateTime Date { get; set; }
        }

    }
}
