using Contracts.Abstractions.Messages;
using System.Linq.Expressions;

namespace Application.Abstractions.Gateways
{
    public interface IProjectionGateway<TProjection>
    where TProjection : IProjection
    {
        ValueTask ReplaceInsertAsync(TProjection replacement, CancellationToken cancellationToken);
        Task<List<TProjection?>> FindListAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken);
        Task<TProjection?> FindAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken);
        Task UpdateFieldAsync<TField, TId>(TId id, long version, Expression<Func<TProjection, TField>> field, TField value, CancellationToken cancellationToken);
        Task UpdateFieldsAsync<TId>(TId id, long version, IEnumerable<(Expression<Func<TProjection, object>> field, object value)> updates, CancellationToken cancellationToken);
    }
}
