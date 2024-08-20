using Contracts.Abstractions.Messages;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Account
{
    public static class Projection 
    {
        public class Account : IProjection
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            [BsonElement("Budget")]
            public long Budget { get; set; }
        }
    }
}
