using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MScProject.Database.Interfaces;
using MScProject.Services.Services.Interfaces;

namespace MScProject.Services.Services
{
    public class TaskListService : ITaskListService
    {
        private readonly IMongoDbContext _dbContext;
        private const string collectionName = "task_list";
        private const string taskCollectionName = "task";

        public TaskListService(IMongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GetAllTaskLists()
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
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("task_list_id", objectId);
            return (await _dbContext.GetCollection(taskCollectionName).FindAsync(filter).Result.ToListAsync()).ToJson();
        }

        public async Task Create(string taskListJson)
        {
            BsonDocument document = BsonDocument.Parse(taskListJson);
            await _dbContext.GetCollection(collectionName).InsertOneAsync(document);
        }

        public async Task Update(string taskListJson)
        {
            BsonDocument document = BsonDocument.Parse(taskListJson);
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