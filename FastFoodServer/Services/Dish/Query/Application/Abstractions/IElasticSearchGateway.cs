using Contracts.Abstractions.Messages;
using Contracts.Services.Dish;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IElasticSearchGateway<TProjection>
        where TProjection : IProjection
    {
        Task<TProjection?> FindAsync(Func<QueryContainerDescriptor<Projection.Dish>, QueryContainer> predicate, CancellationToken cancellationToken);
    }
}
