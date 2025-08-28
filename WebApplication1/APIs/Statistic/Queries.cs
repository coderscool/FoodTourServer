using Contracts.Services.Statistic.Protobuf;
using WebApplication1.Abstractions;
using WebApplication1.APIs.Statistic.Validator;

namespace WebApplication1.APIs.Statistic
{
    public static class Queries
    {
        public record GetStatisticById(Statisticer.StatisticerClient Client, string Id, CancellationToken CancellationToken)
            : Validatable<GetStatisticByIdValidator>, IQuery<Statisticer.StatisticerClient>
        {
            public static implicit operator GetByIdRequest(GetStatisticById request)
                => new() { Id = request.Id };
        }
    }
}
