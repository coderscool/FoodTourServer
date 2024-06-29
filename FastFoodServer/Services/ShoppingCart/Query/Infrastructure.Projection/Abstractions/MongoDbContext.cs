using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Projection.Abstractions
{
    public abstract class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;
        protected MongoDbContext(IConfiguration configuration, IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase("Message-clone");
        }

        public IMongoCollection<T> GetCollection<T>()
            => _database.GetCollection<T>(typeof(T).Name);
    }
}
