using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MScProject.Database.Entities;
using MScProject.Database.Interfaces;
using MScProject.Database.Repositories.Interfaces;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace MScProject.Services.Services
{
    public class TaskListService : ITaskListService
    {
        private readonly ITaskListRepository _taskListRepository;

        public TaskListService(ITaskListRepository taskListRepository)
        {
            _taskListRepository = taskListRepository;
        }

        public async Task<IEnumerable<TaskListDTO>> GetAllTaskLists()
            => (await _taskListRepository.GetAll()).Select(taskList => new TaskListDTO
            {
                Id = taskList.Id,
                Title = taskList.Title,
                CreatedAt = taskList.CreatedAt
            });

        public async Task<TaskListDTO> Get(string id)
        {
            var taskList = await _taskListRepository.Get(id);
            return new TaskListDTO
            {
                Id = taskList.Id,
                Title = taskList.Title,
                CreatedAt = taskList.CreatedAt
            };
        }

        public async Task<IEnumerable<TaskDTO>> GetTasks(string id)
            => (await _taskListRepository.GetTasks(id)).Select(task => new TaskDTO
            {
                Id = task.Id,
                Description = task.Description,
                ListId = task.ListId,
                Title = task.Title,
                CreatedAt = task.CreatedAt,
                Photos = task.Photos.ToJson()
            });

        public async Task Create(TaskListDTO taskList)
        {
            var taskListToAdd = new TaskList
            {
                Id = taskList.Id,
                Title = taskList.Title,
                CreatedAt = taskList.CreatedAt
            };

            await _taskListRepository.Create(taskListToAdd);
        }

        public async Task Update(TaskListDTO taskList)
        {
            var taskListToUpdate = new TaskList
            {
                Id = taskList.Id,
                Title = taskList.Title,
                CreatedAt = taskList.CreatedAt
            };
            var objectId = new ObjectId(taskList.Id);

            await _taskListRepository.Update(taskListToUpdate, objectId);
        }

        public async Task Delete(string id)
            => await _taskListRepository.Delete(id);
    }
}