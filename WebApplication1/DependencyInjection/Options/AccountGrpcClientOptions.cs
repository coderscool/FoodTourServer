using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DependencyInjection.Options
{
    public record AccountGrpcClientOptions
    {
        [Required, Url] public required string BaseAddress { get; init; }
    }
}
