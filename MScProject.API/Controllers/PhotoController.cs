using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MScProject.Services.DTO;
using MScProject.Services.Services.Interfaces;

namespace MScProject.API.Controllers
{
    [ApiController]
    [Route("api/photo")]
    public class PhotoController : ControllerBase
    {

        private readonly ILogger<PhotoController> _logger;
        private readonly IPhotoService _photoService;
        
        public PhotoController(ILogger<PhotoController> logger, IPhotoService photoService)
        {
            _logger = logger;
            _photoService = photoService;
        }

        [HttpGet]
        public IEnumerable<PhotoDTO> GetAll()
            => _photoService.GetAllPhotos();
        
        [HttpGet("{id}")]
        public PhotoDTO GetPhoto(long id)
            => _photoService.Get(id);
        
        [HttpGet("{id}/tasks")]
        public IEnumerable<TaskDTO> GetPhotoTasks(long id)
            => _photoService.GetTasks(id);
        
        [HttpPost]
        public void CreatePhoto([FromBody] PhotoDTO photo)
            => _photoService.Create(photo);
        
        [HttpPut]
        public void UpdatePhoto([FromBody] PhotoDTO photo)
            => _photoService.Update(photo);
        
        [HttpDelete("{id}")]
        public void DeletePhoto(long id)
            => _photoService.Delete(id);
    }
}