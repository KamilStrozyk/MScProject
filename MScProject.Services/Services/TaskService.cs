using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using MScProject.Database.Models;
using MScProject.Database.Repositories.Interfaces;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;

namespace MScProject.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IEnumerable<TaskDTO> GetAllTasks()
            => _taskRepository.GetAll().Select(x => new TaskDTO
            {
                Id = x.Id,
                ListId = x.ListId,
                CreatedAt = x.CreatedAt,
                Description = x.Description,
                Title = x.Title
            });

        public TaskDTO Get(long id)
        {
            var model = _taskRepository.Get(id);
            return new TaskDTO
            {
                Id = model.Id,
                ListId = model.ListId,
                CreatedAt = model.CreatedAt,
                Description = model.Description,
                Title = model.Title
            };
        }

        public IEnumerable<PhotoDTO> GetTasksPhotos(long id)
            => _taskRepository.GetPhotos(id).Select(x => new PhotoDTO
            {
                Id = x.Id,
                Content = Encoding.ASCII.GetString(x.Content)
            });

        public void Create(TaskDTO task)
            => _taskRepository.Add(new Task
            {
                Id = task.Id,
                ListId = task.ListId,
                CreatedAt = task.CreatedAt,
                Description = task.Description,
                Title = task.Title
            });

        public void Update(TaskDTO task)
            => _taskRepository.Update(new Task
            {
                Id = task.Id,
                ListId = task.ListId,
                CreatedAt = task.CreatedAt,
                Description = task.Description,
                Title = task.Title
            });

        public void Delete(long id)
            => _taskRepository.Delete(id);

        public void Unassign(long id, long photoId)
            => _taskRepository.Unassign(id,photoId);

        public void Assign(long id, long photoId)
            => _taskRepository.Assign(id,photoId);
    }
}