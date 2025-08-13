using Infrastructure.Projection.Abstractions;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Projection
{
    public class ProjectionDbContext : MongoDbContext
    {
        public ProjectionDbContext(IConfiguration configuration, IMongoClient mongoClient) : base(configuration, mongoClient)
        {
        }
    }
}
