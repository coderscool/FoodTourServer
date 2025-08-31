using Azure;
using Azure.Identity;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Security.KeyVault.Secrets;
using Contracts.Services.Account;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ElasticSearch.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAzureSearch(this IServiceCollection services, IConfiguration config)
        {
            var serviceName = "foodtourdb-es";
            var indexName = "accounts";

            var keyVaultUrl = "https://foodtour-keyvault.vault.azure.net/"; // ví dụ: "https://foodtour-keyvault.vault.azure.net/"
            var secretName = "FoodTourSearch--AdminKey"; // tên secret bạn lưu trong Key Vault

            var secretClient = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            KeyVaultSecret secret = secretClient.GetSecret(secretName);

            var apiKey = secret.Value; // lấy ra API key
            var endpoint = new Uri($"https://{serviceName}.search.windows.net");
            var credential = new AzureKeyCredential(apiKey);

            // Tạo SearchIndexClient
            var indexClient = new SearchIndexClient(endpoint, credential);
            EnsureIndexExists<Projection.AccountSellerES>(indexClient, indexName);

            // Tạo SearchClient và inject vào DI
            var searchClient = new SearchClient(endpoint, indexName, credential);
            services.AddSingleton(searchClient);

            return services;
        }

        private static void EnsureIndexExists<T>(SearchIndexClient indexClient, string indexName)
        {
            var exists = indexClient.GetIndexNames().Contains(indexName);
            if (!exists)
            {
                var fields = new FieldBuilder().Build(typeof(T));
                var definition = new SearchIndex(indexName, fields);

                indexClient.CreateOrUpdateIndex(definition);
            }
        }
    }
}
