﻿using Contracts.Abstractions.Messages;
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
        Task<TProjection?> FindAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken);
        Task UpdateFieldAsync(Expression<Func<TProjection, bool>> predicate, TProjection projection, CancellationToken cancellationToken);
        Task UpdateFieldAsync<TField, TId>(TId id, long version, Expression<Func<TProjection, TField>> field, TField value, CancellationToken cancellationToken);
    }
}
