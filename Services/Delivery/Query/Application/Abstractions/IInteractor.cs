using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;

namespace Application.Abstractions
{
    public interface IInteractor<in TEvent>
    where TEvent : IDomainEvent
    {
        Task InteractAsync(TEvent @event, CancellationToken cancellationToken);
    }

    public interface IInteractor<in TQuery, TProjection>
        where TQuery : IQuery
        where TProjection : IProjection
    {
        Task<TProjection?> InteractAsync(TQuery query, CancellationToken cancellationToken);
    }

    public interface IPagedInteractor<in TQuery, TProjection>
    where TQuery : IQuery
    where TProjection : IProjection
    {
        ValueTask<IPagedResult<TProjection>> InteractAsync(TQuery query, CancellationToken cancellationToken);
    }

    public interface IFindInteractor<in TQuery, TProjection>
    where TQuery : IQuery
    where TProjection : IProjection
    {
        Task<List<TProjection>> InteractAsync(TQuery query, CancellationToken cancellationToken);
    }
}
