using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MScProject.Database.Entities;
using MScProject.Database.Interfaces;
using MScProject.Database.Repositories.Interfaces;
using DbTask = MScProject.Database.Entities.Task;

namespace MScProject.Database.Repositories
{
    public class TaskRepository : GenericRepository<DbTask>, ITaskRepository
    {
        private const string photoCollectionName = "photo";
        private readonly IMongoDbContext _mongoDbContext;

        public TaskRepository(IMongoDbContext mongoDbContext) : base(mongoDbContext, "task")
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task<IEnumerable<Photo>> GetTasksPhotos(string id)
        {
            var task = await base.Get(id);
            var photoFilter = Builders<Photo>.Filter.In("_id", task.Photos);

            var photos = await _mongoDbContext.GetCollection<Photo>(photoCollectionName).FindAsync(photoFilter);
            return photos.ToList();
        }
    }
}