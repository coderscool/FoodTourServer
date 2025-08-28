using Application.Abstractions.Gateways;
using Infrastructure.MessageBus.Consumers;
using MassTransit;
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
                    bus.Host(new Uri("amqps://flchehre:XxJUMzxjwPmRolCdjpKYEwCXs6muYn55@toucan.lmq.cloudamqp.com/flchehre"));

                    bus.ConfigureEndpoints(context);

                    bus.ReceiveEndpoint("dish-create", e =>
                    {
                        e.ConfigureConsumer<CreateDishConsumer>(context);
                    });
                });
            });
            return services;
        }

        public static IServiceCollection AddEventBusGateway(this IServiceCollection services)
            => services.AddScoped<IEventBusGateway, EventBusGateway>();
    }
}
