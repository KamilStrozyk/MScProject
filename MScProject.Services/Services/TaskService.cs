using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MScProject.Database.Repositories.Interfaces;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;
using DbTask = MScProject.Database.Entities.Task;

namespace MScProject.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskDTO>> GetAllTasks()
            => (await _taskRepository.GetAll()).Select(task => new TaskDTO
            {
                Id = task.Id,
                Description = task.Description,
                ListId = task.ListId,
                Title = task.Title,
                CreatedAt = task.CreatedAt,
                Photos = task.Photos.ToJson()
            });

        public async Task<TaskDTO> Get(string id)
        {
            var task = await _taskRepository.Get(id);

            return new TaskDTO
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
            => (await _taskRepository.GetTasksPhotos(id)).Select(photo => new PhotoDTO()
            {
                Id = photo.Id,
                Content = photo.Content,
            });

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
            await _taskRepository.Create(taskToAdd);
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

            await _taskRepository.Update(taskToUpdate, objectId);
        }

        public async Task Delete(string id)
            => await _taskRepository.Delete(id);
    }
}