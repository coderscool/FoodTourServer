using Infrastructure.Projection.Abstractions;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Projection
{
    public class ProjectionDbContext : MongoDbContext
    {
        public ProjectionDbContext(IConfiguration configuration, IMongoClient mongoClient) : base(configuration, mongoClient)
        {
        }
    }
}
