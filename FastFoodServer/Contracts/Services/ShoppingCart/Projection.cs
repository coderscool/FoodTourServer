using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.ShoppingCart
{
    public static class Projection
    {
        public class Cart : IProjection 
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
            [BsonElement("Amount")]
            public int Amount { get; set; }
        }

    }
}
