using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Abstractions.Messages;

namespace Contracts.Services.Identity
{
    public static class Projection
    {
        public class LoginUser : IProjection
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            [BsonElement("UserName")]
            public string UserName { get; set; } = string.Empty;
            [BsonElement("PassWord")]
            public string PassWord { get; set; } = string.Empty;
            [BsonElement("Role")]
            public string Role { get; set; } = string.Empty;
            [BsonElement("Token")]
            public string Token { get; set; } = string.Empty;
        }
    }
}
