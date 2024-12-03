using Contracts.Services.Identity;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ElasticSearch.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddElasticSearch(this IServiceCollection services)
        {
            var url = "http://localhost:9200";
            var defaulIndex = "user";

            var setting = new ConnectionSettings(new Uri(url)).PrettyJson().DefaultIndex(defaulIndex);

            AddDefaultMapping(setting);

            var client = new ElasticClient(setting);

            services.AddSingleton<IElasticClient>(client);

            CreateIndex(client, defaulIndex);
            return services;
        }

        private static void AddDefaultMapping(ConnectionSettings settings) 
        {
            settings.DefaultMappingFor<Projection.User>(d => d.Ignore(x => x.Image)
                                                              .Ignore(x => x.UserName)
                                                              .Ignore(x => x.PassWord)
                                                              .Ignore(x => x.Token));
        }

        private static void CreateIndex(IElasticClient client, string indexName) 
        {
            client.Indices.Create(indexName, i => i.Map<Projection.User>(x => x.AutoMap()));
        }
    }
}
