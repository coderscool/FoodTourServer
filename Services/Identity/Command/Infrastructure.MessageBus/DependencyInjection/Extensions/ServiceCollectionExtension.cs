using Application.Abstractions.Gateways;
using Contracts.Abstractions.Messages;
using Infrastructure.MessageBus.Consumers;
using MassTransit;
using MassTransit.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

                    bus.ReceiveEndpoint("register", e =>
                    {
                        e.ConfigureConsumer<RegisterUserConsumer>(context);
                    });
                });
            });
            return services;
        }

        public static IServiceCollection AddEventBusGateway(this IServiceCollection services)
            => services.AddScoped<IEventBusGateway, EventBusGateway>();
    }
}
