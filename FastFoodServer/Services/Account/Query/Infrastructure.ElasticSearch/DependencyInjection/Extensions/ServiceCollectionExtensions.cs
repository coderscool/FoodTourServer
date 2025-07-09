using Contracts.Services.Account;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace Infrastructure.ElasticSearch.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddElasticSearch(this IServiceCollection services)
        {
            var url = "http://localhost:9200";
            var defaulIndex = "account";

            var setting = new ConnectionSettings(new Uri(url)).PrettyJson().DefaultIndex(defaulIndex);

            AddDefaultMapping(setting);

            var client = new ElasticClient(setting);

            services.AddSingleton<IElasticClient>(client);

            CreateIndex(client, defaulIndex);
            return services;
        }

        private static void AddDefaultMapping(ConnectionSettings settings)
        {
            settings.DefaultMappingFor<Projection.AccountSellerES>(m => m);
        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            client.Indices.Create(indexName, i => i
                .Map<Projection.AccountSeller>(x => x
                    .Properties(p => p
                        .Keyword(k => k.Name("id"))
                        .Text(t => t.Name("name"))
                        .Text(t => t.Name("image"))
                        .Text(t => t.Name("phone"))
                        .Text(t => t.Name("address"))
                        .GeoPoint(g => g.Name("location")) // Elasticsearch expects lat/lon format  
                        .Keyword(k => k.Name("nation")) // List<string> maps as keyword array  
                        .Number(n => n.Name("version").Type(NumberType.Long))
                    )
                )
            );
        }
    }
}
