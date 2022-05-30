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
        public async Task<TaskListDTO> GetTaskList(string id)
            => await _taskListService.Get(id);
        
        [HttpGet("{id}/tasks")]
        public async Task<IEnumerable<TaskDTO>> GetTaskListTasks(string id)
            => await _taskListService.GetTasks(id);
        
        [HttpPost]
        public async Task CreateTaskList([FromBody] TaskListDTO taskList)
            => await _taskListService.Create(taskList);
        
        [HttpPut]
        public async Task UpdateTaskList([FromBody] TaskListDTO taskList)
            => await _taskListService.Update(taskList);
        
        [HttpDelete("{id}")]
        public async Task DeleteTaskList(string id)
            => await _taskListService.Delete(id);
    }
}