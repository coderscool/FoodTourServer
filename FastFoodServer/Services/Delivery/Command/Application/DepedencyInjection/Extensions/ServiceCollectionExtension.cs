using Application.Abstractions;
using Application.Services;
using Application.UseCases.Events;
using Contracts.Services.Order;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DepedencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IApplicationService, ApplicationService>()
                       .AddScoped<IInteractor<SummaryEvent.OrderTransport>,  CreateDeliveryWhenOrderTransportInteractor>();
    }
}
