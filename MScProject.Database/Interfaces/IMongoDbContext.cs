using MongoDB.Bson;
using MongoDB.Driver;

namespace MScProject.Database.Interfaces
{
    public interface IMongoDbContext
    {
        IMongoCollection<BsonDocument> GetCollection(string name); 
    }
}