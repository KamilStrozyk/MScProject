using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
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
        public IEnumerable<BsonDocument> GetAll()
            => _photoService.GetAllPhotos();
        
        [HttpGet("{id}")]
        public BsonDocument GetPhoto(long id)
            => _photoService.Get(id);
        
        [HttpGet("{id}/tasks")]
        public IEnumerable<BsonDocument> GetPhotoTasks(long id)
            => _photoService.GetTasks(id);
        
        [HttpPost]
        public void CreatePhoto([FromBody] BsonDocument photo)
            => _photoService.Create(photo);
        
        [HttpPut]
        public void UpdatePhoto([FromBody] BsonDocument photo)
            => _photoService.Update(photo);
        
        [HttpDelete("{id}")]
        public void DeletePhoto(long id)
            => _photoService.Delete(id);
    }
}