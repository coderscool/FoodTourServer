using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Gateways
{
    public interface IElasticSearchGateway<TProjection> where TProjection : class, IProjection
    {
        ValueTask<IPagedResult<TProjection>> SearchAsync(
            string indexName,
            Func<QueryContainerDescriptor<TProjection>, QueryContainer> query,
            Paging Paging,
            CancellationToken cancellationToken
        );

        Task InsertDocumentAsync(TProjection project);
    }
}
