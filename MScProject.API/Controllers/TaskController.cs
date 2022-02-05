using System.Collections.Generic;
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
        public IEnumerable<TaskDTO> GetAll()
            => _taskService.GetAllTasks();
        
        [HttpGet("{id}")]
        public TaskDTO GetTask(long id)
            => _taskService.Get(id);
        
        [HttpGet("{id}/photos")]
        public IEnumerable<PhotoDTO> GetTaskPhotos(long id)
            => _taskService.GetTasksPhotos(id);
        
        [HttpPost]
        public void CreateTask([FromBody] TaskDTO task)
            => _taskService.Create(task);
        
        [HttpPut]
        public void UpdateTask([FromBody] TaskDTO task)
            => _taskService.Update(task);
        
        [HttpDelete("{id}")]
        public void DeleteTask(long id)
            => _taskService.Delete(id); 
        
        [HttpDelete("{id}/photos/{photoId}")]
        public void UnassignPhoto(long id, long PhotoId)
            => _taskService.Unassign(id, PhotoId);   
        
        [HttpPost("{id}/photos/{photoId}")]
        public void AssignPhoto(long id, long PhotoId)
            => _taskService.Assign(id, PhotoId);
    }
}