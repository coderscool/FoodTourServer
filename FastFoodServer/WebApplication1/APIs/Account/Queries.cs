using Contracts.Services.Account.Protobuf;
using WebApplication1.Abstractions;
using WebApplication1.APIs.Account.Validators;

namespace WebApplication1.APIs.Account
{
    public static class Queries
    {
        public record GetListStoreNears(Accounter.AccounterClient Client, int Limit, int Offset, double Latitude, double Longitude, CancellationToken CancellationToken)
            : Validatable<GetListStoreNearsValidator>, IQuery<Accounter.AccounterClient>
        {
            public static implicit operator LocationRequest(GetListStoreNears request)
                => new() { Paging = new() { Limit = request.Limit, Offset = request.Offset }, Latitude = request.Latitude, Longitude = request.Longitude };
        }
    }
}
