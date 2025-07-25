using Application.Abstractions;
using Application.Services;
using Application.UseCases.Events;
using Order = Contracts.Services.Order;
using Microsoft.Extensions.DependencyInjection;
using Contracts.Services.Delivery;
using Application.UseCases.Commands;

namespace Application.DepedencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IApplicationService, ApplicationService>()
                       .AddScoped<IInteractor<Order.SummaryEvent.OrderTransport>,  CreateDeliveryWhenOrderTransportInteractor>()
                       .AddScoped<IInteractor<Command.AddShipperDelivery>, AddShipperDeliveryInteractor>()
                       .AddScoped<IInteractor<Command.RequireDishDelivery>, RequireDishDeliveryInteractor>()
                       .AddScoped<IInteractor<Order.DomainEvent.OrderCompleteDish>, UpdateOrderDeliveryWhenOrderCompleteDishInteractor>();
    }
}
