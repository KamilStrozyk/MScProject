using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MScProject.Database.Configuration;
using MScProject.Database.Interfaces;

namespace MScProject.Database
{
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }
        
        public MongoDbContext(IConfiguration configuration)
        {
            _mongoClient = new MongoClient(configuration["MongoSettings:Connection"]);
            _db =_mongoClient.GetDatabase(configuration["MongoSettings:DatabaseName"]);
        }
      
        public IMongoCollection<BsonDocument> GetCollection(string name)
        {
            return _db.GetCollection<BsonDocument>(name);
        }
    }
}