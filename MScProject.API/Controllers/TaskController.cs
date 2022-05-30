using System.Collections.Generic;
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
        public IEnumerable<BsonDocument> GetAll()
            => _taskService.GetAllTasks();
        
        [HttpGet("{id}")]
        public BsonDocument GetTask(long id)
            => _taskService.Get(id);
        
        [HttpGet("{id}/photos")]
        public IEnumerable<BsonDocument> GetTaskPhotos(long id)
            => _taskService.GetTasksPhotos(id);
        
        [HttpPost]
        public void CreateTask([FromBody] BsonDocument task)
            => _taskService.Create(task);
        
        [HttpPut]
        public void UpdateTask([FromBody] BsonDocument task)
            => _taskService.Update(task);
        
        [HttpDelete("{id}")]
        public void DeleteTask(long id)
            => _taskService.Delete(id);
    }
}