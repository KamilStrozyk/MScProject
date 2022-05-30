using System.Collections.Generic;
using System.Threading.Tasks;
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
        public Task<IEnumerable<PhotoDTO>> GetAll()
            => _photoService.GetAllPhotos();
        
        [HttpGet("{id}")]
        public Task<PhotoDTO> GetPhoto(string id)
            => _photoService.Get(id);
        
        [HttpGet("{id}/tasks")]
        public Task<IEnumerable<TaskDTO>> GetPhotoTasks(string id)
            => _photoService.GetTasks(id);
        
        [HttpPost]
        public Task CreatePhoto([FromBody] PhotoDTO photo)
            => _photoService.Create(photo);
        
        [HttpPut]
        public Task UpdatePhoto([FromBody] PhotoDTO photo)
            => _photoService.Update(photo);
        
        [HttpDelete("{id}")]
        public Task DeletePhoto(string id)
            => _photoService.Delete(id);
    }
}