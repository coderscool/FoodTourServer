using Contracts.Abstractions.Messages;
using System.Linq.Expressions;

namespace Application.Abstractions.Gateways
{
    public interface IProjectionGateway<TProjection>
    where TProjection : IProjection
    {
        ValueTask ReplaceInsertAsync(TProjection replacement, CancellationToken cancellationToken);
        Task<List<TProjection?>> FindSellAsync(CancellationToken cancellationToken);
        Task<TProjection?> FindAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken);
        Task<List<TProjection?>> FindPaginatonAsync(Expression<Func<TProjection, bool>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken);
        Task UpdateFieldAsync(Expression<Func<TProjection, bool>> predicate, TProjection projection, CancellationToken cancellationToken);
        Task UpdateFieldAsync<TField, TId>(TId id, long version, Expression<Func<TProjection, TField>> field, TField value, CancellationToken cancellationToken);

    }
}
