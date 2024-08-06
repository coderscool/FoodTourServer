using Application.Abstractions.Gateways;
using Contracts.Abstractions.Messages;
using Infrastructure.Projection.Abstractions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
    }
}
