using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Abstractions.Paging;
using Contracts.Services.Account;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Application.UseCases.Queries
{
    public class GetListStoreNear : IFindInteractor<Query.PositionStore, Projection.AccountSeller>
    {
        private readonly IPositionProjectionGateway<Projection.AccountSeller> _projectionGateway;
        public GetListStoreNear(IPositionProjectionGateway<Projection.AccountSeller> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task<List<Projection.AccountSeller>> InteractAsync(Query.PositionStore query, CancellationToken cancellationToken)
        {
            var point = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(new GeoJson2DGeographicCoordinates(query.Longitude, query.Latitude));
            return await _projectionGateway.ListAsync(point, cancellationToken);
        }
    }
}
