using System.Collections.Generic;
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
        public IEnumerable<TaskListDTO> GetAll()
            => _taskListService.GetAllTaskLists();
        
        [HttpGet("{id}")]
        public TaskListDTO GetTaskList(long id)
            => _taskListService.Get(id);
        
        [HttpGet("{id}/tasks")]
        public IEnumerable<TaskDTO> GetTaskListTasks(long id)
            => _taskListService.GetTasks(id);
        
        [HttpPost]
        public void CreateTaskList([FromBody] TaskListDTO taskList)
            => _taskListService.Create(taskList);
        
        [HttpPut]
        public void UpdateTaskList([FromBody] TaskListDTO taskList)
            => _taskListService.Update(taskList);
        
        [HttpDelete("{id}")]
        public void DeleteTaskList(long id)
            => _taskListService.Delete(id);
    }
}