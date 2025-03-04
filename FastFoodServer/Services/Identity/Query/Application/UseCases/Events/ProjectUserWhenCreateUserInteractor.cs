using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Identity;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class ProjectUserWhenCreateUserInteractor : IInteractor<DomainEvent.RegisterEvent>
    {
        private readonly IProjectionGateway<Projection.User> _projectionGateway;

        public ProjectUserWhenCreateUserInteractor(IProjectionGateway<Projection.User> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }

        public async Task InteractAsync(DomainEvent.RegisterEvent @event, CancellationToken cancellationToken)
        {
            var user = new Projection.User(@event.Id, @event.UserName, @event.PassWord, @event.Role, "");
            Console.WriteLine(user);
            await _projectionGateway.ReplaceInsertAsync(user, cancellationToken);
        }
    }
}
