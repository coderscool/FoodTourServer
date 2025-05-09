using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.DataTransferObject;
using Contracts.Services.Account;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public interface IProjectAccountWhenAccountChangedInteractor : IInteractor<DomainEvent.AccountCreate>;
    public class ProjectAccountWhenAccountChangedInteractor : IProjectAccountWhenAccountChangedInteractor
    {
        private readonly IProjectionGateway<Projection.AccountDetails> _projectionGateway;
        public ProjectAccountWhenAccountChangedInteractor(IProjectionGateway<Projection.AccountDetails> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task InteractAsync(DomainEvent.AccountCreate @event, CancellationToken cancellationToken)
        {
            var point = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(
                new GeoJson2DGeographicCoordinates(@event.Person.Address.Longitude, @event.Person.Address.Latitude));

            Projection.AccountDetails accounts = new(
                @event.AccountId,
                @event.Person.Name,
                @event.Person.Image,
                @event.Person.Phone,
                @event.Person.Address.Address, 
                point,
                @event.Nation,
                @event.Version);

            await _projectionGateway.ReplaceInsertAsync(accounts, cancellationToken);
        }
    }
}
