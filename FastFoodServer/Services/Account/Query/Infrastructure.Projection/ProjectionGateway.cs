using Application.Abstractions.Gateways;
using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using Infrastructure.Projection.Abstractions;
using Infrastructure.Projection.Pagination;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using MongoDB.Driver.Linq;
using System.Drawing;
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

        public async Task<TProjection?> FindAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken)
            => await _collection.AsQueryable().Where(predicate).FirstOrDefaultAsync(cancellationToken)!;

        public async Task UpdateFieldAsync(Expression<Func<TProjection, bool>> predicate, TProjection projection, CancellationToken cancellationToken)
            => await _collection.ReplaceOneAsync(predicate, projection);
           
    }

    public class PositionProjectionGateway<TProjection> : IPositionProjectionGateway<TProjection>
    where TProjection : IPositionProjection
    {
        private readonly IMongoCollection<TProjection> _collection;
        private const int pageSize = 2;
        public PositionProjectionGateway(IMongoDbContext context)
        {
            _collection = context.GetCollection<TProjection>();

            CreateIndexesAsync().GetAwaiter().GetResult();
        }

        private async Task CreateIndexesAsync()
        {
            var indexKeys = Builders<TProjection>.IndexKeys.Geo2DSphere(s => s.Location);
            var indexModel = new CreateIndexModel<TProjection>(indexKeys);

            await _collection.Indexes.CreateOneAsync(indexModel);
        }

        public async Task<List<TProjection>> ListAsync(GeoJsonPoint<GeoJson2DGeographicCoordinates> point, CancellationToken cancellationToken)
            => await _collection.Find(Builders<TProjection>.Filter.Near(s => s.Location, point)).Limit(2).ToListAsync();
    }
}
