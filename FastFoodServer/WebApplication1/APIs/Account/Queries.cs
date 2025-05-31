using Contracts.Abstractions.Paging;
using Contracts.Services.Account.Protobuf;
using Contracts.Services.Identity.Protobuf;
using WebApplication1.Abstractions;
using WebApplication1.APIs.Account.Validators;

namespace WebApplication1.APIs.Account
{
    public static class Queries
    {
        public record GetListStoreNears(Accounter.AccounterClient Client, double Longitude, double Latitude, CancellationToken CancellationToken)
            : Validatable<GetListStoreNearsValidator>, IQuery<Accounter.AccounterClient>
        {
            public static implicit operator LocationRequest(GetListStoreNears request)
                => new() 
                { 
                    Longitude = request.Longitude,
                    Latitude = request.Latitude
                };
        }

        public record SearchListStore(Accounter.AccounterClient Client, int Limit, int Offset, string Keyword, string Nation, string City, CancellationToken CancellationToken)
            : Validatable<SearchListStoreValidator>, IQuery<Accounter.AccounterClient>
        {
            public static implicit operator SearchRequest(SearchListStore request)
                => new()
                {
                    Paging = new() { Limit = request.Limit, Offset = request.Offset },
                    Keyword = request.Keyword,
                    Nation = request.Nation,
                    City = request.City
                };
        }
    }
}
