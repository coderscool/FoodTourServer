using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Account;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Application.UseCases.Events
{
    public interface IProjectAccountSellerWhenAccountSellerChangedInteractor : IInteractor<DomainEvent.AccountSellerCreate>;
    public class ProjectAccountSellerWhenAccountSellerChangedInteractor : IProjectAccountSellerWhenAccountSellerChangedInteractor
    {
        private readonly IProjectionGateway<Projection.AccountSeller> _projectionGateway;
        private readonly IElasticSearchGateway<Projection.AccountSellerES> _elasticSearchGateway;
        public ProjectAccountSellerWhenAccountSellerChangedInteractor(IProjectionGateway<Projection.AccountSeller> projectionGateway,
            IElasticSearchGateway<Projection.AccountSellerES> elasticSearchGateway)
        {
            _projectionGateway = projectionGateway;
            _elasticSearchGateway = elasticSearchGateway;
        }
        public async Task InteractAsync(DomainEvent.AccountSellerCreate @event, CancellationToken cancellationToken)
        {
            var point = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(
                new GeoJson2DGeographicCoordinates(@event.Seller.Address.Longitude, @event.Seller.Address.Latitude));

            Projection.AccountSeller accounts = new(
                @event.Id,
                @event.Seller,
                @event.Image,
                point,
                @event.Nation,
                @event.TimeActive, 
                @event.Status,
                @event.Version);

            await _projectionGateway.ReplaceInsertAsync(accounts, cancellationToken);
            Projection.AccountSellerES accountes = (Projection.AccountSellerES)accounts;
            await _elasticSearchGateway.InsertDocumentAsync(accountes);
        }
    }
}
