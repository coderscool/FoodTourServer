using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Gateways
{
    public interface IProjectionGateway<TProjection>
    where TProjection : IProjection
    {
        ValueTask ReplaceInsertAsync(TProjection replacement, CancellationToken cancellationToken);
        Task<List<TProjection?>> ListAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken);
        Task DeleteAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken);
        Task DeleteAsync<TId>(TId id, CancellationToken cancellationToken);
        Task<int> QuantityAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken);
        Task UpdateFieldAsync<TField, TId>(TId id, long version, Expression<Func<TProjection, TField>> field, TField value, CancellationToken cancellationToken);
    }
}
