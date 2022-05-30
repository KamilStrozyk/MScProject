using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MScProject.Database.Interfaces;
using MScProject.Services.Services.Interfaces;

namespace MScProject.Services.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IMongoDbContext _dbContext;
        private const string collectionName = "photo";
        private const string taskCollectionName = "task";

        public PhotoService(IMongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GetAllPhotos()
        {
            var all = await _dbContext.GetCollection(collectionName)
                .FindAsync(MongoDB.Driver.Builders<BsonDocument>.Filter.Empty);
            var allList = await all.ToListAsync();
            return allList.ToJson();
        }

        public async Task<string> Get(string id)
        {
            var objectId = new ObjectId(id);
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);

            return (await _dbContext.GetCollection(collectionName).FindAsync(filter).Result.FirstOrDefaultAsync())
                .ToJson();
        }

        public async Task<string> GetTasks(string id)
        {
            var objectId = new ObjectId(id);
            
            FilterDefinition<BsonDocument> taskFilter = Builders<BsonDocument>.Filter.AnyEq("photos", objectId);
            return (await _dbContext.GetCollection(taskCollectionName).FindAsync(taskFilter).Result.ToListAsync()).ToJson();        }

        public async Task Create(string photoJson)
        {
            BsonDocument document = BsonDocument.Parse(photoJson);
            await _dbContext.GetCollection(collectionName).InsertOneAsync(document);
        }

        public async Task Update(string photoJson)
        {
            BsonDocument document = BsonDocument.Parse(photoJson);
            await _dbContext.GetCollection(collectionName)
                .ReplaceOneAsync(Builders<BsonDocument>.Filter.Eq("_id", document.GetValue("_id")), document);
        }

        public async Task Delete(string id)
        {
            var objectId = new ObjectId(id);
            await _dbContext.GetCollection(collectionName).DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("_id", objectId));
        }
    }
}