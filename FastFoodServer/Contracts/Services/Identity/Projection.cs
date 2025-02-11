﻿using MongoDB.Bson.Serialization.Attributes;
using Contracts.DataTransferObject;
using MongoDB.Bson;
using Contracts.Abstractions.Messages;

namespace Contracts.Services.Identity
{
    public static class Projection
    {
        public record User(string Id, string UserName, string PassWord, Dto.DtoPerson Person, string Role, string Token) : IProjection
        {
            public static implicit operator Protobuf.UserDetails(User userDetails)
                => new()
                {
                    Id = userDetails.Id,
                    UserName = userDetails.UserName,
                    PassWord = userDetails.PassWord,
                    Person = userDetails.Person,
                    Role = userDetails.Role,
                    Token = userDetails.Token
                };
        }
    }
}
