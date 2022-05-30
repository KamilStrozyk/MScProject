using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MScProject.Database.Entities;
using MScProject.Database.Interfaces;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;
using Task = System.Threading.Tasks.Task;
using DbTask = MScProject.Database.Entities.Task;

namespace MScProject.Services.Services
{
    public class TaskListService : ITaskListService
    {
        private const string collectionName = "task_list";
        private const string taskCollectionName = "task";
        private readonly IMongoDbContext _context;

        public TaskListService(IMongoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskListDTO>> GetAllTaskLists()
        {
            var all = await _context.GetCollection<TaskList>(collectionName).FindAsync(Builders<TaskList>.Filter.Empty);
            return all.ToList().Select(taskList => new TaskListDTO
            {
                Id = taskList.Id,
                Title = taskList.Title,
                CreatedAt = taskList.CreatedAt.ToString()
            });
        }

        public async Task<TaskListDTO> Get(string id)
        {
            var objectId = new ObjectId(id);

            var filter = Builders<TaskList>.Filter.Eq("_id", objectId);

            var result = await _context.GetCollection<TaskList>(collectionName).FindAsync(filter).Result
                .FirstOrDefaultAsync();
            
            return new TaskListDTO
            {
                Id = result.Id,
                Title = result.Title,
                CreatedAt = result.CreatedAt.ToString()
            };
        }

        public async Task<IEnumerable<TaskDTO>> GetTasks(string id)
        {
            var objectId = new ObjectId(id);

            var filter = Builders<DbTask>.Filter.Eq("ListId", objectId);
            var all = await _context.GetCollection<DbTask>(taskCollectionName).FindAsync(filter);
            return all.ToList().Select(task => new TaskDTO
            {
                Id = task.Id,
                Description = task.Description,
                ListId = task.ListId,
                Title = task.Title,
                CreatedAt = task.CreatedAt,
                Photos = task.Photos.ToJson()
            });
        }

        public async Task Create(TaskListDTO taskList)
        {
            var taskListToAdd = new TaskList
            {
                Id = taskList.Id,
                Title = taskList.Title,
                CreatedAt = DateTime.Parse(taskList.CreatedAt)
            };

            await _context.GetCollection<TaskList>(collectionName).InsertOneAsync(taskListToAdd);
        }

        public async Task Update(TaskListDTO taskList)
        {
            var taskListToUpdate = new TaskList
            {
                Id = taskList.Id,
                Title = taskList.Title,
                CreatedAt = DateTime.Parse(taskList.CreatedAt)
            };
            var objectId = new ObjectId(taskList.Id);

            await _context.GetCollection<TaskList>(collectionName)
                .ReplaceOneAsync(Builders<TaskList>.Filter.Eq("_id", objectId), taskListToUpdate);
        }

        public async Task Delete(string id)
        {
            var objectId = new ObjectId(id);

            await _context.GetCollection<TaskList>(collectionName)
                .DeleteOneAsync(Builders<TaskList>.Filter.Eq("_id", objectId));
        }
    }
}