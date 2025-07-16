using Contracts.Services.Account.Protobuf;
using Contracts.Services.Dish.Protobuf;
using Contracts.Services.Identity.Protobuf;
using Grpc.Core;
using Grpc.Net.Client.Configuration;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebApi.DependencyInjection.Options;
using WebApplication1.DependencyInjection.Options;

namespace WebApi.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddConfigurationMasstransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(mt =>
            {
                mt.UsingRabbitMq((context, bus) =>
                {
                    bus.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    bus.ConfigureEndpoints(context);
                });
            });
            return services;
        }

        public static IServiceCollection AddConfigurationJwtBeerer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Pictur Authentication", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer vhp123'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            string issuer = "https://localhost:44381";
            string signingKey = "0123456789ABCDEF";
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                    };
                });
            return services;
        }

        public static OptionsBuilder<IdentityGrpcClientOptions> ConfigureIdentityGrpcClientOptions(this IServiceCollection services, IConfigurationSection section)
            => services
                .AddOptions<IdentityGrpcClientOptions>()
                .Bind(section);

        public static OptionsBuilder<AccountGrpcClientOptions> ConfigureAccountGrpcClientOptions(this IServiceCollection services, IConfigurationSection section)
            => services
                .AddOptions<AccountGrpcClientOptions>()
                .Bind(section);

        public static OptionsBuilder<DishGrpcClientOptions> ConfigureDishGrpcClientOptions(this IServiceCollection services, IConfigurationSection section)
            => services
                .AddOptions<DishGrpcClientOptions>()
                .Bind(section);

        public static void AddIdentityGrpcClient(this IServiceCollection services)
        => services.AddGrpcClient<Identiter.IdentiterClient, IdentityGrpcClientOptions>();

        public static void AddAccountGrpcClient(this IServiceCollection services)
        => services.AddGrpcClient<Accounter.AccounterClient, AccountGrpcClientOptions>();

        public static void AddDishGrpcClient(this IServiceCollection services)
        => services.AddGrpcClient<Disher.DisherClient, DishGrpcClientOptions>();

        private static void AddGrpcClient<TClient, TOptions>(this IServiceCollection services)
            where TClient : ClientBase
            where TOptions : class
            => services.AddGrpcClient<TClient>((provider, client) =>
            {
                var options = provider.GetRequiredService<IOptionsMonitor<TOptions>>().CurrentValue as dynamic;
                client.Address = new(options.BaseAddress);
            })
            .ConfigureChannel(options =>
            {
                options.Credentials = ChannelCredentials.Insecure;
                options.ServiceConfig = new() { LoadBalancingConfigs = { new RoundRobinConfig() } };
            }
            )
            .ConfigurePrimaryHttpMessageHandler(() =>
                new SocketsHttpHandler
                {
                    PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
                    KeepAlivePingDelay = TimeSpan.FromSeconds(60),
                    KeepAlivePingTimeout = TimeSpan.FromSeconds(30),
                    EnableMultipleHttp2Connections = true
                });
    }
}
