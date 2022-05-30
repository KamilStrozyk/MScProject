using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MScProject.Services.Services.Interfaces;

namespace MScProject.API.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {

        private readonly ILogger<TaskController> _logger;
        private readonly ITaskService _taskService;
        
        public TaskController(ILogger<TaskController> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<string> GetAll()
            => await _taskService.GetAllTasks();
        
        [HttpGet("{id}")]
        public async Task<string> GetTask(string id)
            => await _taskService.Get(id);
        
        [HttpGet("{id}/photos")]
        public async Task<string> GetTaskPhotos(string id)
            => await _taskService.GetTasksPhotos(id);
        
        [HttpPost]
        public async Task CreateTask([FromBody] string task)
            => await _taskService.Create(task);
        
        [HttpPut]
        public async Task UpdateTask([FromBody] string task)
            => await _taskService.Update(task);
        
        [HttpDelete("{id}")]
        public async Task DeleteTask(string id)
            => await _taskService.Delete(id);
    }
}