using System.Collections.Generic;
using MScProject.Database;
using MScProject.Database.Models;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;
using System.Linq;
using System.Text;

namespace MScProject.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskDTO> GetAllTasks()
            => _context.Set<Task>().Where(x => x.Id != null)
                .Select(x => new TaskDTO
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    Title = x.Title,
                    Description = x.Description
                });

        public TaskDTO Get(long id)
            => _context.Set<Task>().Where(x => x.Id == id)
                .Select(x => new TaskDTO
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    Title = x.Title,
                    Description = x.Description
                }).Single();

        public IEnumerable<PhotoDTO> GetTasksPhotos(long id)
        {
            var photoIds = _context.Set<TaskPhoto>().Where(x => x.TaskId == id).Select(x => x.PhotoId).ToArray();
            return _context.Set<Photo>()
                .Where(x => photoIds.Contains(x.Id))
                .Select(x => new PhotoDTO {Id = x.Id, Content = Encoding.ASCII.GetString(x.Content)});
        }

        public void Create(TaskDTO task)
        {
            _context.Set<Task>().Add(new Task
            {
                Id = task.Id,
                Title = task.Title,
                CreatedAt = task.CreatedAt,
                Description = task.Description,
                ListId = task.ListId
            });
            _context.SaveChanges();
        }

        public void Update(TaskDTO task)
        {
            _context.Set<Task>().Update(new Task
            {
                Id = task.Id,
                Title = task.Title,
                CreatedAt = task.CreatedAt,
                Description = task.Description,
                ListId = task.ListId
            });
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var toRemove = _context.Set<Task>().SingleOrDefault(x => x.Id == id);
            if (toRemove != null)
            {
                _context.Set<Task>().Remove(toRemove);
                _context.SaveChanges();
            }
        }

        public void Unassign(long id, long photoId)
        {
            _context.Set<TaskPhoto>().Remove(new TaskPhoto
            {
                TaskId = id,
                PhotoId = photoId
            });
            _context.SaveChanges();
        }

        public void Assign(long id, long photoId)
        {
            _context.Set<TaskPhoto>().Add(new TaskPhoto
            {
                TaskId = id,
                PhotoId = photoId
            });
            _context.SaveChanges();
        }
    }
}