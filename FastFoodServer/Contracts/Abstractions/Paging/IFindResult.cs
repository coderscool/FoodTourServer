using MassTransit;

namespace Contracts.Abstractions.Paging
{
    [ExcludeFromTopology]
    public interface IFindResult<out TProjection>
    {
        IReadOnlyList<TProjection> Items { get; }
    }
}
