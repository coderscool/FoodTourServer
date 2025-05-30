﻿using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
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
        Task<TProjection?> FindAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken);
        ValueTask ReplaceInsertAsync(TProjection replacement, CancellationToken cancellationToken);
        Task UpdateFieldAsync(Expression<Func<TProjection, bool>> predicate, TProjection projection, CancellationToken cancellationToken);
        Task DeleteAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken);
        Task<List<TProjection?>> FindPaginatonAsync(int pageIndex, CancellationToken cancellationToken);
        Task<List<TProjection?>> FindListAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken);
        ValueTask<IPagedResult<TProjection>> ListAsync(Paging paging, CancellationToken cancellationToken);
    }
}
