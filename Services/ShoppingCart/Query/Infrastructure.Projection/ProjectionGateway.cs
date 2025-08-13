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

        public async Task<List<TProjection?>> ListAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken)
            => await _collection.AsQueryable().Where(predicate).ToListAsync();

        public async ValueTask ReplaceInsertAsync(TProjection replacement, CancellationToken cancellationToken)
            => await _collection.InsertOneAsync(replacement);

        public async Task DeleteAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken)
            => await _collection.DeleteManyAsync(predicate, cancellationToken);

        public async Task<int> QuantityAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken)
            => await _collection.AsQueryable().Where(predicate).CountAsync();

        public Task UpdateFieldAsync<TField, TId>(TId id, long version, Expression<Func<TProjection, TField>> field, TField value, CancellationToken cancellationToken)
        => _collection.UpdateOneAsync(
            filter: projection => projection.Id.Equals(id) && projection.Version < version,
            update: new ObjectUpdateDefinition<TProjection>(new()).Set(field, value),
            cancellationToken: cancellationToken);

        public Task DeleteAsync<TId>(TId id, CancellationToken cancellationToken)
            => _collection.DeleteOneAsync(projection => projection.Id.Equals(id), cancellationToken);
    }
}
