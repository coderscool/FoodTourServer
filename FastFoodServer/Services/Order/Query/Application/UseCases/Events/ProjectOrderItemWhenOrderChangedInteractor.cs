using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public interface IProjectOrderItemWhenOrderChangedInteractor :
        IInteractor<DomainEvent.OrderPlaced>;
    public class ProjectOrderItemWhenOrderChangedInteractor : IInteractor<DomainEvent.StatusUpdate>
    {
        private readonly IProjectionGateway<Projection.Order> _projectionGateway;
        public ProjectOrderItemWhenOrderChangedInteractor(IProjectionGateway<Projection.Order> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
       
    }
}
