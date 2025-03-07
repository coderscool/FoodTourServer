﻿using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IInteractor<in TMessage>
        where TMessage : IMessage
    {
        Task InteractAsync(TMessage message, CancellationToken cancellationToken);
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
}
