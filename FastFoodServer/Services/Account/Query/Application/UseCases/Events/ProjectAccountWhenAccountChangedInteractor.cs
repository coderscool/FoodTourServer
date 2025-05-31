using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Account;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Application.UseCases.Events
{
    public interface IProjectAccountWhenAccountChangedInteractor : IInteractor<DomainEvent.AccountCreate>;
    public class ProjectAccountWhenAccountChangedInteractor : IProjectAccountWhenAccountChangedInteractor
    {
        private readonly IProjectionGateway<Projection.Account> _projectionGateway;
        private readonly IElasticSearchGateway<Projection.AccountES> _elasticSearchGateway;
        public ProjectAccountWhenAccountChangedInteractor(IProjectionGateway<Projection.Account> projectionGateway,
            IElasticSearchGateway<Projection.AccountES> elasticSearchGateway)
        {
            _projectionGateway = projectionGateway;
            _elasticSearchGateway = elasticSearchGateway;
        }
        public async Task InteractAsync(DomainEvent.AccountCreate @event, CancellationToken cancellationToken)
        {
            var point = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(
                new GeoJson2DGeographicCoordinates(@event.Person.Address.Longitude, @event.Person.Address.Latitude));

            Projection.Account accounts = new(
                @event.AccountId,
                @event.Person.Name,
                @event.Person.Image,
                @event.Person.Phone,
                @event.Person.Address.Address, 
                point,
                @event.Nation,
                @event.Version);

            await _projectionGateway.ReplaceInsertAsync(accounts, cancellationToken);
            Projection.AccountES accountes = (Projection.AccountES)accounts;
            await _elasticSearchGateway.InsertDocumentAsync(accountes);
        }
    }
}
