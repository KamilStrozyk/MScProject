using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MScProject.Services.Services.Interfaces;

namespace MScProject.API.Controllers
{
    [ApiController]
    [Route("api/taskList")]
    public class TaskListController : ControllerBase
    {

        private readonly ILogger<TaskListController> _logger;
        private readonly ITaskListService _taskListService;
        
        public TaskListController(ILogger<TaskListController> logger, ITaskListService taskListService)
        {
            _logger = logger;
            _taskListService = taskListService;
        }

        [HttpGet]
        public async Task<string> GetAll()
            =>  await _taskListService.GetAllTaskLists();
        
        [HttpGet("{id}")]
        public async Task<string> GetTaskList(string id)
            => await _taskListService.Get(id);
        
        [HttpGet("{id}/tasks")]
        public async Task<string> GetTaskListTasks(string id)
            => await _taskListService.GetTasks(id);
        
        [HttpPost]
        public async Task CreateTaskList([FromBody] string taskList)
            => await _taskListService.Create(taskList);
        
        [HttpPut]
        public async Task UpdateTaskList([FromBody] string taskList)
            => await _taskListService.Update(taskList);
        
        [HttpDelete("{id}")]
        public async Task DeleteTaskList(string id)
            => await _taskListService.Delete(id);
    }
}