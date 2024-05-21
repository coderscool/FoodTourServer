using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Identity;
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
            var user = new Projection.User
            {
                Id = @event.AggregateId,
                UserName = @event.UserName,
                PassWord = @event.PassWord,
                Name = @event.Person.Name,
                Address = @event.Person.Address,
                Phone = @event.Person.Phone,
                Image = @event.Image, 
                Role = @event.Role,
                Category = @event.Search.Category,
                Nation = @event.Search.Nation,
                Token = ""
            };
            Console.WriteLine("123456789");
            await _projectionGateway.ReplaceInsertAsync(user, cancellationToken);
        }
    }
}
