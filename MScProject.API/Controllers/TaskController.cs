using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MScProject.Services.DTO;
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
        public Task<IEnumerable<TaskDTO>> GetAll()
            => _taskService.GetAllTasks();
        
        [HttpGet("{id}")]
        public Task<TaskDTO> GetTask(string id)
            => _taskService.Get(id);
        
        [HttpGet("{id}/photos")]
        public Task<IEnumerable<PhotoDTO>> GetTaskPhotos(string id)
            => _taskService.GetTasksPhotos(id);
        
        [HttpPost]
        public Task CreateTask([FromBody] TaskDTO task)
            => _taskService.Create(task);
        
        [HttpPut]
        public Task UpdateTask([FromBody] TaskDTO task)
            => _taskService.Update(task);
        
        [HttpDelete("{id}")]
        public Task DeleteTask(string id)
            => _taskService.Delete(id);
    }
}