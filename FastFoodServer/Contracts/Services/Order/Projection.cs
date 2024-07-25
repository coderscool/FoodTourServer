using Contracts.Abstractions.Messages;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Abstractions.DataTransferObject;

namespace Contracts.Services.Order
{
    public static class Projection
    {
        public class Order : IProjection 
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
            [BsonElement("Restaurant")]
            public Dto.Person Restaurant { get; set; }
            [BsonElement("Customer")]
            public Dto.Person Customer { get; set; }
            [BsonElement("Name")]
            public string Name { get; set; }
            [BsonElement("Price")]
            public long Price { get; set; }
            [BsonElement("Status")]
            public string Status { get; set; }
            [BsonElement("Amount")]
            public int Amount { get; set; }
            [BsonElement("Date")]
            public DateTime Date { get; set; }
        }

    }
}
