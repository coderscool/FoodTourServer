using Contracts.Services.Dish.Protobuf;

namespace WebApplication1.APIs.Dish
{
    public static class Queries
    {
        public record DishDetailsById(Disher.DisherClient Client, string Id, CancellationToken CancellationToken)
        {
            public static implicit operator DishDetailsByIdRequest(DishDetailsById request)
                => new() { Id = request.Id };
        }
    }
}
