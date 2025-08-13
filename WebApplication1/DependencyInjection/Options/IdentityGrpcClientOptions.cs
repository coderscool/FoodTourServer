using System.ComponentModel.DataAnnotations;

namespace WebApi.DependencyInjection.Options
{
    public record IdentityGrpcClientOptions
    {
        [Required, Url] public required string BaseAddress { get; init; }
    }
}
