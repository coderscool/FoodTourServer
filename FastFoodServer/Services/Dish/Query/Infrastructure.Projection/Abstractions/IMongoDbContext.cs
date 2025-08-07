using MongoDB.Driver;

namespace Infrastructure.Projection.Abstractions
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>();
    }
}
