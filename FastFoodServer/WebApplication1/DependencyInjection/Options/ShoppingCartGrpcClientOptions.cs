using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DependencyInjection.Options
{
    public class ShoppingCartGrpcClientOptions
    {
        [Required, Url] public required string BaseAddress { get; init; }
    }
}
