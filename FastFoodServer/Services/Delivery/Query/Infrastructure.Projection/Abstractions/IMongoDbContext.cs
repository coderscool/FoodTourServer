using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Projection.Abstractions
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>();
    }
}
