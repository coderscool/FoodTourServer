using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Abstractions.Messages;
using Contracts.Abstractions.DataTransferObject;

namespace Contracts.Services.Identity
{
    public static class Projection
    {
        public class User : IProjection
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; } = string.Empty;
            [BsonElement("UserName")]
            public string UserName { get; set; } = string.Empty;
            [BsonElement("PassWord")]
            public string PassWord { get; set; } = string.Empty;
            [BsonElement("Name")]
            public Dto.Person Person { get; set; }
            [BsonElement("Image")]
            public string Image { get; set; } = string.Empty;
            [BsonElement("Role")]
            public string Role { get; set; } = string.Empty;
            [BsonElement("Category")]
            public List<string>? Nation { get; set; }
            [BsonElement("Token")]
            public string Token { get; set; } = string.Empty;
        }
    }
}
