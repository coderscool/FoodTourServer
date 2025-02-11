using Contracts.Abstractions.Paging;
using PagedResult = Contracts.Abstractions.Protobuf.PagedResult;
using Google.Protobuf;

namespace WebApplication1.Abstractions
{
    public record PagedResult<TProjection> : IPagedResult<TProjection>
    where TProjection : IMessage, new()
    {
        public IReadOnlyList<TProjection> Items { get; init; } = new List<TProjection>();
        public Page Page { get; init; } = new();

        public static implicit operator PagedResult<TProjection>(PagedResult result)
            => new()
            {
                Items = result.Projections.Select(proto => proto.Unpack<TProjection>()).ToList(),
                Page = result.Page
            };
    }
}
