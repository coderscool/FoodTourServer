using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DependencyInjection.Options
{
    public class OrderGrpcClientOptions
    {
        [Required, Url] public required string BaseAddress { get; init; }
    }
}
