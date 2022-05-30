using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MScProject.Services.DTO;
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
        public async Task<IEnumerable<TaskListDTO>> GetAll()
            => await _taskListService.GetAllTaskLists();
        
        [HttpGet("{id}")]
        public Task<TaskListDTO> GetTaskList(string id)
            => _taskListService.Get(id);
        
        [HttpGet("{id}/tasks")]
        public Task<IEnumerable<TaskDTO>> GetTaskListTasks(string id)
            => _taskListService.GetTasks(id);
        
        [HttpPost]
        public Task CreateTaskList([FromBody] TaskListDTO taskList)
            => _taskListService.Create(taskList);
        
        [HttpPut]
        public Task UpdateTaskList([FromBody] TaskListDTO taskList)
            => _taskListService.Update(taskList);
        
        [HttpDelete("{id}")]
        public Task DeleteTaskList(string id)
            => _taskListService.Delete(id);
    }
}