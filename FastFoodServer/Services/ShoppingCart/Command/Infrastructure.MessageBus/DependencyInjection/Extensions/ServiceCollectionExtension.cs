using Application.Abstractions.Gateways;
using Infrastructure.MessageBus.Consumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.MessageBus.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddConfigurationMasstransit(this IServiceCollection services)
        {
            services.AddMassTransit(mt =>
            {
                mt.SetKebabCaseEndpointNameFormatter();
                mt.SetInMemorySagaRepositoryProvider();
                mt.AddConsumers(Assembly.GetExecutingAssembly());
                mt.UsingRabbitMq((context, bus) =>
                {
                    bus.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    bus.ConfigureEndpoints(context);

                    bus.ReceiveEndpoint("createcart", e =>
                    {
                        e.ConfigureConsumer<CreateCartConsumer>(context);
                    });

                    bus.ReceiveEndpoint("changecustomercart", e =>
                    {
                        e.ConfigureConsumer<ChangeCustomerCartConsumer>(context);
                    });

                    /*bus.ReceiveEndpoint("changedscriptioncart", e =>
                    {
                        e.ConfigureConsumer<ChangeDescriptionCartConsumer>(context);
                    });*/
                });
            });
            return services;
        }

        public static IServiceCollection AddEventBusGateway(this IServiceCollection services)
            => services.AddScoped<IEventBusGateway, EventBusGateway>();
    }
}
