using Contracts.Services.Cart.Protobuf;
using WebApplication1.Abstractions;
using WebApplication1.APIs.ShoppingCart.Validators;

namespace WebApplication1.APIs.ShoppingCart
{
    public static class Queries
    {
        public record GetListCart(Carter.CarterClient Client, string Id, CancellationToken CancellationToken)
            : Validatable<GetListCartValidator>, IQuery<Carter.CarterClient>
        {
            public static implicit operator GetListCartRequest(GetListCart request)
                => new()
                {
                    CustomerId = request.Id
                };
        }
    }
}
