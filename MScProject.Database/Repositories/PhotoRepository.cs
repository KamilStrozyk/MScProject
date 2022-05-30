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
    public class PhotoRepository : GenericRepository<Photo>, IPhotoRepository
    {
        private const string taskCollectionName = "task";
        private readonly IMongoDbContext _mongoDbContext;

        public PhotoRepository(IMongoDbContext mongoDbContext) : base(mongoDbContext, "photo")
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task<IEnumerable<DbTask>> GetTasks(string id)
        {
            var objectId = new ObjectId(id);
            var taskFilter = Builders<DbTask>.Filter.AnyEq("Photos", objectId);
            var tasks = await _mongoDbContext.GetCollection<DbTask>(taskCollectionName).FindAsync(taskFilter);

            return tasks.ToList();
        }
    }
}