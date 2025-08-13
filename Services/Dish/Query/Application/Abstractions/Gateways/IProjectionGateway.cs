using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using MongoDB.Driver.GeoJsonObjectModel;
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
        Task<List<TProjection>> SortAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken);
        Task<List<TProjection>> ListAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken);
        Task<TProjection?> FindAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken);
        ValueTask<IPagedResult<TProjection>> ListAsync(Expression<Func<TProjection, bool>> predicate, Paging paging, CancellationToken cancellationToken);
        Task UpdateFieldAsync<TField, TId>(TId id, long version, Expression<Func<TProjection, TField>> field, TField value, CancellationToken cancellationToken);
        Task UpdateFieldsAsync<TId>(TId id, long version, IEnumerable<(Expression<Func<TProjection, object>> field, object value)> updates, CancellationToken cancellationToken);
    }
}
