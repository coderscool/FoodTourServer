using Contracts.Services.Statistic.Protobuf;
using WebApplication1.Abstractions;

namespace WebApplication1.APIs.Statistic
{
    public static class StatisticApi
    {
        public static IEndpointRouteBuilder MapStatisticApiV1(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/api/statictic/detail", ([AsParameters] Queries.GetStatisticById query)
                => ApplicationApi.GetAsync<Statisticer.StatisticerClient, StatisticDetail>
                    (query, (client, ct) => client.GetStatisticDetailAsync(query, cancellationToken: ct)));

            return builder;
        }
    }
}
