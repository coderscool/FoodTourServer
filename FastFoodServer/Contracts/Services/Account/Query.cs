using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using Contracts.Services.Account.Protobuf;

namespace Contracts.Services.Account
{
    public static class Query
    {
        public class GetAccountId : IQuery
        {
            public string Id { get; set; }
        }
        public record SearchQuery(Paging Paging, string Keyword, string Nation, string City) : IQuery
        {
            public static implicit operator SearchQuery(SearchRequest store)
                => new(store.Paging, store.Keyword, store.Nation, store.City);
        }

        public record PositionStore(double Longitude, double Latitude) : IQuery
        {
            public static implicit operator PositionStore(LocationRequest store)
                => new(store.Longitude, store.Latitude);
        }
    }
}
