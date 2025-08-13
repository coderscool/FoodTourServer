using Contracts.Abstractions.Messages;
using MongoDB.Driver.GeoJsonObjectModel;
using System.Linq.Expressions;

namespace Application.Abstractions.Gateways
{
    public interface IProjectionGateway<TProjection>
        where TProjection : IProjection
    {
        ValueTask ReplaceInsertAsync(TProjection replacement, CancellationToken cancellationToken);
        Task<TProjection?> FindAsync(Expression<Func<TProjection, bool>> predicate, CancellationToken cancellationToken);
        Task UpdateFieldAsync(Expression<Func<TProjection, bool>> predicate, TProjection projection, CancellationToken cancellationToken);
    }

    public interface IPositionProjectionGateway<TProjection>
        where TProjection : IPositionProjection
    {
        Task<List<TProjection>> ListAsync(GeoJsonPoint<GeoJson2DGeographicCoordinates> point, CancellationToken cancellationToken);
    }
}
