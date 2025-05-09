using Application.Abstractions.Gateways;
using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using Infrastructure.Projection.Abstractions;
using Infrastructure.Projection.Pagination;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Projection
{
    public class ProjectionGateway<TProjection> : IProjectionGateway<TProjection>
        where TProjection : IPositionProjection
    {
        private readonly IMongoCollection<TProjection> _collection;
        private const int pageSize = 2;
        public ProjectionGateway(IMongoDbContext context)
        {
            _collection = context.GetCollection<TProjection>();

            CreateIndexesAsync().GetAwaiter().GetResult();
        }

        public async ValueTask ReplaceInsertAsync(TProjection replacement, CancellationToken cancellationToken)
            => await _collection.InsertOneAsync(replacement);

        public async Task<List<TProjection>> FindSellAsync(CancellationToken cancellationToken)
            => await _collection.Find(x => true).Sort(Builders<TProjection>.Sort.Descending("Sell")).Limit(10).ToListAsync(cancellationToken);

        public async Task<TProjection?> FindAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken)
            => await _collection.AsQueryable().Where(predicate).FirstOrDefaultAsync(cancellationToken)!;

        public async Task UpdateFieldAsync(Expression<Func<TProjection, bool>> predicate, TProjection projection, CancellationToken cancellationToken)
            => await _collection.ReplaceOneAsync(predicate, projection);

        public async Task<List<TProjection>> ListAsync(Paging paging, GeoJsonPoint<GeoJson2DGeographicCoordinates> Point, CancellationToken cancellationToken)
            => await _collection.Find(Builders<TProjection>.Filter.Near(s => s.Location, Point)).Limit(10).ToListAsync();

        private async Task CreateIndexesAsync()
        {
            var indexKeys = Builders<TProjection>.IndexKeys.Geo2DSphere(s => s.Location);
            var indexModel = new CreateIndexModel<TProjection>(indexKeys);

            await _collection.Indexes.CreateOneAsync(indexModel);
        }
    }
}
