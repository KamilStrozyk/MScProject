using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MScProject.Database.Interfaces;
using MScProject.Services.Services.Interfaces;

namespace MScProject.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMongoDbContext _dbContext;
        private const string collectionName = "task";
        private const string photoCollectionName = "photo";

        public TaskService(IMongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GetAllTasks()
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

        public async Task<string> GetTasksPhotos(string id)
        {
            var objectId = new ObjectId(id);
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);
            var task = await _dbContext.GetCollection(collectionName).FindAsync(filter).Result.FirstOrDefaultAsync();
            var photoIds = task.GetValue("photos").AsBsonArray;
            
            FilterDefinition<BsonDocument> photoFilter = Builders<BsonDocument>.Filter.In("_id", photoIds);
            return (await _dbContext.GetCollection(photoCollectionName).FindAsync(photoFilter).Result.ToListAsync()).ToJson();
        }

        public async Task Create(string taskJson)
        {
            BsonDocument document = BsonDocument.Parse(taskJson);
            await _dbContext.GetCollection(collectionName).InsertOneAsync(document);
        }

        public async Task Update(string taskJson)
        {
            BsonDocument document = BsonDocument.Parse(taskJson);
            await _dbContext.GetCollection(collectionName)
                .ReplaceOneAsync(Builders<BsonDocument>.Filter.Eq("_id", document.GetValue("_id")), document);
        }

        public async Task Delete(string id)
        {
            var objectId = new ObjectId(id);
            _dbContext.GetCollection(collectionName).DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("_id", objectId));
        }
    }
}