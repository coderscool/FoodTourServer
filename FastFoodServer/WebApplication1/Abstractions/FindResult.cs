using Contracts.Abstractions.Paging;
using FindResult = Contracts.Abstractions.Protobuf.FindResult;
using Google.Protobuf;

namespace WebApplication1.Abstractions
{
    public record FindResult<TProjection> : IFindResult<TProjection>
    where TProjection : IMessage, new()
    {
        public IReadOnlyList<TProjection> Items { get; init; } = new List<TProjection>();

        public static implicit operator FindResult<TProjection>(FindResult result)
            => new()
            {
                Items = result.Projections.Select(proto => proto.Unpack<TProjection>()).ToList(),
            };
    }
}
