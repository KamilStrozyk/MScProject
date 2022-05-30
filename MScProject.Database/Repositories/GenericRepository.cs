using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MScProject.Database.Interfaces;
using MScProject.Database.Repositories.Interfaces;

namespace MScProject.Database.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private string collectionName = "";
        private readonly IMongoDbContext _mongoDbContext;

        public GenericRepository(IMongoDbContext mongoDbContext, string collectionName)
        {
            _mongoDbContext = mongoDbContext;
            this.collectionName = collectionName;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var all = await _mongoDbContext.GetCollection<T>(collectionName).FindAsync(Builders<T>.Filter.Empty);
            return await all.ToListAsync();
        }

        public async Task<T> Get(string id)
        {
            var objectId = new ObjectId(id);

            FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", objectId);

            return await _mongoDbContext.GetCollection<T>(collectionName).FindAsync(filter).Result
                .FirstOrDefaultAsync();
        }

        public async Task Create(T obj)
        {
            await _mongoDbContext.GetCollection<T>(collectionName).InsertOneAsync(obj);
        }

        public async Task Update(T obj, ObjectId id)
        {
            await _mongoDbContext.GetCollection<T>(collectionName)
                .ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), obj);
        }

        public async Task Delete(string id)
        {
            var objectId = new ObjectId(id);
            await _mongoDbContext.GetCollection<T>(collectionName)
                .DeleteOneAsync(Builders<T>.Filter.Eq("_id", objectId));
        }
    }
}