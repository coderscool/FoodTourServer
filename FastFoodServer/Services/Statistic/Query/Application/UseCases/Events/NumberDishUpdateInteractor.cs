using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class NumberDishUpdateInteractor : IInteractor<DomainEvent.NumberDishUpdate>
    {
        private readonly IProjectionGateway<Projection.Statistic> _projectionGateway;
        public NumberDishUpdateInteractor(IProjectionGateway<Projection.Statistic> projectionGateway) 
        {
            _projectionGateway = projectionGateway;
        }
        public async Task InteractAsync(DomainEvent.NumberDishUpdate @event, CancellationToken cancellationToken)
        {
            var statis = await _projectionGateway.FindAsync(x => x.Id == @event.AggregateId, cancellationToken);
            Console.WriteLine(statis);
            if(statis != null)
            {
                statis.NumberDish += @event.Quantity;
                Console.WriteLine(statis.NumberDish);
                await _projectionGateway.UpdateFieldAsync(x => x.Id == @event.AggregateId, statis, cancellationToken);
            }
            else
            {
                throw new AggregateException("fail");
            }
        }
    }
}
