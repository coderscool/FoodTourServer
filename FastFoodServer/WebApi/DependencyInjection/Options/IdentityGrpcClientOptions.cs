using System.ComponentModel.DataAnnotations;

namespace WebApi.DependencyInjection.Options
{
    public record IdentityGrpcClientOptions
    {
        public string BaseAddress { get; init; }
    }
}
