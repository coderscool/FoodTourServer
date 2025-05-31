using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Infrastructure.Projection.Pagination
{
    public class PagedResult<TProjection> : IPagedResult<TProjection>
    where TProjection : IProjection
    {
        private readonly IReadOnlyList<TProjection> _items;
        private readonly Paging _paging;

        public PagedResult(IReadOnlyList<TProjection> items, Paging paging)
        {
            _items = items;
            _paging = paging;
        }

        public IReadOnlyList<TProjection> Items
            => _items.ToList().AsReadOnly();
        
        public Page Page
            => new()
            {
                Current =  1,
                Size = 2,
                HasNext = true,
                HasPrevious = true
            };

        public static async ValueTask<IPagedResult<TProjection>> CreateAsync(Paging paging, IQueryable<TProjection> source, CancellationToken cancellationToken)
        {
            var items = await ApplyPagination(paging, source).ToListAsync(cancellationToken);
            return new PagedResult<TProjection>(items, paging);
        }

        private static IMongoQueryable<TProjection> ApplyPagination(Paging paging, IQueryable<TProjection> source)
            => (IMongoQueryable<TProjection>)source.Skip(paging.Limit * paging.Offset).Take(paging.Limit);
    }
}
