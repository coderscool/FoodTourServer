using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using System.Linq.Expressions;

namespace Application.Abstractions.Gateways
{
    public interface IProjectionGateway<TProjection>
    where TProjection : IProjection
    {
        ValueTask ReplaceInsertAsync(TProjection replacement, CancellationToken cancellationToken);
        ValueTask<IPagedResult<TProjection>> ListAsync(Expression<Func<TProjection, bool>> predicate, Paging paging, CancellationToken cancellationToken);
        Task UpdateFieldAsync(Expression<Func<TProjection, bool>> predicate, TProjection projection, CancellationToken cancellationToken);
        Task UpdateFieldAsync<TField, TId>(TId id, long version, Expression<Func<TProjection, TField>> field, TField value, CancellationToken cancellationToken);
    }
}
