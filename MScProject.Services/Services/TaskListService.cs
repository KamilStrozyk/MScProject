using System.Collections.Generic;
using System.Linq;
using MScProject.Database;
using MScProject.Database.Models;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;

namespace MScProject.Services.Services
{
    public class TaskListService : ITaskListService
    {
        private readonly ApplicationDbContext _context;

        public TaskListService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskListDTO> GetAllTaskLists()
            => _context.Set<TaskList>().Select(x => new TaskListDTO
            {
                Id = x.Id,
                CreatedAt = x.CreatedAt,
                Title = x.Title
            });

        public TaskListDTO Get(long id)
            => _context.Set<TaskList>().Where(x => x.Id == id)
                .Select(x => new TaskListDTO
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    Title = x.Title
                }).Single();

        public IEnumerable<TaskDTO> GetTasks(long id)
            => _context.Set<Task>().Where(x => x.ListId == id)
                .Select(x => new TaskDTO
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    Title = x.Title,
                    Description = x.Description
                });

        public void Create(TaskListDTO taskList)
        {
            _context.Set<TaskList>().Add(new TaskList
            {
                Id = taskList.Id,
                Title = taskList.Title,
                CreatedAt = taskList.CreatedAt
            });
            _context.SaveChanges();
        }

        public void Update(TaskListDTO taskList)
        {
            _context.Set<TaskList>().Update(new TaskList
            {
                Id = taskList.Id,
                Title = taskList.Title,
                CreatedAt = taskList.CreatedAt
            });
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var toRemove = _context.Set<TaskList>().SingleOrDefault(x => x.Id == id);
            if (toRemove != null)
            {
                _context.Set<TaskList>().Remove(toRemove);
                _context.SaveChanges();
            }
        }
    }
}