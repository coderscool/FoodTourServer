using Contracts.Abstractions.Messages;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.DataTransferObject;

namespace Contracts.Services.Account
{
    public static class Projection 
    {
        public record Accounts(string Id, Dto.DtoPerson Person) : IProjection
        {
            public static implicit operator Protobuf.AccountDetail(Accounts account)
                => new()
                {
                    Id = account.Id,
                    Person = account.Person,
                };
        }
    }
}
