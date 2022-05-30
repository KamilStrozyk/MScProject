using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MScProject.Database.Entities;
using MScProject.Database.Interfaces;
using MScProject.Database.Repositories.Interfaces;
using DbTask = MScProject.Database.Entities.Task;
using System.Threading.Tasks;

namespace MScProject.Database.Repositories
{
    public class TaskListRepository : GenericRepository<TaskList>, ITaskListRepository
    {
        private const string taskCollectionName = "task";
        private readonly IMongoDbContext _mongoDbContext;

        public TaskListRepository(IMongoDbContext mongoDbContext) : base(mongoDbContext, "task_list")
        {
            _mongoDbContext = mongoDbContext;
        }

        public async Task<IEnumerable<DbTask>> GetTasks(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<DbTask>.Filter.Eq("ListId", objectId);
            var all = await _mongoDbContext.GetCollection<DbTask>(taskCollectionName).FindAsync(filter);
            return all.ToList();
        }
    }
}