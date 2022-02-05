using System.Collections.Generic;
using System.Linq;
using MScProject.Database.Models;
using MScProject.Database.Repositories.Interfaces;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;

namespace MScProject.Services.Services
{
    public class TaskListService : ITaskListService
    {
        private readonly ITaskListRepository _taskListRepository;

        public TaskListService(ITaskListRepository taskListRepository)
        {
            _taskListRepository = taskListRepository;
        }

        public IEnumerable<TaskListDTO> GetAllTaskLists()
            => _taskListRepository.GetAll().Select(x => new TaskListDTO
            {
                Id = x.Id,
                Title = x.Title,
                CreatedAt = x.CreatedAt
            });

        public TaskListDTO Get(long id)
        {
            var model = _taskListRepository.Get(id);
            return new TaskListDTO
            {
                Id = model.Id,
                Title = model.Title,
                CreatedAt = model.CreatedAt
            };
        }

        public IEnumerable<TaskDTO> GetTasks(long id)
            => _taskListRepository.GetTasks(id)
                .Select(x => new TaskDTO()
                {
                    Id = x.Id,
                    Title = x.Title,
                    CreatedAt = x.CreatedAt,
                    Description = x.Description,
                    ListId = x.ListId,
                });

        public void Create(TaskListDTO taskList)
            => _taskListRepository.Add(new TaskList
            {
                Id = taskList.Id,
                Title = taskList.Title,
                CreatedAt = taskList.CreatedAt
            });


        public void Update(TaskListDTO taskList)
            => _taskListRepository.Update(new TaskList
            {
                Id = taskList.Id,
                Title = taskList.Title,
                CreatedAt = taskList.CreatedAt
            });

        public void Delete(long id)
            => _taskListRepository.Delete(id);
    }
}