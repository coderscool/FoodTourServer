﻿using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IQueryInteractor<in TEvent>
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
        Task<List<TProjection>> InteractAsync(TQuery query, CancellationToken cancellationToken);
    }

    public interface ICountInteractor<in TQuery>
        where TQuery : IQuery
    {
        Task<int> InteractAsync(TQuery query, CancellationToken cancellationToken);
    }
}
