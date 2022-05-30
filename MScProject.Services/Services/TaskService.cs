using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MScProject.Database.Entities;
using MScProject.Database.Interfaces;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;
using Task = System.Threading.Tasks.Task;
using DbTask = MScProject.Database.Entities.Task;

namespace MScProject.Services.Services
{
    public class TaskService : ITaskService
    {
        private const string collectionName = "task";
        private const string photoCollectionName = "photo";
        private readonly IMongoDbContext _context;

        public TaskService(IMongoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskDTO>> GetAllTasks()
        {
            var all = await _context.GetCollection<DbTask>(collectionName).FindAsync(Builders<DbTask>.Filter.Empty);
            return all.ToList().Select(task => new TaskDTO()
            {
                Id = task.Id,
                Description = task.Description,
                ListId = task.ListId,
                Title = task.Title,
                CreatedAt = task.CreatedAt,
                Photos = task.Photos.ToJson()
            });
        }

        public async Task<TaskDTO> Get(string id)
        {
            var objectId = new ObjectId(id);

            var filter = Builders<DbTask>.Filter.Eq("_id", objectId);

            var task = await _context.GetCollection<DbTask>(collectionName).FindAsync(filter).Result
                .FirstOrDefaultAsync();

            return new TaskDTO()
            {
                Id = task.Id,
                Description = task.Description,
                ListId = task.ListId,
                Title = task.Title,
                CreatedAt = task.CreatedAt,
                Photos = task.Photos.ToJson()
            };
        }

        public async Task<IEnumerable<PhotoDTO>> GetTasksPhotos(string id)
        {
            var objectId = new ObjectId(id);

            var filter = Builders<DbTask>.Filter.Eq("_id", objectId);

            var task = await _context.GetCollection<DbTask>(collectionName).FindAsync(filter).Result
                .FirstOrDefaultAsync();
            var photoFilter = Builders<Photo>.Filter.In("_id", task.Photos);

            var photos = await _context.GetCollection<Photo>(photoCollectionName).FindAsync(photoFilter);
            return photos.ToList().Select(photo => new PhotoDTO()
            {
                Id = photo.Id,
                Content = photo.Content,
            });
        }

        public async Task Create(TaskDTO task)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9-]");
            var taskToAdd = new DbTask()
            {
                Id = task.Id,
                Description = task.Description,
                ListId = task.ListId,
                Title = task.Title,
                CreatedAt = task.CreatedAt,
                Photos = task.Photos.Split(",")
                    .Select(photo => new ObjectId(rgx.Replace(photo, "").Replace("ObjectId", "")))
            };

            await _context.GetCollection<DbTask>(collectionName).InsertOneAsync(taskToAdd);
        }

        public async Task Update(TaskDTO task)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9-]");
            var taskToUpdate = new DbTask()
            {
                Id = task.Id,
                Description = task.Description,
                ListId = task.ListId,
                Title = task.Title,
                CreatedAt = task.CreatedAt,
                Photos = task.Photos.Split(",")
                    .Select(photo => new ObjectId(rgx.Replace(photo, "").Replace("ObjectId", "")))
            };
            var objectId = new ObjectId(task.Id);

            await _context.GetCollection<DbTask>(collectionName)
                .ReplaceOneAsync(Builders<DbTask>.Filter.Eq("_id", objectId), taskToUpdate);
        }

        public async Task Delete(string id)
        {
            var objectId = new ObjectId(id);

            await _context.GetCollection<DbTask>(collectionName)
                .DeleteOneAsync(Builders<DbTask>.Filter.Eq("_id", objectId));
        }
    }
}