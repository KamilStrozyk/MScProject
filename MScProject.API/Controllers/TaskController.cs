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
        public async Task<IEnumerable<TaskDTO>> GetAll()
            => await _taskService.GetAllTasks();
        
        [HttpGet("{id}")]
        public async Task<TaskDTO> GetTask(string id)
            => await _taskService.Get(id);
        
        [HttpGet("{id}/photos")]
        public async Task<IEnumerable<PhotoDTO>> GetTaskPhotos(string id)
            => await _taskService.GetTasksPhotos(id);
        
        [HttpPost]
        public async Task CreateTask([FromBody] TaskDTO task)
            => await _taskService.Create(task);
        
        [HttpPut]
        public async Task UpdateTask([FromBody] TaskDTO task)
            => await _taskService.Update(task);
        
        [HttpDelete("{id}")]
        public async Task DeleteTask(string id)
            => await _taskService.Delete(id);
    }
}