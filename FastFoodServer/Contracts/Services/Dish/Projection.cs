﻿using Contracts.Abstractions.DataTransferObject;
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
            [BsonElement("Person")]
            public Dto.Person Person { get; set; }
            [BsonElement("Name")]
            public string Name { get; set; } = string.Empty;
            [BsonElement("Image")]
            public string Image { get; set; }
            [BsonElement("Location")]
            public List<string>? Category { get; set; }
            [BsonElement("Nation")]
            public List<string>? Nation { get; set; }
            [BsonElement("Cost")]
            public string Cost { get; set; } = string.Empty;
            [BsonElement("Discount")]
            public float Discount { get; set; }
            [BsonElement("Rate")]
            public float Rate { get; set; }
            [BsonElement("Sell")]
            public int Sell { get; set; }
        }
    }
}
