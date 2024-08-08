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
        Task<List<TProjection?>> FindSellAsync(CancellationToken cancellationToken);
        Task<TProjection?> FindAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken);
    }
}
