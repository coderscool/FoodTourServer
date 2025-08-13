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

        public async ValueTask ReplaceInsertAsync(TProjection replacement, CancellationToken cancellationToken)
            => await _collection.InsertOneAsync(replacement);

        public async Task<List<TProjection?>> FindListAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken)
            => await _collection.AsQueryable().Where(predicate).ToListAsync(cancellationToken);

        public async Task<TProjection?> FindAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken)
            => await _collection.AsQueryable().Where(predicate).FirstOrDefaultAsync(cancellationToken)!;

        public async ValueTask<IPagedResult<TProjection>> ListAsync(Expression<Func<TProjection, bool>> predicate, Paging paging, CancellationToken cancellationToken)
            => await PagedResult<TProjection>.CreateAsync(paging, _collection.AsQueryable().Where(predicate), cancellationToken);

        public Task UpdateFieldAsync<TField, TId>(TId id, long version, Expression<Func<TProjection, TField>> field, TField value, CancellationToken cancellationToken)
        => _collection.UpdateOneAsync(
            filter: projection => projection.Id.Equals(id) && projection.Version < version,
            update: new ObjectUpdateDefinition<TProjection>(new()).Set(field, value),
            cancellationToken: cancellationToken);

        public Task UpdateFieldsAsync<TId>(TId id, long version, IEnumerable<(Expression<Func<TProjection, object>> field, object value)> updates,
            CancellationToken cancellationToken)
        {
            var updateDefinition = Builders<TProjection>.Update.Combine(
                updates.Select(u => Builders<TProjection>.Update.Set(u.field, u.value))
            );

            var filter = Builders<TProjection>.Filter.Where(x => x.Id!.Equals(id) && x.Version < version);

            return _collection.UpdateOneAsync(filter, updateDefinition, cancellationToken: cancellationToken);
        }



    }
}
