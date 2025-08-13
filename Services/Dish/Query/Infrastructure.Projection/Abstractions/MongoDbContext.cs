using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure.Projection.Abstractions
{
    public abstract class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;
        protected MongoDbContext(IConfiguration configuration, IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase("FoodTour");
        }

        public IMongoCollection<T> GetCollection<T>()
            => _database.GetCollection<T>(typeof(T).Name);
    }
}
