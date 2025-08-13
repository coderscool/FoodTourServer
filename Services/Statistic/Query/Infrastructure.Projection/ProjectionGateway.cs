using Application.Abstractions.Gateways;
using Contracts.Abstractions.Messages;
using Infrastructure.Projection.Abstractions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Projection
{
    public class ProjectionGateway<TProjection> : IProjectionGateway<TProjection>
        where TProjection : IProjection
    {
        private readonly IMongoCollection<TProjection> _collection;
        public ProjectionGateway(IMongoDbContext context)
        {
            _collection = context.GetCollection<TProjection>();
        }

        public async ValueTask ReplaceInsertAsync(TProjection replacement, CancellationToken cancellationToken)
            => await _collection.InsertOneAsync(replacement);

        public async Task<List<TProjection?>> FindSellAsync(CancellationToken cancellationToken)
            => await _collection.Find(x => true).Sort(Builders<TProjection>.Sort.Descending("Sell")).Limit(10).ToListAsync(cancellationToken);

        public async Task<TProjection?> FindAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken)
            => await _collection.AsQueryable().Where(predicate).FirstOrDefaultAsync(cancellationToken)!;

        public async Task<List<TProjection?>> FindPaginatonAsync(Expression<Func<TProjection, bool>> predicate, int pageIndex, int pageSize, CancellationToken cancellationToken)
            => await _collection.AsQueryable().Where(predicate).Skip(pageIndex*pageSize).Take(pageSize).ToListAsync();

        public async Task UpdateFieldAsync(Expression<Func<TProjection, bool>> predicate, TProjection projection, CancellationToken cancellationToken)
            => await _collection.ReplaceOneAsync(predicate, projection);

        public Task UpdateFieldAsync<TField, TId>(TId id, long version, Expression<Func<TProjection, TField>> field, TField value, CancellationToken cancellationToken)
            => _collection.UpdateOneAsync(
                filter: projection => projection.Id.Equals(id) && projection.Version < version,
                update: new ObjectUpdateDefinition<TProjection>(new()).Set(field, value),
                cancellationToken: cancellationToken);
    }
}
