using MongoDB.Driver;

namespace MScProject.Database.Interfaces
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>(string name); 
    }
}