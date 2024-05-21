using Application.Abstractions;
using Application.UseCases.Queries;
using Contracts.Services.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IInteractor<Query.Login, Projection.User>, LoginUserInteractor>();
    }
}
