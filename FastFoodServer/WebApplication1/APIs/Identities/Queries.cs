using Contracts.Services.Identity.Protobuf;
using WebApplication1.Abstractions;
using WebApplication1.APIs.Identities.Validators;

namespace WebApplication1.APIs.Identities
{
    public static class Queries
    {
        public record SignIn(Identiter.IdentiterClient Client, string Username, string Password, CancellationToken CancellationToken)
            : Validatable<SignInValidator>, IQuery<Identiter.IdentiterClient>
        {
            public static implicit operator LoginRequest(SignIn request)
                => new() { UserName = request.Username, PassWord = request.Password };
        }

        public record ListRestaurantItems(Identiter.IdentiterClient Client, int? Limit, int? Offset, CancellationToken CancellationToken)
            : Validatable<ListRestaurantItemsValidator>, IQuery<Identiter.IdentiterClient>
        {
            public static implicit operator ListRestaurantItemsRequest(ListRestaurantItems request)
                => new() { Paging = new() { Limit = request.Limit, Offset = request.Offset } };
        }
    }
}
