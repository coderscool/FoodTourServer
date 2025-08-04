using Contracts.Services.Dish;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace Infrastructure.ElasticSearch.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddElasticSearch(this IServiceCollection services)
        {
            var url = "http://localhost:9200";
            var defaulIndex = "dish";

            var setting = new ConnectionSettings(new Uri(url)).PrettyJson().DefaultIndex(defaulIndex);

            AddDefaultMapping(setting);

            var client = new ElasticClient(setting);

            services.AddSingleton<IElasticClient>(client);

            CreateIndex(client, defaulIndex);
            return services;
        }

        private static void AddDefaultMapping(ConnectionSettings settings) 
        {
            settings.DefaultMappingFor<Projection.Dishs>(d => d.Ignore(x => x.Quantity)
                                                               .Ignore(x => x.Extra));
        }

        private static void CreateIndex(IElasticClient client, string indexName) 
        {
            client.Indices.Create(indexName, i => i.Map<Projection.Dishs>(x => x.AutoMap()));
        }
    }
}
