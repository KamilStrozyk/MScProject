using System.Collections.Generic;
using MScProject.Database;
using MScProject.Database.Models;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;
using System.Linq;

namespace MScProject.Services.Services
{
    public class TaskService: ITaskService
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
            throw new System.NotImplementedException();
        }

        public void Create(TaskDTO task)
        {
            _context.Set<Task>().Add(new Task
            {
                Id = task.Id,
                Title = task.Title,
                CreatedAt = task.CreatedAt,
                Description = task.Description
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
                Description = task.Description
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
            throw new System.NotImplementedException();
        }

        public void Assign(long id, long photoId)
        {
            throw new System.NotImplementedException();
        }
    }
}