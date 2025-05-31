using Application.Abstractions.Gateways;
using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using Infrastructure.Projection.Abstractions;
using Infrastructure.Projection.Pagination;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Projection
{
    public class ProjectionGateway<TProjection> : IProjectionGateway<TProjection>
    where TProjection : IProjection
    {
        private readonly IMongoCollection<TProjection> _collection;
        private const int pageSize = 2;

        public ProjectionGateway(IMongoDbContext context)
        {
            _collection = context.GetCollection<TProjection>();
        }

        public async Task DeleteAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken)
            => await _collection.DeleteManyAsync(predicate, cancellationToken);

        public async Task<TProjection?> FindAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken)
            => await _collection.AsQueryable().Where(predicate).FirstOrDefaultAsync(cancellationToken)!;

        public async Task<List<TProjection?>> FindPaginatonAsync(int pageIndex, CancellationToken cancellationToken)
            => await _collection.AsQueryable().Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();

        public async ValueTask ReplaceInsertAsync(TProjection replacement, CancellationToken cancellationToken)
            => await _collection.InsertOneAsync(replacement);

        public async Task UpdateFieldAsync(Expression<Func<TProjection, bool>> predicate, TProjection projection, CancellationToken cancellationToken)
            => await _collection.ReplaceOneAsync(predicate, projection);

        public async Task<List<TProjection?>> FindListAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken)
            => await _collection.AsQueryable().Where(predicate).ToListAsync(cancellationToken);

        public async ValueTask<IPagedResult<TProjection>> ListAsync(Paging paging, CancellationToken cancellationToken)
            => await PagedResult<TProjection>.CreateAsync(paging, _collection.AsQueryable(), cancellationToken);
    }
}
