using Contracts.Abstractions.Messages;
using Contracts.Services.Statistic.Protobuf;

namespace Contracts.Services.Statistic
{
    public static class Query 
    {
        public record GetById(string Id) : IQuery
        {
            public static implicit operator GetById(GetByIdRequest query)
                => new (query.Id);
        }
    }
}
